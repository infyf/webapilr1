using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab5.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.apilayer.com/email_verification";
        private const string ApiKey = "tvg9jDcBBXpXSAlGcU4D6sSnrRqeUrn9";

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("apikey", ApiKey);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        // GET метод для отримання даних
        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/{endpoint}");
                var content = await response.Content.ReadAsStringAsync();

                var result = new ApiResponse<T>
                {
                    StatusCode = (int)response.StatusCode
                };

                if (!response.IsSuccessStatusCode)
                {
                    result.Message = $"API returned error: {response.StatusCode}";
                    return result;
                }

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var item = JsonSerializer.Deserialize<T>(content, options);

                if (item != null)
                {
                    result.Data.Add(item);
                }

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Message = $"Error: {ex.Message}",
                    StatusCode = 500
                };
            }
        }

        // POST метод для отримання даних з параметрами
        public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BaseUrl}/{endpoint}", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = new ApiResponse<T>
                {
                    StatusCode = (int)response.StatusCode
                };

                if (!response.IsSuccessStatusCode)
                {
                    result.Message = $"API returned error: {response.StatusCode}";
                    return result;
                }

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var item = JsonSerializer.Deserialize<T>(responseContent, options);

                if (item != null)
                {
                    result.Data.Add(item);
                }

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Message = $"Error: {ex.Message}",
                    StatusCode = 500
                };
            }
        }
    }
}
