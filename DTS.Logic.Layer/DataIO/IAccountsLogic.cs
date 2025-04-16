using AutoMapper;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.Models;
using DTS.Core.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using DTS.Logic.Layer.AutoMappers;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.DataIO
{
    public interface IAccountsLogic
    { 
        public int getUserID();
         
        public W_TGO_ACNTS AddCustomer(W_TGO_ACNTS vm);
        public List<W_TGO_ACNTS> GetAllAccounts(); 
        public W_TGO_ACNTS SelectCustomerByCustomerName(string AccountsName); 
        public W_TGO_ACNTS SelectCustomerByEmail(string eMail);
        public W_TGO_ACNTS SelectCustomerByID(int id);

    }
}

 