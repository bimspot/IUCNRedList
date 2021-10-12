namespace IUCNRedList

module Conservation =

  type Code = Code of string

  type Title = Title of string

  type ConservationMeasure = { Code: Code; Title: Title }

  type Id = Id of string

  type Result = Result of ConservationMeasure list

  type ConservationMeasureListResponse = { Id: Id; Result: Result }
  
  type ConservationMeasureForSpecies = {Id: Id; Measures: string}
