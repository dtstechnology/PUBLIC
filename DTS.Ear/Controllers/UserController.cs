using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTS.Ear.Controllers
{
    [Authorize]
    [EARLibraryAutohorizeAttribute]
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Messages()
        {
            return View();
        }

      
    }
}
