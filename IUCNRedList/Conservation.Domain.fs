namespace IUCNRedList

module Conservation =

  type ConservationMeasure = { Code: string; Title: string }

  type ConservationMeasureListResponse =
    { Id: string
      Result: ConservationMeasure list }

  type ConservationMeasureForSpecies = { Id: string; Measures: string }

  let concatMeasureTitle conservationMeasureListResponse =
    conservationMeasureListResponse
    |> List.map (fun m -> m.Title)
    |> String.concat "; "
