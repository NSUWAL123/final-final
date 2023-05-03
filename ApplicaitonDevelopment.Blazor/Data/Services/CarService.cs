using ApplicationDevelopment.Blazor.Data.DTO;
using Newtonsoft.Json;

namespace ApplicationDevelopment.Blazor.Data.Services
{
    public class CarService
    {
        private readonly HttpClient _httpClient;
        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CarData>?> GetCarsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7252/api/Cars");
            var result = await response.Content.ReadAsStringAsync();
            var rr = JsonConvert.DeserializeObject<IEnumerable<CarData>>(result);
            return rr;
        }

        public async Task<CarData?> GetCarsByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7252/api/Cars/{id}");
            var result = response.Content.ReadAsStringAsync().Result;
            var rr = JsonConvert.DeserializeObject<CarData>(result);
            return rr;
        }
    }
}
