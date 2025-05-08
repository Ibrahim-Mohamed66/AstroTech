using Microsoft.AspNetCore.Mvc;

namespace AstroTech.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
