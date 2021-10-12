namespace IUCNRedList

open IUCNRedList.Region

type Undefined = exn

module Species =
  (*
  There is a typo in the API response, this is supposed to be snake
  but it isn't.
  *)
  type Taxonid = Taxonid of int

  type KingdomName = KingdomName of string

  type PhylumName = PhylumName of string

  type ClassName = ClassName of string

  type OrderName = OrderName of string

  type FamilyName = FamilyName of string

  type ScientificName = ScientificName of string

  type TaxonomicAuthority = TaxonomicAuthority of string

  type InfraRank = InfraRank of string

  type InfraName = InfraName of string

  type Population = Population of Undefined

  type Category = Category of string

  type MainCommonName = MainCommonName of string

  type Species =
    { Taxonid: Taxonid
      KingdomName: KingdomName
      PhylumName: PhylumName
      ClassName: ClassName
      OrderName: OrderName
      FamilyName: FamilyName
      ScientificName: ScientificName
      TaxonomicAuthority: TaxonomicAuthority option
      InfraRank: InfraRank option
      InfraName: InfraName option
      Population: Population option
      Category: Category
      MainCommonName: MainCommonName option }

  type Count = Count of int

  type SpeciesListResponse =
    { Count: Count
      RegionIdentifier: RegionIdentifier option
      Result: Species list }

  type ConservationMeasures = ConservationMeasures of string

  type SpeciesWithConservationMeasures =
    { Taxonid: Taxonid
      KingdomName: KingdomName
      PhylumName: PhylumName
      ClassName: ClassName
      OrderName: OrderName
      FamilyName: FamilyName
      ScientificName: ScientificName
      TaxonomicAuthority: TaxonomicAuthority option
      InfraRank: InfraRank option
      InfraName: InfraName option
      Population: Population option
      Category: Category
      MainCommonName: MainCommonName option
      ConservationMeasures: ConservationMeasures option }

  let filterCriticallyEndangeredSpecies speciesListResponse =
    speciesListResponse.Result
    |> List.filter (fun s -> s.Category = Category "CR")

  let filterMammals speciesListResponse =
    speciesListResponse.Result
    |> List.filter (fun s -> s.ClassName = ClassName "MAMMALIA")
