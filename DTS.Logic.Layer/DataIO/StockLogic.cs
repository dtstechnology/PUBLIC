using AutoMapper;
using Data.Access.Layer;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.Models;
using DTS.Core.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.ViewModels;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.DataIO
{
    public class StockLogic : IStockLogic
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IUnitofWork _unitofWork;

        public StockLogic(IHttpContextAccessor httpContextAccessor, IUnitofWork unitofWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitofWork = unitofWork;
        }

        public int getUserID()
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
        public W_TGO_STOCK AddStock(W_TGO_STOCK vm) //string username, string emailAddress, string password, string authLevelId
        {
            try
            {
                _unitofWork.BeginTransaction();
                vm.CRID = getUserID();
                vm.TARIH = DateTime.Now;
                var model = Mapping.Mapper.Map<TGO_STCK>(vm);
                var resultStock = _unitofWork.Stock.Insert(model);
                _unitofWork.Save();


                TGO_STCK_ACTV activitiesModel = new TGO_STCK_ACTV();
                activitiesModel.ACNAME = "Stok";
                activitiesModel.ACIKLAMA = "Yeni Stok Kaydı Oluşturuldu";
                activitiesModel.ISLEMTURU = "Yeni Stok Açılış";
                activitiesModel.MIKTAR = resultStock.MIKTAR;
                activitiesModel.CRID = getUserID();
                activitiesModel.STID = resultStock.STID;
                activitiesModel.TARIH = DateTime.Now;
                var resultActivities = _unitofWork.StockActivities.Insert(activitiesModel);
                _unitofWork.Commit();

                vm = Mapping.Mapper.Map<W_TGO_STOCK>(resultStock);
                return vm;
            }
            catch (Exception error)
            {
                return vm;
            }
        }

        public List<W_TGO_STOCK> GetAllStock()
        {
            List<TGO_STCK> model = _unitofWork.Stock.Where(f => f.CRID == getUserID() && f.TRASH == false).ToList();
            List<W_TGO_STOCK> viewModel = new List<W_TGO_STOCK>();
            if (model.Count > 0)
            {
                viewModel = Mapping.Mapper.Map<List<W_TGO_STOCK>>(model);
            }

            return viewModel;

        }



        public W_TGO_STOCK_LIST GetStockDetail(string stid)
        {
            W_TGO_STOCK_LIST viewModel = new W_TGO_STOCK_LIST();

            TGO_STCK stockModel = _unitofWork.Stock.Get(f => f.CRID == getUserID() && f.TRASH == false && f.STID == Convert.ToInt32(stid));
            viewModel.STOCK = Mapping.Mapper.Map<W_TGO_STOCK>(stockModel);

            //List<TGO_STCK_ACTV> stockActivitiesModel = _unitofWork.StockActivities.Where(f => f.CRID == getUserID() && f.STID == Convert.ToInt32(stid)).ToList();
            //viewModel.STOCK_ACTIVITIES_LIST = Mapping.Mapper.Map<List<W_TGO_STOCK_ACTV>>(stockActivitiesModel);

            return viewModel;

        }


        public List<W_TGO_STOCK> GetAllRecycleBinStock()
        {
            List<TGO_STCK> model = _unitofWork.Stock.Where(f => f.CRID == getUserID() && f.TRASH == true).ToList();
            List<W_TGO_STOCK> viewModel = new List<W_TGO_STOCK>();
            if (model.Count > 0)
            {
                viewModel = Mapping.Mapper.Map<List<W_TGO_STOCK>>(model);
            }

            return viewModel;

        }


        public List<W_TGO_STOCK_ACTV> GetAllStockActivities()
        {
            List<TGO_STCK_ACTV> model = _unitofWork.StockActivities.Where(f => f.CRID == getUserID()).ToList();
            List<W_TGO_STOCK_ACTV> viewModel = new List<W_TGO_STOCK_ACTV>();
            if (model.Count > 0)
            {
                viewModel = Mapping.Mapper.Map<List<W_TGO_STOCK_ACTV>>(model);
            }

            return viewModel;

        }


        public List<W_TGO_STOCK_ACTV> GetStockActivities(string stid)
        {
            List<TGO_STCK_ACTV> model = _unitofWork.StockActivities.Where(f => f.CRID == getUserID() && f.STID == Convert.ToInt32(stid) && f.TRASH == false).OrderByDescending(o=>o.STACTID).ToList();
            List<W_TGO_STOCK_ACTV> viewModel = new List<W_TGO_STOCK_ACTV>();
            if (model.Count > 0)
            {
                viewModel = Mapping.Mapper.Map<List<W_TGO_STOCK_ACTV>>(model);
            }

            return viewModel;

        }

        public W_TGO_STOCK_ACTV GetStockActivity(string stactid)
        {
            TGO_STCK_ACTV model = _unitofWork.StockActivities.Get(f => f.CRID == getUserID() && f.STACTID == Convert.ToInt32(stactid) && f.TRASH == false);
            W_TGO_STOCK_ACTV viewModel = new W_TGO_STOCK_ACTV();
            if (model != null)
            {
                viewModel = Mapping.Mapper.Map<W_TGO_STOCK_ACTV>(model);
            }

            return viewModel;

        }


        public bool MovetoTrash_Stock(string[] ints)
        {
            try
            {
                if (ints.Count() == 0)
                {
                    return false;
                }
                int[] numbers = new int[ints.Length];

                for (int i = 0; i < ints.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(Encoding.UTF8.GetString(Convert.FromBase64String(ints[i])));
                }

                var friends = _unitofWork.Stock.Where(f => f.CRID == getUserID() && numbers.Contains(f.STID)).ToList();

                if (friends.Count > 0)
                {
                    friends.ForEach(a =>
                    {
                        a.TRASH = true;
                    });

                    _unitofWork.Save();
                }
            }
            catch (Exception)
            {
                _unitofWork.Rollback();
                return false;

            }
            return true;
        }


        public bool MovetoTrash_StockActivities(string[] ints)
        {
            try
            {
                if (ints.Count() == 0)
                {
                    return false;
                }
                int[] numbers = new int[ints.Length];

                for (int i = 0; i < ints.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(Encoding.UTF8.GetString(Convert.FromBase64String(ints[i])));
                }

                var friends = _unitofWork.StockActivities.Where(f => f.CRID == getUserID() && numbers.Contains(f.STACTID)).ToList();

                if (friends.Count > 0)
                {
                    friends.ForEach(a =>
                    {
                        a.TRASH = true;
                    });

                    _unitofWork.Save();
                }
            }
            catch (Exception)
            {
                _unitofWork.Rollback();
                return false;

            }
            return true;
        }

        public W_TGO_STOCK_LIST TakeOff(W_TGO_STOCK_LIST vm) //string username, string emailAddress, string password, string authLevelId
        {
            //DateTime dt = DateTime.ParseExact(vm.STOCK_ACTIVITIES.TARIH.ToShortDateString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //vm.STOCK_ACTIVITIES.TARIH = dt.Add(DateTime.Now.TimeOfDay);
            vm.STOCK_ACTIVITIES.CRID = getUserID();
            vm.STOCK_ACTIVITIES.STID = vm.STOCK.STID;
            vm.STOCK_ACTIVITIES.MIKTAR = -vm.STOCK_ACTIVITIES.MIKTAR;
            //vm.STOCK_ACTIVITIES.ACID = 0;
            vm.STOCK_ACTIVITIES.ACNAME = vm.STOCK_ACTIVITIES.ACID == 0 ? "Stok" : vm.STOCK_ACTIVITIES.ACNAME;
            vm.STOCK_ACTIVITIES.ISLEMTURU = vm.STOCK_ACTIVITIES.ACID == 0 ? "Stok Çıkış" : vm.STOCK_ACTIVITIES.ISLEMTURU;

            try
            {
                var stockModel = _unitofWork.Stock.Get(f => f.CRID == getUserID() && f.STID == vm.STOCK.STID && f.TRASH == false); //Mapping.Mapper.Map<TGO_STCK>(vm.STOCK);
                //if (vm.STOCK_ACTIVITIES.MIKTAR + stockModel.MIKTAR < 0)
                //{
                //    vm.RESULT_MESSAGE = "Minimum stok miktarı 0'dan küçük olamaz";
                //    vm.RESULT = false;
                //    return vm;
                //}

                var stockActivityModel = Mapping.Mapper.Map<TGO_STCK_ACTV>(vm.STOCK_ACTIVITIES);
                var r = _unitofWork.StockActivities.Insert(stockActivityModel);

                stockModel.MIKTAR = stockModel.MIKTAR + vm.STOCK_ACTIVITIES.MIKTAR;
                var r2 = _unitofWork.Stock.Update(stockModel);

                _unitofWork.Save();

                vm.STOCK = Mapping.Mapper.Map<W_TGO_STOCK>(r2);
                vm.STOCK_ACTIVITIES = Mapping.Mapper.Map<W_TGO_STOCK_ACTV>(r);

                if (vm.STOCK_ACTIVITIES.STACTID != 0)
                {
                    vm.RESULT_MESSAGE = vm.STOCK_ACTIVITIES.MIKTAR + " adet stok çıkış işlemi başarılı.";
                    vm.RESULT = true;
                }

                return vm;
            }
            catch (Exception error)
            {
                vm.RESULT_MESSAGE = "Hata !";
                vm.RESULT = true;
                return vm;
            }
        }


        public W_TGO_STOCK_LIST TakeOn(W_TGO_STOCK_LIST vm) //string username, string emailAddress, string password, string authLevelId
        {
            //DateTime dt = DateTime.ParseExact(vm.STOCK_ACTIVITIES.TARIH.ToShortDateString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //vm.STOCK_ACTIVITIES.TARIH = dt.Add(DateTime.Now.TimeOfDay);
            vm.STOCK_ACTIVITIES.CRID = getUserID();
            vm.STOCK_ACTIVITIES.STID = vm.STOCK.STID;
            vm.STOCK_ACTIVITIES.ACID = 0;
            vm.STOCK_ACTIVITIES.ACNAME = "Stok";
            vm.STOCK_ACTIVITIES.ISLEMTURU = "Stok Giriş";

            try
            {
                var stockModel = _unitofWork.Stock.Get(f => f.CRID == getUserID() && f.STID == vm.STOCK.STID && f.TRASH == false); //Mapping.Mapper.Map<TGO_STCK>(vm.STOCK);

                var stockActivityModel = Mapping.Mapper.Map<TGO_STCK_ACTV>(vm.STOCK_ACTIVITIES);
                var r = _unitofWork.StockActivities.Insert(stockActivityModel);

                stockModel.MIKTAR = stockModel.MIKTAR + vm.STOCK_ACTIVITIES.MIKTAR;
                var r2 = _unitofWork.Stock.Update(stockModel);

                _unitofWork.Save();

                vm.STOCK = Mapping.Mapper.Map<W_TGO_STOCK>(r2);
                vm.STOCK_ACTIVITIES = Mapping.Mapper.Map<W_TGO_STOCK_ACTV>(r);

                if (vm.STOCK_ACTIVITIES.STACTID != 0)
                {
                    vm.RESULT_MESSAGE = vm.STOCK_ACTIVITIES.MIKTAR + " adet stok giriş işlemi başarılı.";
                    vm.RESULT = true;
                }

                return vm;
            }
            catch (Exception error)
            {
                vm.RESULT_MESSAGE = "Hata !";
                vm.RESULT = true;
                return vm;
            }
        }


    }
}
