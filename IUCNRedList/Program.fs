open IUCNRedList.Region
open IUCNRedList.Species
open IUCNRedList.Conservation
open IUCNRedList.IUCNService

[<EntryPoint>]
let main _ =

  (*
    1. Load the list of the available regions for species.
    2. Take a random region from the list.
  *)
  let lastRegion regionListResponse = List.last regionListResponse.Results

  (*
    3. Load the list of all species in the selected region
    4. Create a model for “Species” and map the results to an array of Species.
  *)
  let allSpecies =
    fetchRegionList
    |> Async.RunSynchronously // TODO: replace this to stay async
    |> lastRegion
    |> fetchAllSpeciesInRegion
    |> Async.RunSynchronously // TODO: replace this to stay async

  (*
    5. Filter the results for Critically Endangered species
  *)
  let criticallyEndangeredSpecies =
    allSpecies |> filterCriticallyEndangeredSpecies

  // Maximum number of species to work with to not kill the API
  let someCriticallyEndangeredSpecies = criticallyEndangeredSpecies.[..3]

  (*
    5.a Fetch the conservation measures for all critically endangered species
  *)

  let conservationMeasures =
    someCriticallyEndangeredSpecies.[..3] // Only fetching the first three
    |> List.map (fun s -> s.Taxonid)
    |> List.map fetchConservationMeasuresForSpecies
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Array.map
         (fun response ->
           { Id = response.Id
             Measures = concatMeasureTitle response.Result })
    |> Array.toList

  (*
    5.b Store the “title”-s of the response in the Species model as
    concatenated text property.
  *)
  let speciesWithConservationMeasuresList =
    List.zip someCriticallyEndangeredSpecies conservationMeasures
    |> List.map
         (fun (species, measures) ->
           { Taxonid = species.Taxonid
             KingdomName = species.KingdomName
             PhylumName = species.PhylumName
             ClassName = species.ClassName
             OrderName = species.OrderName
             FamilyName = species.FamilyName
             ScientificName = species.ScientificName
             TaxonomicAuthority = species.TaxonomicAuthority
             InfraRank = species.InfraRank
             InfraName = species.InfraName
             Population = species.Population
             Category = species.Category
             MainCommonName = species.MainCommonName
             ConservationMeasures = Some(ConservationMeasures measures.Measures) })

  printfn "\n\nSpecies with conservation measures:\n\n"

  speciesWithConservationMeasuresList
  |> printfn "%A"

  (* 6. Filter the results (from step 4) for the mammal class. *)
  printfn "\n\nAll mammals:\n\n"
  allSpecies |> filterMammals |> printfn "%A"

  0 // Exit the app
