using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApiCors.Controllers
{
    public class FetchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
