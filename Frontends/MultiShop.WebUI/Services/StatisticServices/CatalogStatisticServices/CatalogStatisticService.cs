
namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetProductCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount");
            var value = await responseMessage.Content.ReadFromJsonAsync<long>();
            return value;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMaxPriceProductName");
            var value = await responseMessage.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetMinPriceProductName");
            var value = await responseMessage.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<decimal> GetAvgProductPrice()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetAvgProductPrice");
            var value = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return value;
        }

        
    }
}
