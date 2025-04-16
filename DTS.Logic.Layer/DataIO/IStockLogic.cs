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
    public interface IStockLogic
    {
        public int getUserID();
        public W_TGO_STOCK AddStock(W_TGO_STOCK vm);
        public W_TGO_STOCK_LIST GetStockDetail(string stid);
        public List<W_TGO_STOCK> GetAllStock();
        public List<W_TGO_STOCK> GetAllRecycleBinStock();
        public List<W_TGO_STOCK_ACTV> GetAllStockActivities();
        public List<W_TGO_STOCK_ACTV> GetStockActivities(string stid);
        public W_TGO_STOCK_ACTV GetStockActivity(string stactid);
        public bool MovetoTrash_Stock(string[] ints);
        public bool MovetoTrash_StockActivities(string[] ints);
        public W_TGO_STOCK_LIST TakeOff(W_TGO_STOCK_LIST vm);
        public W_TGO_STOCK_LIST TakeOn(W_TGO_STOCK_LIST vm);


    }
}
