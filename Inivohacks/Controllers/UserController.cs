using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
