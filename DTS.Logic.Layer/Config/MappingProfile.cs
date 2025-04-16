using AutoMapper;
using Data.Access.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.AutoMappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        { 
            CreateMap<TGO_CRS, W_TGO_CRS>();
            CreateMap<W_TGO_CRS, TGO_CRS>();
            CreateMap<TGO_CRS_EASET, W_TGO_CRS_EASET>();
            CreateMap<W_TGO_CRS_EASET, TGO_CRS_EASET>();
            CreateMap<TGO_CRS_PROFILE, W_TGO_CRS_PROFILE>();
            CreateMap<W_TGO_CRS_PROFILE, TGO_CRS_PROFILE>();
            CreateMap<TGO_ACNTS, W_TGO_ACNTS>();
            CreateMap<W_TGO_ACNTS, TGO_ACNTS>();
        } 
    }

    public class StockProfile : Profile
    { 
        public StockProfile()
        {  
            CreateMap<W_TGO_STOCK, TGO_STCK>();
            CreateMap<TGO_STCK, W_TGO_STOCK>();

            CreateMap<W_TGO_STOCK_ACTV, TGO_STCK_ACTV>();
            CreateMap<TGO_STCK_ACTV, W_TGO_STOCK_ACTV>();
        } 
    }

    public class BillsProfile : Profile
    {
        public BillsProfile()
        {
            CreateMap<W_TGO_BILLS, TGO_BLS>();
            CreateMap<TGO_BLS, W_TGO_BILLS>();

            
        }
    }

    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<W_TGO_ACNTS, TGO_ACNTS>();
            CreateMap<TGO_ACNTS, W_TGO_ACNTS>();


        }
    }

}
