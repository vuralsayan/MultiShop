using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.CommentServices;
using MultiShop.SignalRRealTimeApi.Services.MessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var totalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveTotalCommentCount", totalCommentCount);

            

        }
    }
}
