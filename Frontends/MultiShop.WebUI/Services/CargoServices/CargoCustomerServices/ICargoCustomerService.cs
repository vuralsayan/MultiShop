﻿using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByUserCustomerIdDto> GetCargoCustomerByUserCustomerIdAsync(string userCustomerId);
    }
}
