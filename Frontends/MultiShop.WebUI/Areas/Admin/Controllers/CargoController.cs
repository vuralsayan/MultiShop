using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanysDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> CargoCompanyList()
        {
            SetViewBag();
            ViewBag.v3 = "Kargo Şirketleri Listesi";
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            SetViewBag();
            ViewBag.v3 = "Yeni Kargo Şirketi Girişi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            SetViewBag();
            ViewBag.v3 = "Yeni Kargo Şirketi Girişi";
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });

        }

        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            SetViewBag();
            ViewBag.v3 = "Kargo Şirketi Güncelleme";
            var value = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        void SetViewBag()
        {
            ViewBag.PageTitle = "Kargo Şirketi İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kargo İşlemleri";
        }
    }
}
