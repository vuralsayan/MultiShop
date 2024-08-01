using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
    public class _ProductListShoppingCardComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ProductListShoppingCardComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasketAsync();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
