﻿namespace MultiShop.Basket.Dtos
{
    public class BasketItemDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
