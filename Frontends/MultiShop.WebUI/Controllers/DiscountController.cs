using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCode(code);
            var basketValues = await _basketService.GetBasketAsync();

            var discountRate = values.Rate;
            var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice * 10 / 100);
            var totalPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax * discountRate / 100);

            return RedirectToAction("Index", "ShoppingCard", new { discountCode = code, discountRate = discountRate, totalPriceWithDiscount = totalPriceWithDiscount});
        }
    }
}
