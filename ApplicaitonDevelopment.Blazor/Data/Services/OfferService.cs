using ApplicationDevelopment.Blazor.Data.DTO;
using Newtonsoft.Json;

namespace ApplicationDevelopment.Blazor.Data.Services
{
    public class OfferService
    {
        private readonly HttpClient _httpClient;
        public OfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OfferData>?> GetOfferAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7252/api/PublishOffer/GetOffers");
            var result = response.Content.ReadAsStringAsync().Result;
            var rr = JsonConvert.DeserializeObject<List<OfferData>>(result);
            return rr;
        }
    }
}
