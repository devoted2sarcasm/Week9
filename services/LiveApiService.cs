using System.Text;
using System.Text.Json;
// using week9exercise.exceptions;
using week9exercise.models.responses;
using week9exercise.models.requests;

namespace week9exercise.services {
    public class LiveApiService {
        private static readonly string BASE_URL = "https://livre.azurewebsites.net";

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<BookResponse?> RetrieveBookById(int bookId)
        {
            Console.WriteLine($"CALLING FOR BOOK WITH ID {bookId}");
            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}/books/{bookId}");

            // If the HTTP Response was successful...
            if (response.IsSuccessStatusCode)
            {
                // Read the response and output it to a string.
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"DONE CALLING FOR BOOK WITH ID {bookId}");

                // Use the JsonSerializer class to turn the JSON response from the API into our Todo class.
                return JsonSerializer.Deserialize<BookResponse>(responseBody);
            }
            else
            {
                // If the HTTP Response was not successful, we throw our custom ExternalServiceException detailing the error.
                throw new Exception($"Error occured calling for todo with id {bookId}. {response.StatusCode}: {response.ReasonPhrase}");
            }
        }

        public async Task<List<BookResponse>> RetrieveBooks()
        {
            Console.WriteLine($"CALLING FOR BOOKS");
            HttpResponseMessage response = await _httpClient.GetAsync($"{BASE_URL}/books");

            // If the HTTP Response was successful...
            if (response.IsSuccessStatusCode)
            {
                // Read the response and output it to a string.
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"DONE CALLING FOR BOOKS");

                // Use the JsonSerializer class to turn the JSON response from the API into our Todo class.
                return JsonSerializer.Deserialize<List<BookResponse>>(responseBody);
            }
            else
            {
                // If the HTTP Response was not successful, we throw our custom ExternalServiceException detailing the error.
                throw new Exception($"Error occured calling for books. {response.StatusCode}: {response.ReasonPhrase}");
            }
        }

        public async Task<BookResponse> CreateBook(Book request) {
            Console.WriteLine($"CALLING TO CREATE BOOK");

            // Serialize our TodoCreateRequest to JSON so it can be included as the HTTP Request Body.
            string jsonRequestBody = JsonSerializer.Serialize(request);

            // Create our HttpContent (the HTTP Request Body), including our TodoCreateRequest and some standard encoding
            // as well as define that we want to use application/json.
            HttpContent httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            // Finally, make the HTTP request to create a new TODO.
            HttpResponseMessage response = await _httpClient.PostAsync($"{BASE_URL}/books", httpContent);

            if (response.IsSuccessStatusCode) {
                // Read the response and output it to a string.
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<BookResponse>(responseBody);
            } else {
                // If the HTTP Response was not successful, we throw our custom ExternalServiceException detailing the error.
                throw new Exception($"Error occured attempting to create book. {response.StatusCode}: {response.ReasonPhrase}");
            }

        }

        public async Task UpdateBook(Book request, int bookId) {
            Console.WriteLine($"CALLING TO UPDATE BOOK");

            // Serialize our TodoCreateRequest to JSON so it can be included as the HTTP Request Body.
            string jsonRequestBody = JsonSerializer.Serialize(request);

            // Create our HttpContent (the HTTP Request Body), including our TodoCreateRequest and some standard encoding
            // as well as define that we want to use application/json.
            HttpContent httpContent = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            // Finally, make the HTTP request to create a new TODO.
            HttpResponseMessage response = await _httpClient.PutAsync($"{BASE_URL}/books/{bookId}", httpContent);

            if (response.IsSuccessStatusCode) {
                Console.WriteLine($"DONE CALLING TO UPDATE BOOK");
                return;
            } else {
                // If the HTTP Response was not successful, we throw our custom ExternalServiceException detailing the error.
                throw new Exception($"Error occured attempting to update todo with id {bookId}. {response.StatusCode}: {response.ReasonPhrase}");
            }

        }

        public async Task DeleteBookById(int bookId)
        {
            Console.WriteLine($"CALLING TO DELETE BOOK WITH ID {bookId}");
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{BASE_URL}/books/{bookId}");

            // If the HTTP Response was successful...
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"DONE CALLING TO DELETE BOOK WITH ID {bookId}");
                return;
            }
            else
            {
                // If the HTTP Response was not successful, we throw our custom ExternalServiceException detailing the error.
                throw new Exception($"Error occured attempting to delete todo with ID {bookId}. {response.StatusCode}: {response.ReasonPhrase}");
            }
        }
    }

}