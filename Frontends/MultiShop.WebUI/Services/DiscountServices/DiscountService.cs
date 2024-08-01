using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCouponCodeDto> GetDiscountCode(string couponCode)
        {
            var response = await _httpClient.GetAsync($"discounts/GetDiscountCodeDetailByCouponCode?code={couponCode}");
            var values = await response.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCouponCodeDto>();
            if (values == null)
            {
                throw new Exception("İndirim kuponu bulunamadı.");
            }
            return values;
        }
    }
}
