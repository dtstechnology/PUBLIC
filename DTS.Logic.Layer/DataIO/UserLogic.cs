using AutoMapper;
using Data.Access.Layer;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.DataIO.Services;
using Data.Access.Layer.Models;
using DTS.Core.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.DataIO
{
    public class UserLogic : IUserLogic
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IUnitofWork _unitofWork; 

        public UserLogic(IHttpContextAccessor httpContextAccessor, IUnitofWork unitofWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitofWork = unitofWork;
        } 

        public int getUserID()
        { 
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }

        public bool UserRegister(W_TGO_CRS m)//string username, string emailAddress, string password, string authLevelId
        {
            try
            {
                _unitofWork.BeginTransaction();
                var model = Mapping.Mapper.Map<TGO_CRS>(m);
                var result = _unitofWork.Users.Insert(model);

                _unitofWork.Save();

                var acntmdl= new W_TGO_ACNTS();
                acntmdl.CRID = result.CRID;
                acntmdl.NAME  = "kevin";
                acntmdl.SURNAME  = "watson";
                acntmdl.COMPANYNAME  = "";
                acntmdl.PHONE  = "";
                acntmdl.FAX  = "";
                acntmdl.MOBILEPHONE  = "";
                acntmdl.EMAIL  = "";
                acntmdl.WEBADDRESS  = "";
                acntmdl.TAXOFFICE  = "";
                acntmdl.TAXNO  = "";
                acntmdl.COMMERCIALREGISTRYNO  = "";
                acntmdl.COUNTRY  = "";
                acntmdl.CITY  = "";
                acntmdl.ZIPCODE  = "";
                acntmdl.DISTRICT  = "";
                acntmdl.ADDRESS = "";
                acntmdl.ADDRESSDELIVERY = ""; 
                var accountmap = Mapping.Mapper.Map<TGO_ACNTS>(acntmdl); 
                var actresult = _unitofWork.Accounts.Insert(accountmap);
             

                _unitofWork.Commit(); 
                _unitofWork.Rollback();



                var x = _unitofWork.Users.GetAll();
                var y = _unitofWork.Accounts.GetAll();


                if (result.CRID > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }
         
        
        public List<W_TGO_CRS> GetAllUsers()
        {
            var allusers = _unitofWork.Users.GetAll();

            List<TGO_CRS> model = _unitofWork.Users.GetAll().ToList();
            List<W_TGO_CRS> viewModel = new List<W_TGO_CRS>();
            if (model.Count > 0)
            {
                viewModel = Mapping.Mapper.Map<List<W_TGO_CRS>>(model);
            } 
            return viewModel; 
        }
  
        public W_TGO_CRS SelectUserByUserName(string userName)
        {
            TGO_CRS model = _unitofWork.Users.Get(q => q.CRNE == userName);
            W_TGO_CRS viewModel = new W_TGO_CRS();
            viewModel = Mapping.Mapper.Map<W_TGO_CRS>(model);

            return viewModel;

        } 
        public W_TGO_CRS SelectUserByEmail(string eMail)
        {
            TGO_CRS model = _unitofWork.Users.Get(q => q.CREL == eMail);
            W_TGO_CRS viewModel = new W_TGO_CRS();
            viewModel = Mapping.Mapper.Map<W_TGO_CRS>(model);

            return viewModel;

        } 
        public W_TGO_CRS SelectUserByID(int id)
        {
            TGO_CRS model = _unitofWork.Users.Get(q => q.CRID == id);
            W_TGO_CRS viewModel = new W_TGO_CRS();
            viewModel = Mapping.Mapper.Map<W_TGO_CRS>(model);

            return viewModel;
        }
        public W_TGO_CRS_PROFILE GetUserProfile(string id)
        { 
            TGO_CRS_PROFILE model = _unitofWork.UsersProfile.Get(q => q.CRID == Convert.ToInt32(id));
            W_TGO_CRS_PROFILE viewModel = new W_TGO_CRS_PROFILE();
            viewModel = Mapping.Mapper.Map<W_TGO_CRS_PROFILE>(model);

            return viewModel;
        }
        public W_TGO_CRS_EASET GetUserSettings(string id)
        {
            
            TGO_CRS_EASET model = _unitofWork.UsersSetting.Get(q => q.CRID == Convert.ToInt32(id));
            W_TGO_CRS_EASET viewModel = new W_TGO_CRS_EASET();
            viewModel = Mapping.Mapper.Map<W_TGO_CRS_EASET>(model);

            return viewModel;
        }  
        public W_TGO_CRS UserLogin(string userNameorEmail, string password)
        {
            userNameorEmail = userNameorEmail ?? "null";
            W_TGO_CRS viewModel = new W_TGO_CRS();

            if (DTS.Core.Auth.AuthenticationHelpers.IsValidEmail(userNameorEmail))
            {
                TGO_CRS model = _unitofWork.Users.Get(q => q.CREL == userNameorEmail || q.CRNE == userNameorEmail);
                if (model != null)
                {
                    if (model.CRPD == password)
                    {
                        viewModel = Mapping.Mapper.Map<W_TGO_CRS>(model);
                        viewModel.CRPD = null;
                    }
                    else
                    {
                        viewModel = null;
                    }
                }
            }
            else
            {
                TGO_CRS model = _unitofWork.Users.Get(q => q.CREL == userNameorEmail || q.CRNE == userNameorEmail);
                if (model != null)
                {
                    if (model.CRPD == password)
                    {
                        viewModel = Mapping.Mapper.Map<W_TGO_CRS>(model);
                        viewModel.CRPD = null;
                    }
                    else
                    {
                        viewModel = null;
                    }
                }
            }
            return viewModel;


        }

    }
}
