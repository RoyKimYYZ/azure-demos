#r "Newtonsoft.Json"
#r "System.Net.Http" // Need for http client to call weather API

using System.Net.Http; // Need for http client to call weather API
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    const string apiKey = "<GET-API-KEY>"; // weather api key (e.g. weatherstack.com)
    string defaultLocationCityCountry = "Toronto, Canada";

    string location = req.Query["location"]; // To parse http query string
    
    log.LogInformation($"req location: {location}");
    string locationCityCountry = string.IsNullOrEmpty(location) ? defaultLocationCityCountry : location;

    // prepare the url for http client to call weatherstack api
    string url = $"http://api.weatherstack.com/current?access_key={apiKey}&query={locationCityCountry}";
    log.LogInformation($"url: {url}");
    
    // Initiate http call with weatherstack api
    var client = new HttpClient();
    var response = await client.GetAsync(url);

    // Handle the http response
    var json = await response.Content.ReadAsStringAsync();
    dynamic responseData = JsonConvert.DeserializeObject(json);
    
    string responseMessage = string.IsNullOrEmpty(json)
        ? "This HTTP triggered function executed successfully!! "
                : $"This HTTP triggered function executed successfully! \n weatherstack json response is \n {json}";
            return new OkObjectResult(responseMessage);

}
