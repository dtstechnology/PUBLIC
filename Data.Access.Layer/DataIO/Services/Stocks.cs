using Data.Access.Layer.DataContext;
using Data.Access.Layer.DataIO.Interfaces;
using Data.Access.Layer.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.DataIO.Services
{
    public class Stocks : IStocks
    {
        public TGO_STCK AddStock(string username, string emailAddress, string password, string authLevelId)
        {

            TGO_STCK newStock = new TGO_STCK
            {
                
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                context.TGO_STCK.AddAsync(newStock);
                context.SaveChangesAsync();
            }
            return newStock;
        }

        public List<TGO_STCK> GetAllStock()
        {
            List<TGO_STCK> customer = new List<TGO_STCK>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customer = context.TGO_STCK.ToList();
            }
            return customer;
        }
        public List<TGO_STCK_ACTV> GetAllStockActivities()
        {
            List<TGO_STCK_ACTV> customer = new List<TGO_STCK_ACTV>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customer = context.TGO_STCK_ACTV.ToList();
            }
            return customer;
        }




    }
}
