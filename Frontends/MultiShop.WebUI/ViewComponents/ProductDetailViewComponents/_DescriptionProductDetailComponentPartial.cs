﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _DescriptionProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        public _DescriptionProductDetailComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetProductDetailByProductIdAsync(id);
            return View(values);
        }
    }
}
