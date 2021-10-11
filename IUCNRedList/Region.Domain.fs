module IUCNRedList.Region_Domain

module Region =
  type RegionName = RegionName of string

  type RegionIdentifier = RegionIdentifier of string

  type Region =
    { Name: RegionName
      Identifier: RegionIdentifier }

  type Count = Count of int

  type Result = Result of Region list

  type RegionListResponse = { Count: Count; Result: Result }
