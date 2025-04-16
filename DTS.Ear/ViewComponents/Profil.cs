using DTS.Core.SystemIO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using DTS.Logic.Layer.DataIO;
using DTS.Logic.Layer.ViewModels;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Ear.ViewComponents
{
    public class Profil : ViewComponent
    {
        private readonly UserLogic _userLogic;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;
        public Profil(UserLogic userLogic, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _userLogic = userLogic;
            webHostEnvironment = hostEnvironment;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
       

            //string wwwPath = webHostEnvironment.WebRootPath;
            //string contentPath = webHostEnvironment.ContentRootPath;
            //string path = Path.Combine(contentPath, "src" , "profile" , userId);
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}


            ViewModelBase model = new ViewModelBase();
            model.CRS_PROFILE = _userLogic.GetUserProfile(userId);
            if (model.CRS_PROFILE == null){ 
                model.CRS_PROFILE = new W_TGO_CRS_PROFILE();
            }
            if (!string.IsNullOrEmpty(model.CRS_PROFILE.PROFILEIMG)){
                model.CRS_PROFILE.PROFILEIMG = $@"/src/Profile/{userId}/{model.CRS_PROFILE.PROFILEIMG}";
            }
            else{
                model.CRS_PROFILE.PROFILEIMG = "/src/Profile/Shared/profileDefault.jpg";
            }

            return View(model);
        }
    }
}
