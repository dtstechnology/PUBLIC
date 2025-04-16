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
    public class StockController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEarLibraryLogic _earLibLogic;
        private readonly IUserLogic _userLogic;
        private readonly IStockLogic _stockLogic;

        public StockController(ILogger<HomeController> logger, IUserLogic userLogic, IStockLogic stockLogic, IEarLibraryLogic earLibLogic)
        {
            _stockLogic = stockLogic;
            _logger = logger;
            _userLogic = userLogic;
            _earLibLogic = earLibLogic;
        }
        public IActionResult Add(W_TGO_STOCK stockModel)
        {
            if (!string.IsNullOrEmpty(stockModel.STOKADI))
            {
                stockModel = _stockLogic.AddStock(stockModel);
            }
            return View(stockModel);
        }

        public IActionResult Update(W_TGO_STOCK stockModel)
        {
            return View(stockModel);
        }

        public IActionResult List(W_TGO_STOCK_LIST stockModel)
        {
            return View(stockModel);
        }
 

        [HttpPost]
        public IActionResult Detail(string i, string submit, W_TGO_STOCK_LIST model)
        {
            if (!string.IsNullOrEmpty(i))
            {
                string encoded_i = Encoding.UTF8.GetString(Convert.FromBase64String(i));
                model = _stockLogic.GetStockDetail(encoded_i);
                return RedirectToAction("Detail", new { i = model.STOCK.STID64 });
            }
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet]
        public IActionResult Detail(string i)
        {
            if (!string.IsNullOrEmpty(i))
            {
                string encoded_i = Encoding.UTF8.GetString(Convert.FromBase64String(i));
                W_TGO_STOCK_LIST stockModel = new W_TGO_STOCK_LIST();
                stockModel = _stockLogic.GetStockDetail(encoded_i);
                return View(stockModel);
            }
            return RedirectToAction("Dashboard", "Home");
        }
        public IActionResult RecycleBin(W_TGO_STOCK_LIST stockModel)
        {
            stockModel.STOCK_LIST = _stockLogic.GetAllRecycleBinStock();
            return View(stockModel);
        }
         

        [HttpGet]
        public IActionResult Activity(string i)
        {
            if (!string.IsNullOrEmpty(i))
            {
                string encoded_i = Encoding.UTF8.GetString(Convert.FromBase64String(i));
                W_TGO_STOCK_LIST stockModel = new W_TGO_STOCK_LIST();
                stockModel.STOCK_ACTIVITIES = _stockLogic.GetStockActivity(encoded_i);
                return View(stockModel);
            }
            return RedirectToAction("Dashboard", "Home");
        }






        public JsonResult Load(W_TGO_STOCK_LIST vm, string i)
        {
            vm.STOCK_LIST = _stockLogic.GetAllStock();
            //var jsonString = JsonSerializer.Serialize(stockActvModel);  
            return Json(new { data = vm });
        }
        public JsonResult Remove(string[] i)
        {
            //TODO: STOKLA İLGİLİ TÜM HAREKETLERİN SİLİNMESİ GEREKİR !!!
            if (i.Count() == 0)
            {
                return Json(false);
            }
            var x = _stockLogic.MovetoTrash_Stock(i);
            return Json(true);
        }
        public JsonResult ActivitiesLoad(W_TGO_STOCK_LIST vm, string i)
        {
            string encoded_i = Encoding.UTF8.GetString(Convert.FromBase64String(i));
            vm.STOCK_ACTIVITIES_LIST = _stockLogic.GetStockActivities(encoded_i);
            return Json(new { data = vm });
        }
        public JsonResult TakeOff(W_TGO_STOCK_LIST vm)
        { 
            vm = _stockLogic.TakeOff(vm); 
            return Json(vm);
        }
        public JsonResult TakeOn(W_TGO_STOCK_LIST vm)
        {
            vm = _stockLogic.TakeOn(vm);
            return Json(vm);
        }



    }
}

