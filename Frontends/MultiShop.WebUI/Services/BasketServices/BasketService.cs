using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient client)
        {
            _httpClient = client;
        }

        //public async Task AddBasketItem(BasketItemDto basketItemDto)
        //{
        //    var values = await GetBasketAsync();
        //    if (values != null)
        //    {
        //        if (!values.BasketItems.Any(x => x.ProductID == basketItemDto.ProductID))
        //        {
        //            values.BasketItems.Add(basketItemDto);
        //        }
        //        else
        //        {
        //            values = new BasketTotalDto();
        //            values.BasketItems.Add(basketItemDto);
        //        }
        //    }
        //    await SaveBasketAsync(values);
        //}

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasketAsync();
            if (values == null)
            {
                values = new BasketTotalDto
                {
                    BasketItems = new List<BasketItemDto>()
                };
            }

            var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductID == basketItemDto.ProductID);

            if (existingItem == null)
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
            {
                existingItem.Quantity += basketItemDto.Quantity;
            }

            await SaveBasketAsync(values);
        }


        public Task DeleteBasketAsync(string userID)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task<bool> RemoveBasketItem(string productID)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductID == productID);
            if (deletedItem != null)
            {
                values.BasketItems.Remove(deletedItem);
                await SaveBasketAsync(values);
                return true;
            }
            return false;
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync("baskets", basketTotalDto);
        }
    }
}
