namespace MultiShop.SignalRRealTimeApi.Services.MessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string userId);
        
    }
}
