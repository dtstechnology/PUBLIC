using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System;
using DTS.Logic.Layer.DataIO;
using DTS.Logic.Layer.ViewModels;
using DTS.Logic.Layer.ViewModels.DTOs;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace DTS.Ear.Controllers
{

    [Authorize]
    [EARLibraryAutohorizeAttribute]
    public class StockActivitiesController : Controller
    {
        private readonly ILogger<StockActivitiesController> _logger;
        private readonly IEarLibraryLogic _earLibLogic;
        private readonly IUserLogic _userLogic;
        private readonly IStockLogic _stockLogic;

        public StockActivitiesController(ILogger<StockActivitiesController> logger, IUserLogic userLogic, IStockLogic stockLogic, IEarLibraryLogic earLibLogic)
        {
            _stockLogic = stockLogic;
            _logger = logger;
            _userLogic = userLogic;
            _earLibLogic = earLibLogic;
        }
         
        public IActionResult Detail(string i)
        {
            //stockModel.STOCK_LIST = _stockLogic.GetAllStock();
            return View();
        }
        public IActionResult List(W_TGO_STOCK_ACTV_LIST vm)
        {
            //stockModel.STOCK_LIST = _stockLogic.GetAllStock();
            return View(vm);
        }
        public IActionResult Add(W_TGO_STOCK vm)
        {

            return View(vm);

        }


     

        public JsonResult Add(W_TGO_STOCK_ACTV_LIST vm, string i)
        {
            string encoded_i = Encoding.UTF8.GetString(Convert.FromBase64String(i));
            vm.STOCK_ACTV_LIST = _stockLogic.GetStockActivities(encoded_i);

            return Json(new { data = vm });
        }

        public JsonResult Delete(W_TGO_STOCK_ACTV_LIST vm, string i)
        {
            string encoded_i = Encoding.UTF8.GetString(Convert.FromBase64String(i));
            vm.STOCK_ACTV_LIST = _stockLogic.GetStockActivities(encoded_i);

            return Json(new { data = vm });
        }

        public IActionResult TakeOn(string i)
        {
            W_TGO_STOCK_ACTV vm = new W_TGO_STOCK_ACTV();
            return View(vm);
        }

        public IActionResult TakeOff()
        {
            W_TGO_STOCK_ACTV vm = new W_TGO_STOCK_ACTV();
            return View(vm);
        }

        public JsonResult Remove(string[] i)
        {
            if (i.Count() == 0)
            {
                return Json(false);
            }
            var x = _stockLogic.MovetoTrash_StockActivities(i);
            return Json(true);
        }



    }
}

