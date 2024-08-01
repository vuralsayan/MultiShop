using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCardController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string discountCode, int discountRate, decimal totalPriceWithDiscount)
        {
            ViewBag.Directory1 = "Anasayfa";
            ViewBag.Directory3 = "Sepetim";

            ViewBag.DiscountCode = discountCode;
            ViewBag.DiscountRate = discountRate;
            ViewBag.TotalPriceWithDiscount = totalPriceWithDiscount;

            var values = await _basketService.GetBasketAsync();
            ViewBag.TotalPrice = values.TotalPrice;

            var tax = (values.TotalPrice * 10) / 100;
            ViewBag.Tax = tax;

            var totalPriceWithTax = values.TotalPrice + tax;
            ViewBag.TotalPriceWithTax = totalPriceWithTax;

            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var product = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductImageUrl = product.ProductImageUrl,
                Price = product.ProductPrice,
                Quantity = 1
            };

            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
