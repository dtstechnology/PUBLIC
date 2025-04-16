using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using DTS.Ear.Library;
using DTS.Ear.Library.Configuration;
using DTS.Logic.Layer.DataIO;
using Microsoft.AspNetCore.Identity;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Ear.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILogger<HomeController> _logger;
        private readonly IEarLibraryLogic _earLibLogic;
        private readonly IUserLogic _userLogic;

        public AuthController(IHttpContextAccessor httpContextAccessor,ILogger<HomeController> logger, IUserLogic userLogic, IEarLibraryLogic earLibLogic)
        {
            _httpContextAccessor = httpContextAccessor;
          
            _logger = logger;
            _userLogic = userLogic;
            _earLibLogic = earLibLogic;
        }
        [HttpGet("SignUp")]
        public IActionResult SignUp()
        {

            return View();
        } 

        [HttpGet("SignIn")]
        public IActionResult SignIn(string returnUrl)
        {

            ViewData["returnUrl"] = returnUrl == "/" ? "Home/Dashboard" : returnUrl;
            return View();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Validate(string uname, string pass, string returnUrl) //(r = returnUrl)
        {
            

            ViewData["r"] = returnUrl;
            if (string.IsNullOrEmpty(returnUrl))
                returnUrl = "Home/Dashboard";

            W_TGO_CRS model = _userLogic.UserLogin(uname, pass);
            

            if (model != null)
            {
                if (model.CRACT)
                {
                    //W_TGO_CRS_EASET crsSettings = _userLogic.GetUserSettings(model.CRID.ToString()); 

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, model.CRNE));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, model.CRID.ToString()));

                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddHours(2); 
                    Response.Cookies.Append("tkn", "", cookie);

                    //if (crsSettings != null)
                    //{
                    //    var x = _earLibLogic.setConfiguration(model.CRID, "");
                    //    //var x = _earLibLogic.setTestConfiguration(model.CRID, ""); //TESTPORTAL
                    //    if (!string.IsNullOrEmpty(x.Token))
                    //    {
                    //        Response.Cookies.Append("tkn", x.Token); 

                    //    }
                    //}
                    
                    //if (_earLibLogic.PresetOK(crsSettings))
                    //{
                    //    claims.Add(new Claim("earid", crsSettings.EARID));
                    //    claims.Add(new Claim("earpd", crsSettings.EARPD));
                    //}
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    await HttpContext.SignInAsync(claimsPrincipal);
                   
                    //var tokenDesc = new SecurityTokenDescriptor
                    //{
                    //    Subject = new ClaimsIdentity(
                    //        new Claim[] {
                    //            new Claim(ClaimTypes.Name, "test"),
                    //        }
                    //        ),
                    //    Expires = DateTime.Now.AddMinutes(2);

                    //};


                    return Redirect(returnUrl);
                }
                else
                {
                    TempData["error"] = "Hesabınız henüz aktif değil! Detaylı bilgi için lütfen destek ekibimiz ile görüşün.";
                    return View("SignIn");
                }
            }
            TempData["error"] = "Hata! Kullanıcı Adı yada şifreniz hatalı";
            return View("SignIn");
        }



        public async Task<IActionResult> Logout()
        {
            string userId = (this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            string token = Request.Cookies["tkn"];
            await HttpContext.SignOutAsync();
            Response.Cookies.Delete("tkn");
            //_earLibLogic.Logout(userId,token);
            return Redirect("/Home/Dashboard");
        }
    }
}
