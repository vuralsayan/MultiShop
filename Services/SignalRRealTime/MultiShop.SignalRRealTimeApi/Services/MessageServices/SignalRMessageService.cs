namespace MultiShop.SignalRRealTimeApi.Services.MessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string userId)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessages/GetTotalMessageCountByReceiverId?id={userId}");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
