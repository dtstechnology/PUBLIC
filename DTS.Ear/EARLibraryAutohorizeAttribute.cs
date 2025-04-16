

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using DTS.Logic.Layer.DataIO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Ear
{

    public class EARLibraryAutohorizeAttribute : AuthorizeAttribute 
    {
     
        public void OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext context)
        {

            var userLogic = context.HttpContext.RequestServices.GetService(typeof(UserLogic)) as UserLogic;
            var earLibLogic = context.HttpContext.RequestServices.GetService(typeof(EarLibraryLogic)) as EarLibraryLogic;


            string name = context.HttpContext.User.Claims.FirstOrDefault(f => f.Type.Contains("name")).Value;
            string id = (context.HttpContext.User.Claims.FirstOrDefault(f => f.Type.Contains("nameidentifier")).Value);
            string role = context.HttpContext.User.Claims.FirstOrDefault(f => f.Type.Contains("role")).Value;
 
               
            W_TGO_CRS_EASET crsSettings = userLogic.GetUserSettings(id);

            if (string.IsNullOrEmpty(crsSettings.EAU) || string.IsNullOrEmpty(crsSettings.EAP))
            {
                context.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "auth",
                                    action = "logout"
                                })
                            );

            }
        }

         

            //if (confg.Token ==null || confg.Password == null || confg.Username == null)
            //{
            //    earLibLogic.Logout(); 
            //}



        }
         


        //if (configuration == null)
        //{
        //    configuration = FaturaServiceConfigurationFactory.Create();
        //    configuration.ServiceType = ServiceType.Prod;
        //    W_TGO_CRS_SET crsSettings = userLogic.GetUserSettings(id);
        //    configuration.Username = crsSettings.EARID;
        //    configuration.Password = crsSettings.EARPD; //User.Claims.FirstOrDefault(c => c.Type == "earpd").Value;

        //    earLibLogic.setConfiguration(configuration);
        //} 


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
