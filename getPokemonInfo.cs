using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using PokemonApiVS.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PokemonApiVS
{
    public static class getPokemonInfo
    {
        [FunctionName("getPokemonInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "getPokemonInfo/pokemon/{name}")] HttpRequest req,
            ILogger log, string name)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            HttpClient client = new HttpClient();
            log.LogInformation($"This is the name of the pokemon from the route: {name}");
            string stringTask = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/" + name);
            dynamic jsonResponse = JObject.Parse(stringTask);

            var getDetails = new GetImportantPokemonDetails();
            getDetails.name = jsonResponse.name;
            getDetails.order = jsonResponse.order;
            getDetails.stats = jsonResponse["stats"].ToObject<List<dynamic>>();
            getDetails.weight = jsonResponse.weight;
            return new OkObjectResult(getDetails);
        }
    }
}
