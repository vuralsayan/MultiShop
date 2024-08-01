using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public ProductListController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public IActionResult Index(string id)
        {
            ViewBag.categoryID = id;
            ViewBag.Directory1 = "Anasayfa";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Ürün Listesi";
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.productID = id;
            ViewBag.Directory1 = "Anasayfa";
            ViewBag.Directory2 = "Ürün Listesi";
            ViewBag.Directory3 = "Ürün Detayları";
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> AddComment()
        {
            await Task.CompletedTask;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto, string productID)
        {
            createCommentDto.ImageUrl = "text123";
            createCommentDto.CreatedDate = DateTime.Now;
            createCommentDto.Status = false;
            //createCommentDto.ProductID = "667213b3242f7137c91457ed";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_apiSettings.CommentApiUrl}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductDetail", "ProductList", new { id = createCommentDto.ProductID });
            }
            return View();
        }
    }
}
