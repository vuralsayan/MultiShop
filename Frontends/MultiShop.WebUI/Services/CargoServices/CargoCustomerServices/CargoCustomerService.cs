using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByUserCustomerIdDto> GetCargoCustomerByUserCustomerIdAsync(string userCustomerId)
        {
            var response = await _httpClient.GetAsync($"cargocustomers/GetCargoCustomerByUserCustomerID?userCustomerID={userCustomerId}");
            var value = await response.Content.ReadFromJsonAsync<GetCargoCustomerByUserCustomerIdDto>();
            return value;
        }
    }
}
