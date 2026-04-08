using Microsoft.AspNetCore.Mvc;

namespace W18.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
