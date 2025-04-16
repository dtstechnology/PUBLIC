using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTS.Logic.Layer.DataIO;
using DTS.Logic.Layer.ViewModels;

using DTS.Ear.Library;
using DTS.Ear.Library.Configuration;
using DTS.Ear.Library.Models;
using System.Text.RegularExpressions;
using System.Security.Claims;

namespace DTS.Ear.Controllers
{

    [Authorize]
    [EARLibraryAutohorizeAttribute]
    public class GIBInvoiceController : Controller
    { 
        private readonly ILogger<HomeController> _logger;
        private readonly IEarLibraryLogic _earLibLogic;
        private readonly IUserLogic _userLogic;

        public GIBInvoiceController(ILogger<HomeController> logger, IUserLogic userLogic, IEarLibraryLogic earLibLogic)
        {
            _logger = logger;
            _userLogic = userLogic;
            _earLibLogic = earLibLogic;
        }

        public IActionResult Details(string uuid)
        {
            //FoundDraftInvoiceResponseModel gibfaturalar = new FoundDraftInvoiceResponseModel();
            //dashboardModel.BILL_LIST = billsLogic.GetAllBills();
            //gibfaturalar = _earLibLogic.GetFaturalar(Convert.ToDateTime("01.01.2023"), DateTime.Now, userId, token); 

            //var full = _earLibLogic.getFaturaFul("22993357-6ec9-4bbc-a054-077452eff7fd", userId, token);
            //var edited = _earLibLogic.updateFatura(full.data, userId, token); 
            // "f12f28d2-3944-48cd-8df3-11e460d4bc81"


            //var invtoPerson = _earLibLogic.GetRecipientDataByTaxIDOrTRID(xxxx, userId, token);   
            //var kullaniciBilgileri = _earLibLogic.GetUserData(); 
            //var uuid = "5b64ad6b-6ea1-4187-a9e5-15d8540fda0d";// "6efa304e-7283-4186-9e4d-06a33747a680";  //faturalar.data[7].ettn; //"b7dabd67-4bf4-4114-aedd-0fe2c0f0d2cb"; //
            //var html = _earLibLogic.getFaturaDetailHTML(faturalar.data[7].ettn,userId,token);
            //var incomingInvoices = _earLibLogic.getGelenFaturalarList(Convert.ToDateTime("01.01.2022"), DateTime.Now, userId, token);

            //EarLibraryService.faturaService.GetAllInvoicesByDateRange(Convert.ToDateTime("01.01.2022"), DateTime.Now).GetAwaiter().GetResult();

            //dashboardModel.BILL_LIST = billsLogic.GetAllBills();
            //dashboardModel.DRAFTINVOICE = gibfaturalar;
            //dashboardModel.CRS_LIST = _userLogic.GetAllUsers();
            //dashboardModel.CRS_SET = _userLogic.GetUserSettings(0);

            string userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string token = Request.Cookies["tkn"];

            var viewModel = new W_TGO_INVDETAIL();

            viewModel.INVOICES_HTML = _earLibLogic.getFaturaDetailHTML(uuid, userId, token);

            return View(viewModel);
        }


        public IActionResult GetGIBInvoices(W_TGO_EARDASHBOARD dashboardModel)
        {
            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string token = Request.Cookies["tkn"];
            //var faturalar = _earLibLogic.GetFaturalar(Convert.ToDateTime("01.01.2022"), DateTime.Now, userId, token); 
            //dashboardModel.DRAFTINVOICE = faturalar;
            //dashboardModel.CRS_LIST = userLogic.GetAllUsers(); 

            return View(dashboardModel);
        }

        public IActionResult Create(W_TGO_INVCREATE invoiceModel)
        {
            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //        var name = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            string token = Request.Cookies["tkn"];

             
            /*---------------------------------SMS GONDER---------------------------------*/

            //var sms = _earLibLogic.imzaSMSGonder("5385716774", userId, token);

              

            /*---------------------------------UPDATE DRAFT INVOICE---------------------------------*/

            //var full = _earLibLogic.getFaturaFul("9bc6a547-3dc6-410d-9732-bdc3ff2fbd0f", userId, token); 
            //full.data.not = "NOTE UPDATE TEST 15:12";
            //var edited = _earLibLogic.updateFatura(full.data, userId, token);
             
             

            /*---------------------------------CREATE DRAFT INVOICE---------------------------------*/

            //var draftModel = new InvoiceDetailsModel();
            //draftModel.name = "xxx";
            //draftModel.surname = "xxx";
            //draftModel.title = "NOVUS BOYUTSAL HARF LOGO URUNLERI";
            //draftModel.date = "16/03/2023";
            //draftModel.time = "16:50:05";
            //draftModel.taxIDOrTRID = "xxx";
            //draftModel.taxOffice = "MERAM";
            //draftModel.fullAddress = "xxxx";

            //decimal grndtotal = Convert.ToDecimal(50);
            //decimal ttlvat = Convert.ToDecimal(9);
            //decimal grndtotalincvat = Convert.ToDecimal(59);
            //decimal pmtotal = Convert.ToDecimal(59);

            //draftModel.grandTotal = grndtotal; // matrah
            //draftModel.totalVAT = ttlvat; // hesaplanan kdv
            //draftModel.grandTotalInclVAT = grndtotalincvat; // vergiler dahil toplam tutar
            //draftModel.paymentTotal = pmtotal; // ödenecek tutar

            //decimal kdv = Convert.ToDecimal(9);

            //draftModel.items = new List<InvoiceDetailsItemModel>();
            //draftModel.items.Add(new InvoiceDetailsItemModel
            //{
            //    name = "UZAK BAGLANTI DESTEK HIZMETI",
            //    quantity = 1,
            //    unitPrice = 50,
            //    price = 50,
            //    VATAmount = kdv,
            //    VATRate = 18,

            //});

            //var x = _earLibLogic.createDraftFatura(draftModel, userId, token);

            /*---------------------------------CREATE DRAFT INVOICE---------------------------------*/



            return View();
        }

        public IActionResult VerifySignSMS(string code, string oid)
        {
            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //        var name = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            string token = Request.Cookies["tkn"];


            var full = _earLibLogic.getFaturaFul("ETTN", userId, token);
            //var faturalar = _earLibLogic.GetFaturalar(Convert.ToDateTime("16.03.2023"), DateTime.Now, userId, token);


            //faturalar değişkeninin olması gereken veri yapısı EARŞİV PORTALDAN ALINDI
            //{     
            //     "SIFRE": "A7SS72",
            //     "OID": "23lfb6avca1czs",
            //     "OPR": 1,
            //     "DATA": [
            //         {
            //             "faturaOid": "",
            //             "toplamTutar": "0",
            //             "belgeNumarasi": "XXX",
            //             "aliciVknTckn": "XXX",
            //             "aliciUnvanAdSoyad": "XXX",
            //             "saticiVknTckn": "",
            //             "saticiUnvanAdSoyad": "",
            //             "belgeTarihi": "16-03-2023",
            //             "belgeTuru": "FATURA",
            //             "onayDurumu": "Onaylanmadı",
            //             "ettn": "XXX",
            //             "talepDurumColumn": "----------",
            //             "iptalItiraz": "-99",
            //             "talepDurum": "-99"
            //         }
            //     ]
            // }

            //var onay = _earLibLogic.imzaKODGonder(faturalar, code, oid, userId, token);


            return View();
        }
    }
}

