namespace IUCNRedList

module Region =
  type RegionName = RegionName of string

  type RegionIdentifier = RegionIdentifier of string

  type Region =
    { Name: RegionName
      Identifier: RegionIdentifier }

  type Count = Count of int

  type RegionListResponse = { Count: Count; Results: Region list }
