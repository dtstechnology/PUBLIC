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
using DTS.Logic.Layer.ViewModels;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.DataIO
{
    public interface IBillsLogic 
    { 
        public List<W_TGO_BILLS> GetAllBills();
        public W_TGO_BILLS GetBillDetail(string blid);
        public W_TGO_BILLS_ADD AddBill(W_TGO_BILLS_ADD vm);
    }
}
