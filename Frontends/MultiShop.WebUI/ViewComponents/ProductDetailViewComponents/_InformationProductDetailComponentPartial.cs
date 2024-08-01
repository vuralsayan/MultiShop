using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _InformationProductDetailComponentPartial : ViewComponent
    {
       private readonly IProductDetailService _productDetailService;

        public _InformationProductDetailComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetProductDetailByProductIdAsync(id);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"{_apiSettings.ProductDetailApiUrl}/GetProductDetailByProductId?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<ResultProductDetailDto>(jsonData);
            //    return View(values);
            //}
            return View(values);
        }
    }
}
