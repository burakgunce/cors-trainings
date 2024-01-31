using ConsumeWebApiCors.Models.HospitalVMs;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApiCors.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View();
        }

        public IActionResult GetAll2()
        {
            //Esas çalışan bu
            return View();
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalVM hospitalVM)
        {
            return View();
        }

        
    }
}
