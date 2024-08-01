namespace MultiShop.SignalRRealTimeApi.Services.CommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
