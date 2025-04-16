using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DTS.Logic.Layer.DataIO;
using DTS.Logic.Layer.ViewModels;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Ear.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly AccountsLogic _accountsLogic;

        public AccountsController(AccountsLogic accountsLogic)
        {
            _accountsLogic = accountsLogic;
        }

        public IActionResult List(W_TGO_ACCOUNTS_LIST model)
        {
            return View(model);
        }
        public IActionResult Customers(List<W_TGO_ACNTS> viewModel)
        {
            //var x = typeof(W_TGO_ACNTS).GetProperties().Length;
            //var ix = typeof(W_TGO_ACNTS).GetProperties(); 
            //foreach (var item in ix)
            //{
            //    var xs = item;
            //}

            viewModel = _accountsLogic.GetAllAccounts().OrderByDescending(x => x.ACID).ToList();
            return View(viewModel);
        }

        public IActionResult Suppliers(List<W_TGO_ACNTS> viewModel)
        {


            //viewModel = _accountsLogic.GetAllCustomer();
            return View(viewModel);
        }

         

        public IActionResult Add(W_TGO_ACNTS viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.COMPANYNAME))
            {
                viewModel = _accountsLogic.AddCustomer(viewModel);
            } 

            return View(viewModel);
        }

        public IActionResult Detail(W_TGO_ACNTS viewModel)
        {


            return View(viewModel);
        }

        public JsonResult getCustomers(List<W_TGO_ACNTS> viewModel)
        {

            var x = typeof(W_TGO_ACNTS).GetProperties().Length;
            var ix = typeof(W_TGO_ACNTS).GetProperties();

            foreach (var item in ix)
            {
                var xs = item;
            }

            viewModel = _accountsLogic.GetAllAccounts();
            return Json(viewModel);
        }


        public string getTest()
        {
            //var list = _accountsLogic.GetAllCustomer();
            //var result = JsonConvert.SerializeObject(new { data = list });

            return "";
        }

        public JsonResult Load(W_TGO_ACCOUNTS_LIST vm, string i)
        {
            vm.ACCOUNT_LIST = _accountsLogic.GetAllAccounts();
            //var jsonString = JsonSerializer.Serialize(stockActvModel);  
            return Json(new { data = vm });
        }


    }
}
