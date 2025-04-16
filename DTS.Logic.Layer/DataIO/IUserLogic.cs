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
    public interface IUserLogic
    { 
        public int getUserID(); 
        public bool UserRegister(W_TGO_CRS model); 
        public List<W_TGO_CRS> GetAllUsers(); 
        public W_TGO_CRS SelectUserByUserName(string userName); 
        public W_TGO_CRS SelectUserByEmail(string eMail); 
        public W_TGO_CRS SelectUserByID(int id); 
        public W_TGO_CRS_EASET GetUserSettings(string id); 
        public W_TGO_CRS UserLogin(string userNameorEmail, string password);
        

    }
}

 