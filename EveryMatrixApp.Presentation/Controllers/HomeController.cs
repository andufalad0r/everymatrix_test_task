using Microsoft.AspNetCore.Mvc;

namespace EveryMatrixApp.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
