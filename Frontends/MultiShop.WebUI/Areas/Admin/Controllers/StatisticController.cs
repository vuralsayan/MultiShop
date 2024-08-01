using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticServices _discountStatisticServices;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IDiscountStatisticServices discountStatisticServices, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticServices = discountStatisticServices;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            SetViewBag();

            var brandCount = await _catalogStatisticService.GetBrandCount();
            ViewBag.BrandCount = brandCount;

            var productCount = await _catalogStatisticService.GetProductCount();
            ViewBag.ProductCount = productCount;

            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            ViewBag.CategoryCount = categoryCount;

            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();  
            ViewBag.MaxPriceProductName = maxPriceProductName;

            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.MinPriceProductName = minPriceProductName;

            //var avgProductPrice = await _catalogStatisticService.GetAvgProductPrice();
            //ViewBag.AvgProductPrice = avgProductPrice;

            var userCount = await _userStatisticService.GetUserCount();
            ViewBag.UserCount = userCount;

            var totalCommentCount = await _commentStatisticService.GetTotalCommentCount();  
            ViewBag.TotalCommentCount = totalCommentCount;

            var activeCommentCount = await _commentStatisticService.GetActiveCommentCount();
            ViewBag.ActiveCommentCount = activeCommentCount;

            var passiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();
            ViewBag.PassiveCommentCount = passiveCommentCount;

            var discountCouponCount = await _discountStatisticServices.GetDiscountCouponCount();
            ViewBag.DiscountCouponCount = discountCouponCount;

            var messageCount = await _messageStatisticService.GetTotalMessageCount();
            ViewBag.MessageCount = messageCount;

            return View();
        }

        void SetViewBag()
        {
            ViewBag.PageTitle = "İstatistikler";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İstatistikler";
        }
    }
}
