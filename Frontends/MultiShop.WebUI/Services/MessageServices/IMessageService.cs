using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInBoxMessageDto>> GetInboxMessageAsync(string userId);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string userId);
        Task<int> GetTotalMessageCountByReceiverId(string userId);
    }
}
