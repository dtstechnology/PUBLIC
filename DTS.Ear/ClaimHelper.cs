using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using DTS.Ear.Library;
using DTS.Ear.Library.Configuration;
using DTS.Logic.Layer.DataIO;
using DTS.Logic.Layer.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DTS.Ear
{
    public class ClaimUserModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string role { get; set; }

    }

    public class ClaimHelper
    {
     
        public IHttpContextAccessor _httpContextAccessor;
        private readonly IEarLibraryLogic _earLibLogic;
        public ClaimHelper(IHttpContextAccessor httpContextAccessor, IEarLibraryLogic earLibLogic)
        {
            _httpContextAccessor = httpContextAccessor;
            _earLibLogic = earLibLogic;
        }


        public string getCurrentClaim()
        {
            var contextRequest = _httpContextAccessor.HttpContext?.Request;
            string? userAgentString = contextRequest?.Headers["user-agent"].ToString();

            if (string.IsNullOrEmpty(userAgentString))
            {
                userAgentString = "Unknown";
            }

            return userAgentString;
        }

    }




    //public class DTSAutohorizeAttribute : AuthorizeAttribute
    //{
    //    public class Role
    //    {
    //        public const string Supervisor = "Supervisor";
    //        public const string Accountant = "Accountant";
    //        public const string Company = "Company";
    //        public const string Employee = "Employee";
    //    }

    //    public class Module
    //    {
    //        public string Cari = Role.Supervisor + "," + Role.Accountant;
    //        /*
    //            hesaplar    
    //            finans      
    //            muhasebe     
    //            insan kaynakları 
    //            imalat
    //            depo / stok
    //            pazarlama 
    //            satın alma 
    //            ihracat 
    //            Yönetim


    //            / hesaplar / müşteri / tedarikçi     
    //            / banka / çek / kasa 
    //            / finans / stok / fatura / irsaliye / teklif sipariş / personel / demirbaş


    //            */

    //    }



    //}
}
