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
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using DTS.Ear.Library;
using DTS.Ear.Library.Configuration;
using DTS.Ear.Library.Models;
using DTS.Ear.Library.Models.UpdateInvoice;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.ViewModels;

namespace DTS.Logic.Layer.DataIO
{
    public interface IEarLibraryLogic
    {
        public bool Logout(string id, string currentToken); 
        public IFaturaServiceConfiguration setTestConfiguration(string id, string currentToken);
        public IFaturaServiceConfiguration setConfiguration(string id, string currentToken);
        public FaturaService setFaturaService(string id, string currentToken);
        public IFaturaServiceConfiguration GetConfiguration();
        public UserModel GetUserData();
        public GIBResponseModel<RecipientModel> GetRecipientDataByTaxIDOrTRID(long taxid, string id, string token);
        public FoundDraftInvoiceResponseModel GetFaturalar(DateTime x, DateTime y, string id, string token);
        public FullInvoiceResponseModel getFaturaFul(string uuid, string id, string token);
        public GIBResponseModel<string> getFaturaDetailHTML(string uuid, string id, string token);
        public DraftInvoiceResponseModel createDraftFatura(InvoiceDetailsModel draftModel, string id, string token);
        public CreatedInvoiceModel createFatura(InvoiceDetailsModel draftModel, string id, string token);
        public UpdatedInvoiceResponseModel updateFatura(FullInvoiceModel draftModel, string id, string token);
        public SignDraftInvoiceModel imzaFatura(FullInvoiceModel draftModel, string id, string token);
        public SMSCodeResponseModel imzaSMSGonder(string phone, string id, string token);
        public SignDraftInvoiceModel imzaKODGonder(FoundDraftInvoiceResponseModel draftInvoice, string code, string oid, string id, string token);



    }
}