using Data.Access.Layer.DataContext;
using Data.Access.Layer.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.DataIO.Interfaces
{
    public interface IStocks
    {
        TGO_STCK AddStock(string username, string emailAddress, string password, string authLevelId);

        List<TGO_STCK> GetAllStock();

        List<TGO_STCK_ACTV> GetAllStockActivities();



    }

}
