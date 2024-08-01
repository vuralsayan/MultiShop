using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultUserMessageDto>> GetAllUserMessageAsync();
        Task<List<ResultInBoxUserMessageDto>> GetInboxUserMessageAsync(string id);
        Task<List<ResultSendBoxUserMessageDto>> GetSendBoxUserMessageAsync(string id);
        Task CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto);
        Task UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto);
        Task DeleteUserMessageAsync(int id);
        Task<GetByIdUserMessageDto> GetByIdUserMessageAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
