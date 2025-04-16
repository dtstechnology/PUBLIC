using AutoMapper;
using Data.Access.Layer;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.DataIO
{

    public class AccountsLogic : IAccountsLogic
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IUnitofWork _unitofWork;

        public AccountsLogic(IHttpContextAccessor httpContextAccessor, IUnitofWork unitofWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitofWork = unitofWork;
        }

        public int getUserID()
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
  
        public W_TGO_ACNTS AddCustomer(W_TGO_ACNTS vm)  
        {
            try
            { 
                vm.CRID = getUserID();
                //vm.TARIH = DateTime.Now; //TODO ACCOUNTS KAYIT TARIHI EKLENECEK
                var model = Mapping.Mapper.Map<TGO_ACNTS>(vm);
                var resultAccount = _unitofWork.Accounts.Insert(model);
                _unitofWork.Save();
                  

                vm = Mapping.Mapper.Map<W_TGO_ACNTS>(resultAccount);
                return vm;
            }
            catch (Exception error)
            {
                return vm;
            }
        }



        public List<W_TGO_ACNTS> GetAllAccounts()
        {
            List<TGO_ACNTS> model = _unitofWork.Accounts.Where(f => f.CRID == getUserID()).ToList();
            List<W_TGO_ACNTS> viewModel = new List<W_TGO_ACNTS>();
            if (model.Count > 0)
            {
                viewModel = Mapping.Mapper.Map<List<W_TGO_ACNTS>>(model);
            }

            return viewModel;

        }


        public W_TGO_ACNTS SelectCustomerByCustomerName(string AccountsName)
        {
            TGO_ACNTS model = _unitofWork.Accounts.Get(f=>f.COMPANYNAME == AccountsName);
            W_TGO_ACNTS viewModel = new W_TGO_ACNTS();
            viewModel = Mapping.Mapper.Map<W_TGO_ACNTS>(model);

            return viewModel;

        }

        public W_TGO_ACNTS SelectCustomerByEmail(string eMail)
        {
            TGO_ACNTS model = _unitofWork.Accounts.Get(f => f.EMAIL == eMail);
            W_TGO_ACNTS viewModel = new W_TGO_ACNTS();
            viewModel = Mapping.Mapper.Map<W_TGO_ACNTS>(model);

            return viewModel;

        }

        public W_TGO_ACNTS SelectCustomerByID(int id)
        {
            TGO_ACNTS model = _unitofWork.Accounts.Get(f => f.ACID == id);
            W_TGO_ACNTS viewModel = new W_TGO_ACNTS();
            viewModel = Mapping.Mapper.Map<W_TGO_ACNTS>(model);

            return viewModel;
        }




    }
}
