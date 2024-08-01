using MultiShop.DtoLayer.MessageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;
        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInboxMessageAsync(string userId)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessages/GetInboxUserMessage?id={userId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
            if (values != null)
                return values;
            return new List<ResultInBoxMessageDto>();

        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string userId)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessages/GetSendboxUserMessage?id={userId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSendboxMessageDto>>(jsonData);
            if (values != null)
                return values;
            return new List<ResultSendboxMessageDto>();
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string userId)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessages/GetTotalMessageCountByReceiverId?id={userId}");
            var value = await responseMessage.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
