
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticServices : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var response = await _httpClient.GetAsync("userMessages/GetTotalMessageCount");
            var value = await response.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
