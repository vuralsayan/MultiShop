namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<int> GetTotalCommentCount();
        Task<int> GetPassiveCommentCount();
        Task<int> GetActiveCommentCount();
    }
}
