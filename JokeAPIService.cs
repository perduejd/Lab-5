using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DadJokeAPI;

namespace DadJokeAPI
{
    public class JokeApiService
    {
        private readonly HttpClient _client; // Http Client is a class that allows us to make HTTP requests

        public JokeApiService() // Initalize HttpClient and set the Accept header to application/json
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json"); // Setting the Accept header to application/json
        }

        public async Task<string> GetRandomJokeAsync() // Method used to retrieve a random joke from the API asynchonously
        {
            HttpResponseMessage response = await _client.GetAsync("https://icanhazdadjoke.com/"); // GET req to random joke endpoint
            response.EnsureSuccessStatusCode(); // Ensuring the respone is successful
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic jokeObject = JsonConvert.DeserializeObject(responseBody); // Deserialize JSON response to dynamic object
            return jokeObject.joke; // Returns the random joke
        }

        public async Task<string[]> SearchJokesAsync(string term) // Method that allows you to search for a dad joke based on a search term asynchonously
        {
            HttpResponseMessage response = await _client.GetAsync($"https://icanhazdadjoke.com/search?term={term}"); // GET request to search endpoint with provided search term
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync(); 
            dynamic jokesResponse = JsonConvert.DeserializeObject(responseBody); 

            List<string> jokesList = new List<string>(); // Creates a list to store retrieved jokes

            foreach (var jokeObject in jokesResponse.results) // Iterates through results and add jokes to the list 
            {
                jokesList.Add(jokeObject.joke.ToString());
            }

            return jokesList.ToArray(); // Returns the list of jokes as an array
        }
    }
}