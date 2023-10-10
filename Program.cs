using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DadJokeAPI;
class Program
{
    static async Task Main(string[] args)
    {
        JokeApiService jokeApiService = new JokeApiService(); // Creates a new instance of the JokeApiService class

        while (true) // Menu
        {
            Console.WriteLine("Choose an option:\n");
            Console.WriteLine("1. Get a terrible Dad Joke");
            Console.WriteLine("2. Search for Dad Jokes by Key Word");
            Console.WriteLine("3. Exit Dad Joke App");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        string randomJoke = await jokeApiService.GetRandomJokeAsync(); // Calls the GetRandomJokeAsync method
                        Console.WriteLine($"\nRandom Joke: {randomJoke}\n"); // Displays the random joke
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "2":
                    Console.Write("Enter search term: "); // Prompts user to enter a search term
                    string searchTerm = Console.ReadLine(); // Stores the search term in a variable
                    try
                    {
                        var jokes = await jokeApiService.SearchJokesAsync(searchTerm); // Calls the SearchJokesAsync method
                        foreach (var joke in jokes) // Iterates through the jokes and displays them
                        {
                            Console.WriteLine(joke); // Displays the joke
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}