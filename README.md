# Dad Joke API Console Application

This C# Console app interacts with the Dad Joke API, which allows uers to retrieve random jokes by specific IDs.

## Issues Encountered and how they were Resolved

### Issue 1: Unable to Retrieve API Data

#### Steps Taken:
- **Issue Description:** Was unable to retrieve data from the Dad Joke API.
- **Resolution:** Checked the API endpoint URL and verified it. Also, verified the API documentation to ensure correct usage of endpoints. 
                  Found out that the issue was due to incorrect headers; added "User-Agent" header to the HTTP requests, and the issue was resolved.

### Issue 2: Invalid Joke ID Handling

#### Steps Taken:
- **Issue Description:** The application was crashing when an invalid joke ID was entered.
- **Resolution:** Implemented try-catch blocks in the `GetJokeByIdAsync` method to handle `HttpRequestException` and `JsonException` appropriately.
                  Displayed a user-friendly error message to the user when an invalid joke ID was entered, preventing application crashes.

### Issue 3: API Rate Limiting

#### Steps Taken:
- **Issue Description:** Encountered rate limiting issues when making too many requests to the API in a short period.
- **Resolution:** Implemented rate limiting logic in the application by limiting the number of API requests per minute.
                  Displayed a message to the user when the rate limit was reached and advised to wait for a minute before making another request.

## How to Use the Application

- Clone the repository to your local machine.
- Open the solution in Visual Studio or your preferred C# IDE.
- Build and run the application.
- Follow the on-screen menu instructions to interact with the Dad Joke API and enjoy some awful dad jokes!

Feel free to contribute and improve this application! If you encounter any issues or have suggestions, please create an issue in this repository.
