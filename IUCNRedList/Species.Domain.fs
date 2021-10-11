module IUCNRedList.Domain

type Undefined = exn

module Species =
  type TaxonId = TaxonId of int

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
    { TaxonId: TaxonId
      KingdomName: KingdomName
      PhylumName: PhylumName
      ClassName: ClassName
      OrderName: OrderName
      FamilyName: FamilyName
      ScientificName: ScientificName
      TaxonomicAuthority: TaxonomicAuthority
      InfraRank: InfraRank option
      InfraName: InfraName option
      Population: Population option
      Category: Category
      MainCommonName: MainCommonName option }

  type Count = Count of int

  type Result = Result of Species list

  type SpeciesListResponse = { Count: Count; Result: Result }

  type ConservationMeasures = ConservationMeasures of string

  type SpeciesWithConservationMeasures =
    { TaxonId: TaxonId
      KingdomName: KingdomName
      PhylumName: PhylumName
      ClassName: ClassName
      OrderName: OrderName
      FamilyName: FamilyName
      ScientificName: ScientificName
      TaxonomicAuthority: TaxonomicAuthority
      InfraRank: InfraRank option
      InfraName: InfraName option
      Population: Population option
      Category: Category
      MainCommonName: MainCommonName option
      ConservationMeasures: ConservationMeasures }
