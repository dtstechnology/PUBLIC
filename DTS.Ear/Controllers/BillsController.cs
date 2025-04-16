using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Web.Helpers;
using DTS.Ear.Library.Models.UpdateInvoice;
using DTS.Logic.Layer.DataIO;
using DTS.Logic.Layer.ViewModels;
using DTS.Logic.Layer.ViewModels.DTOs;
using static DTS.Logic.Layer.ViewModels.DTOs.W_TGO_STOCK;

namespace DTS.Ear.Controllers
{

    [Authorize]
    [EARLibraryAutohorizeAttribute]
    public class BillsController : Controller
    {
       

        private readonly ILogger<HomeController> _logger;
        private readonly IEarLibraryLogic _earLibLogic;
        private readonly IUserLogic _userLogic;
        private readonly IBillsLogic _billslogic;
        public BillsController(ILogger<HomeController> logger, IBillsLogic billslogic, IUserLogic userLogic, IEarLibraryLogic earLibLogic)
        {
            _logger = logger;
            _userLogic = userLogic;
            _earLibLogic = earLibLogic;
            _billslogic = billslogic;
        }


         

        public IActionResult List(W_TGO_BILLS_LIST model)
        { 
            //model.BILL_LIST = _billslogic.GetAllBills();
            return View(model); 
        }
        public JsonResult Load(W_TGO_BILLS_LIST model, string t)
        {
            model.BILL_LIST = _billslogic.GetAllBills();

            return Json(new { data = model });

        }

        public IActionResult Detail(string i)
        {
            W_TGO_BILLS_LIST billModel = new W_TGO_BILLS_LIST();
            string decoded_i = Encoding.UTF8.GetString(Convert.FromBase64String(i));

            billModel.BILL = _billslogic.GetBillDetail(decoded_i);
            billModel.malHizmetList = JsonConvert.DeserializeObject<List<StockMalHizmetTable>>(billModel.BILL.MALHIZMET);

            return View(billModel);

        }

        [HttpGet]
        public IActionResult Add(W_TGO_BILLS_ADD model)
        {
             
            var time = DateTime.Now.TimeOfDay;
            var date = DateTime.Now.Date;
            //https://datatables.net/reference/api/row.add()
            //JSON.stringify($('#advanced_search_results').DataTable().rows().data().toArray());
            return View(model);
        }

        [HttpPost]
        public JsonResult Add(W_TGO_BILLS_ADD model, int i)
        {
           
            var time = DateTime.Now.TimeOfDay;
            var date = DateTime.Now.Date; 
            if (!string.IsNullOrEmpty(model.BILL.AD))
            {
                
                model = _billslogic.AddBill(model);
                if (model.BILL.BLID != 0)
                {
                    model.RESULT = true;
                    model.RESULT_MESSAGE = "Fatura Başarıyla Oluşturuldu";
                    return Json(model);

                }
            }
            return Json(model);
        }




        public IActionResult Details(string uuid)
        {
            string userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string token = Request.Cookies["tkn"];

            var viewModel = new W_TGO_INVDETAIL(); 
            viewModel.INVOICES_HTML = _earLibLogic.getFaturaDetailHTML(uuid, userId, token); 
            return View(viewModel);
        }
          
        public IActionResult Create(W_TGO_INVCREATE invoiceModel)
        {
            return View();
        }

        public JsonResult Remove(int[] ids)
        {
            //var x = _billslogic.MovetoTrash(ids);
            return Json(true);
        }


    }

}

