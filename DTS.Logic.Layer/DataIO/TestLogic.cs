using AutoMapper;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.DataIO.Services;
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

namespace DTS.Logic.Layer.DataIO
{
    public class TestLogic 
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private AddManager _addmanager = new Data.Access.Layer.DataIO.Services.AddManager();
         
        public TestLogic(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor; 
        }


        public int getUserID()
        {
            UsersTest user = new UsersTest();
            _addmanager.GetAll(user);

            BillsTest bill = new BillsTest();
            _addmanager.GetAll(bill);

            return 0;
        }
 




    }
}
