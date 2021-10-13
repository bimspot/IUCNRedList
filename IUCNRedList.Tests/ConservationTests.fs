module IUCNRedList.Tests

open NUnit.Framework
open FsUnit
open IUCNRedList.Conservation

[<SetUp>]
let Setup () =
  ()

[<Test>]
let concatenatedTitles () =
  let list = [
    {
      Code = "1.1.1"
      Title = "Does he look like a bitch?"
    }
    {
      Code = "1.1.2"
      Title = "Zed's dead, baby. Zed's dead."
    }
  ]
  let expected = "Does he look like a bitch?; Zed's dead, baby. Zed's dead." 
  let titles = list |> concatMeasureTitle
  titles |> should equal expected
