
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/GetActiveCommentCount");
            var value = await response.Content.ReadFromJsonAsync<int>();
            return value;
        }

        public async Task<int> GetPassiveCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/GetPassiveCommentCount");
            var value = await response.Content.ReadFromJsonAsync<int>();
            return value;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/GetTotalCommentCount");
            var value = await response.Content.ReadFromJsonAsync<int>();
            return value;
        }
    }
}
