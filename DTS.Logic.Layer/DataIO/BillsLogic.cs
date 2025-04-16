using Autofac.Core;
using AutoMapper;
using Data.Access.Layer;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.DataIO.Services;
using Data.Access.Layer.Models;
using DTS.Core.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.ViewModels;
using DTS.Logic.Layer.ViewModels.DTOs;
using static DTS.Logic.Layer.ViewModels.DTOs.W_TGO_STOCK;

namespace DTS.Logic.Layer.DataIO
{
    public class BillsLogic : IBillsLogic
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IUnitofWork _unitofWork;
        private IStockLogic _stockLogic;

        public BillsLogic(IHttpContextAccessor httpContextAccessor, IUnitofWork unitofWork, IStockLogic stockLogic)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitofWork = unitofWork;
            _stockLogic = stockLogic;
        }

        public int getUserID()
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;

        }
        public List<W_TGO_BILLS> GetAllBills()
        {

            List<TGO_BLS> model = _unitofWork.Bills.Where(f => f.CRID == getUserID()).OrderByDescending(d=>d.BLID).ToList();
            List<W_TGO_BILLS> viewModel = new List<W_TGO_BILLS>();
            if (model.Count > 0)
            {
                viewModel = Mapping.Mapper.Map<List<W_TGO_BILLS>>(model);
            }

            return viewModel;


        }


        public W_TGO_BILLS GetBillDetail(string blid)
        {

            TGO_BLS stockModel = _unitofWork.Bills.Get(f => f.CRID == getUserID() && f.BLID == Convert.ToInt32(blid));

            W_TGO_BILLS viewModel = new W_TGO_BILLS();

            viewModel = Mapping.Mapper.Map<W_TGO_BILLS>(stockModel);

            return viewModel;
        }


        public W_TGO_BILLS_ADD AddBill(W_TGO_BILLS_ADD vm) //string username, string emailAddress, string password, string authLevelId
        {
            try
            {
                _unitofWork.BeginTransaction();
                vm.MALHIZMET_LIST = JsonConvert.DeserializeObject<List<StockMalHizmetTable>>(vm.BILL.MALHIZMET);
                vm.BILL.CRID = getUserID();
                vm.BILL.ACID = vm.ACCOUNT.ACID;
                vm.BILL.BELGENO = "EXTBILL";
                vm.BILL.TIPI = "SATIS";
                vm.BILL.ETTN = "EXTETTN";
                var model = Mapping.Mapper.Map<TGO_BLS>(vm.BILL);
                var resultBill = _unitofWork.Bills.Insert(model);
                //_unitofWork.Save();

                if (vm.BILL.TIPI == "SATIS")
                {
                    foreach (var item in vm.MALHIZMET_LIST)
                    {
                        vm.STOCK_LIST = new W_TGO_STOCK_LIST();
                        vm.STOCK_LIST.STOCK = _stockLogic.GetStockDetail(item.STID).STOCK;
                        vm.STOCK_LIST.STOCK_ACTIVITIES = new W_TGO_STOCK_ACTV();
                        vm.STOCK_LIST.STOCK_ACTIVITIES.ACID = vm.ACCOUNT.ACID;
                        vm.STOCK_LIST.STOCK_ACTIVITIES.ACNAME = vm.ACCOUNT.ACID.ToString();
                        vm.STOCK_LIST.STOCK_ACTIVITIES.TARIH = DateTime.Now;
                        vm.STOCK_LIST.STOCK_ACTIVITIES.ISLEMTURU = "Satış";
                        vm.STOCK_LIST.STOCK_ACTIVITIES.ACIKLAMA = vm.ACCOUNT.ACID + " NOLU MÜŞTERİYE SATIŞ";
                        vm.STOCK_LIST.STOCK_ACTIVITIES.MIKTAR = Convert.ToInt32(item.miktar);
                        _stockLogic.TakeOff(vm.STOCK_LIST); 
                    } 
                    
                } 

                _unitofWork.Commit();

                vm.BILL = Mapping.Mapper.Map<W_TGO_BILLS>(resultBill);
                return vm;
            }
            catch (Exception error)
            {
                return vm;
            }
        }


    }
}
