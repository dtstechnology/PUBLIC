using DTS.Core.SystemIO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using DTS.Logic.Layer.DataIO;
using DTS.Logic.Layer.ViewModels;

namespace DTS.Ear.Controllers
{
    [Authorize]
    [EARLibraryAutohorizeAttribute]
    public class HomeController : Controller
    { 
        
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly ILogger<HomeController> _logger;
        private readonly IEarLibraryLogic _earLibLogic;
        private readonly UserLogic _userLogic;


        public HomeController(
            IHttpContextAccessor httpContextAccessor, 
            ILogger<HomeController> logger, 
            UserLogic userLogic, 
            IEarLibraryLogic earLibLogic
        )
        {
            
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userLogic = userLogic;
            _earLibLogic = earLibLogic;
        }

        [HttpGet]
        public IActionResult GetProfileData(int id)
        {
            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewModelBase model = new ViewModelBase();
            model.CRS_PROFILE = _userLogic.GetUserProfile(userId);
            return PartialView("1");
        }
         

        public IActionResult Dashboard(W_TGO_EARDASHBOARD dashboardModel)
        { 
            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var name = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            string token = Request.Cookies["tkn"];

            dashboardModel.CRS_LIST = _userLogic.GetAllUsers();
            
           

            //dashboardModel.CRS = new W_TGO_CRS();
            //dashboardModel.CRS.CREL = "kevin_watson-1990@hotmail.com";
            //dashboardModel.CRS.CRNE = "watson";
            //dashboardModel.CRS.CRPD = "0101";

            //dashboardModel.CRS.CRLL = "0101";
            //dashboardModel.CRS.CRRE = "0101";
            //dashboardModel.CRS.CRCR = false;
            //dashboardModel.CRS.CRLLN = "0101";
            //dashboardModel.CRS.CRACT = false; 
            //_userLogic.UserRegister(dashboardModel.CRS); 
            //return Redirect("/auth/logout");



            
            return View(dashboardModel);
        }

        [Authorize(Roles = "Supervisor")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult AccessDenied()
        {
            return View();
        }
         

    }
}
