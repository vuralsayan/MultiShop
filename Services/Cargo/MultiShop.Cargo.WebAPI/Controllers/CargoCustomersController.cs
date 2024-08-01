using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCustomerList()
        {
            var values = await _cargoCustomerService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerById(int id)
        {
            var value = await _cargoCustomerService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
            await _cargoCustomerService.TInsertAsync(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCustomer(int id)
        {
            await _cargoCustomerService.TDeleteAsync(id);
            return Ok("Kargo müşterisi başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(updateCargoCustomerDto);
            await _cargoCustomerService.TUpdateAsync(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla güncellendi.");
        }

        [HttpGet("GetCargoCustomerByUserCustomerID")]
        public async Task<IActionResult> GetCargoCustomerByUserCustomerID(string userCustomerID)
        {
            var value = await _cargoCustomerService.TGetCargoCustomerByUserCustomerID(userCustomerID);
            return Ok(value);
        }
    }
}
