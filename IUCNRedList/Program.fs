open IUCNRedList.IUCNService
open IUCNRedList.Region
open IUCNRedList.Species

[<EntryPoint>]
let main _ =

  let lastRegion regionListResponse = List.last regionListResponse.Results

  let filterCriticallyEndangeredSpecies speciesListResponse =
    speciesListResponse.Result
    |> List.filter (fun s -> s.Category = Category "CR")

  let criticallyEndangeredSpecies =
    fetchRegionList
    |> Async.RunSynchronously // TODO: replace this to stay async
    |> lastRegion
    |> fetchAllSpeciesInRegion
    |> Async.RunSynchronously // TODO: replace this to stay async
    |> filterCriticallyEndangeredSpecies
  
  let conservationMeasures =
    criticallyEndangeredSpecies.[..3] // Only fetching the first three
    |> List.map (fun s -> s.Taxonid)
    |> List.map fetchConservationMeasuresForSpecies
    |> Async.Parallel
    |> Async.RunSynchronously
    |> printfn "%A"

  0 // Exit the app
