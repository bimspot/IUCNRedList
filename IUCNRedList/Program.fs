open IUCNRedList.IUCNService
open IUCNRedList.Region
open IUCNRedList.Species

[<EntryPoint>]
let main _ =
 
  let lastRegion regionListResponse =
     List.last regionListResponse.Results
     
  let criticallyEndangered speciesListResponse =
    speciesListResponse.Result
    |> List.filter (fun s -> s.Category = Category "CR")
     
  let regionListResponse = 
    regionList
    |> Async.RunSynchronously // TODO: replace this to stay async
    |> lastRegion
    |> species
    |> Async.RunSynchronously // TODO: replace this to stay async
    |> criticallyEndangered
    |> printfn "%A"
  
  
  0
