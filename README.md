# coding exercise

Build a simple app using the technology of your choice and integrate the following features using the public IUCN Red List API. http://apiv3.iucnredlist.org/api/v3/docs

1. Load the list of the available regions for species
2. Take a random region from the list
3. Load the list of all species in the selected region — the first page of the results would suffice, no need for pagination
4. Create a model for “Species” and map the results to an array of Species.
5. Filter the results for Critically Endangered species
   a. Fetch the conservation measures for all _**critically endangered**_ species
   b. Store the “title”-s of the response in the Species model as concatenated text property.
   c. Print/display the results
6. Filter the results (from step 4) for the **_mammal_** class
   a. Print/display the results
   Please publish the code to GitHub (or other git service) including commits as you progress.

 
— 

**bimspot engineering**

[stackshare](https://stackshare.io/bimspot/bimspot-io) | [github](https://github.com/bimspot)