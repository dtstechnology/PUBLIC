using Microsoft.AspNetCore.Mvc;

namespace DTS.Ear.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
