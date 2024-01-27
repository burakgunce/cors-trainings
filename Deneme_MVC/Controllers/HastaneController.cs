using ConsumeWebApiCors.Models.HospitalVMs;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApiCors.Controllers
{
    public class HastaneController : Controller
    {
        private readonly string apiAddress = "https://localhost:7133/api/Hastaneler/";
        HttpClient client;
        public HastaneController()
        {
            client = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            //hastane Id name ve adres gelicek
            List<HospitalVM> hospitals = await client.GetFromJsonAsync<List<HospitalVM>>(apiAddress + "getall");
            return View();
        }

        public async Task<IActionResult> GetById(int id = 1)
        {
            HospitalVM hospital = await  client.GetFromJsonAsync<HospitalVM>(apiAddress + "getbyid?id=" + id);
            return View();
        }

        public async Task<IActionResult> Create(HospitalCreateVM hospitalCreateVM)
        {
            hospitalCreateVM.HastaneAd = "medipol";
            hospitalCreateVM.Adres = "kosuyolu";

            var result = await client.PostAsJsonAsync<HospitalCreateVM>(apiAddress + "add", hospitalCreateVM);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Hata", "Eklenirken bir hata oluştu");

            return View();
        }

        public async Task<IActionResult> Update(HospitalUpdateVM hospitalUpdateVM, int id=1)
        {
            hospitalUpdateVM.Name = "qwe";
            hospitalUpdateVM.Adres = "emınonu";

            var result = await client.PutAsJsonAsync(apiAddress + "update?id=" + id, hospitalUpdateVM);

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await client.DeleteAsync(apiAddress + "delete?id=" + id);
            return View();
        }
        
    }
}
