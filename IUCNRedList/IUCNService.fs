namespace IUCNRedList

open FSharp.Data
open FSharp.Json
open IUCNRedList.Region
open IUCNRedList.Species

// TODO: error handling of request and deserialisation
module IUCNService =
  let apiKey =
    "9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee"

  let regionList =
    async {
      let! response =
        Http.AsyncRequestString(
          "http://apiv3.iucnredlist.org/api/v3/region/list",
          query = [ "token", apiKey ],
          silentHttpErrors = true
        )

      let config =
        JsonConfig.create (jsonFieldNaming = Json.snakeCase)

      let result =
        Json.deserializeEx<RegionListResponse> config response

      return result
    }

  let species region =
    async {
      let (RegionIdentifier identifier) = region.Identifier

      let url =
        $"http://apiv3.iucnredlist.org/api/v3/species/region/{identifier}/page/0"

      let! response =
        Http.AsyncRequestString(
          url,
          query = [ "token", apiKey ],
          silentHttpErrors = true
        )

      let config =
        JsonConfig.create (jsonFieldNaming = Json.snakeCase)

      let result =
        Json.deserializeEx<SpeciesListResponse> config response

      return result
    }
