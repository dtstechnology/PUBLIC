using AutoMapper;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.Models;
using DTS.Core.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DTS.Ear.Library;
using DTS.Ear.Library.Configuration;
using DTS.Ear.Library.Models;
using DTS.Ear.Library.Models.UpdateInvoice;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.DataIO
{
    public class EarLibraryLogic : IEarLibraryLogic
    {
        public FaturaService faturaService;
        public IFaturaServiceConfiguration configuration;

        private readonly IUserLogic _userLogic;
        private readonly IHttpContextAccessor _httpContextAccessor;
         
        public EarLibraryLogic(IHttpContextAccessor httpContextAccessor, IUserLogic userLogic)
        {
            _httpContextAccessor = httpContextAccessor;
            _userLogic = userLogic;
        }
 
        //public bool PresetOK(W_TGO_CRS_SET settings)
        //{
        //    if (configuration == null)
        //    {
        //        configuration = FaturaServiceConfigurationFactory.Create();
        //    }
        //    configuration.ServiceType = ServiceType.Prod;
        //    configuration.Username = settings.EARID;
        //    configuration.Password = settings.EARPD; //User.Claims.FirstOrDefault(c => c.Type == "earpd").Value;
        //    faturaService = new(configuration);
        //    if (configuration.Token == null)
        //    {
        //        faturaService.GetToken().Wait();
        //    }
        //    return true;
        //}
        public bool Logout(string id, string currentToken)
        {
            try
            {
                faturaService = setFaturaService(id, currentToken);
                faturaService = new(configuration);
                faturaService.Logout().Wait();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }


        public IFaturaServiceConfiguration setTestConfiguration(string id, string currentToken)
        {
            configuration = FaturaServiceConfigurationFactory.Create();

            configuration.ServiceType = ServiceType.Test;


            if (string.IsNullOrEmpty(currentToken))
            {
                faturaService = new(configuration);
                var testUser = faturaService.GetTestUserID().GetAwaiter().GetResult();
                configuration.Username = testUser.userid;
                configuration.Password = "1"; //User.Claims.FirstOrDefault(c => c.Type == "earpd").Value;

                if (configuration.Token == null)
                {
                    faturaService.GetToken().Wait();
                }
            }
            else
            {
                configuration.Token = currentToken;
            }

            return configuration;
        }


        public IFaturaServiceConfiguration setConfiguration(string id, string currentToken)
        {

            configuration = FaturaServiceConfigurationFactory.Create();
            configuration.ServiceType = ServiceType.Prod;
            W_TGO_CRS_EASET crsSettings = _userLogic.GetUserSettings(id);
            configuration.Username = crsSettings.EAU;
            configuration.Password = crsSettings.EAP; //User.Claims.FirstOrDefault(c => c.Type == "earpd").Value;
            if (string.IsNullOrEmpty(currentToken))
            {
                faturaService = new(configuration);

                if (configuration.Token == null)
                {
                    faturaService.GetToken().Wait();
                }
            }
            else
            {
                configuration.Token = currentToken;
            }

            return configuration;
        }


        public FaturaService setFaturaService(string id, string currentToken)
        {
            var configuration = setConfiguration(id, currentToken);
            //var configuration = setTestConfiguration(id, currentToken);  //TESTPORTAL
            faturaService = new(configuration);
            return faturaService;
        }

        public IFaturaServiceConfiguration GetConfiguration()
        {
            return configuration;
        }

        public UserModel GetUserData()
        {

            //faturaService = new FaturaService(configuration);

            //TODO: FATURA SERVİS NULL GELİYOR ÇÜNKÜ "EARLibraryAutohorizeAttribute" SADECE SAYFA YÜKLENİRKEN ÇALIŞIYOR 
            //TODO: User.Claims.NAME BURADAN ÇEKEMİYORUZ BU SORUNU ÇÖZMELİSİN !!!

            var response = faturaService.GetUserData().GetAwaiter().GetResult();
            return response;
        }
        public GIBResponseModel<RecipientModel> GetRecipientDataByTaxIDOrTRID(long taxid, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.GetRecipientDataByTaxIDOrTRID(taxid).GetAwaiter().GetResult();
            return response;
        }

        public FoundDraftInvoiceResponseModel GetFaturalar(DateTime x, DateTime y, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.GetAllInvoicesByDateRange(x, y).GetAwaiter().GetResult();
            return response;
        }

        public FullInvoiceResponseModel getFaturaFul(string uuid, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.GetInvFul(uuid).GetAwaiter().GetResult();
            return response;
        }


        public GIBResponseModel<string> getFaturaDetailHTML(string uuid, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.GetInvoiceHTML(uuid).GetAwaiter().GetResult();
            return response;
        }

        public DraftInvoiceResponseModel createDraftFatura(InvoiceDetailsModel draftModel, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.CreateDraftInvoice(draftModel).GetAwaiter().GetResult();
            return response;
        }

        public CreatedInvoiceModel createFatura(InvoiceDetailsModel draftModel, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.CreateInvoice(draftModel, false).GetAwaiter().GetResult();
            return response;
        }

        public UpdatedInvoiceResponseModel updateFatura(FullInvoiceModel draftModel, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.UpdateInvoice(draftModel, false).GetAwaiter().GetResult();
            return response;

        }

        public SignDraftInvoiceModel imzaFatura(FullInvoiceModel draftModel, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.SignDraftInvoice(draftModel).GetAwaiter().GetResult();


            return response;

        }

        public SMSCodeResponseModel imzaSMSGonder(string phone, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var telefon = faturaService.telefonNoSorgula().GetAwaiter().GetResult();
            var response = faturaService.SendSignSMSCode(phone).GetAwaiter().GetResult();

            return response.data;

        }


        public SignDraftInvoiceModel imzaKODGonder(FoundDraftInvoiceResponseModel draftInvoice, string code, string oid, string id, string token)
        {
            faturaService = setFaturaService((id), token);
            var response = faturaService.VerifySignSMSCode(draftInvoice, code, oid).GetAwaiter().GetResult();


            return null;

        }
    }
}
