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
    public class Accounts : IAccounts
    {
           
        public TGO_ACNTS AddCustomer(TGO_ACNTS model)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    context.TGO_ACNTS.AddAsync(model);
                    context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                model = null;
            }

            return model;
        }

        public List<TGO_ACNTS> GetAllCustomer()
        {
            List<TGO_ACNTS> customers = new List<TGO_ACNTS>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {

                customers = context.TGO_ACNTS.ToList();
            }
            return customers;
        }
        public TGO_ACNTS SelectCustomerByID(int id)
        {
            TGO_ACNTS customers = new TGO_ACNTS();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customers = context.TGO_ACNTS.FirstOrDefault(f => f.CRID == id);
            }
            return customers;
        }
        public TGO_ACNTS SelectCustomerByCustomerName(string CustomerName)
        {
            TGO_ACNTS customers = new TGO_ACNTS();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customers = context.TGO_ACNTS.FirstOrDefault(f => f.NAME == CustomerName);
            }
            return customers;
        }
        public TGO_ACNTS SelectCustomerByEmail(string CustomerName)
        {
            TGO_ACNTS customers = new TGO_ACNTS();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customers = context.TGO_ACNTS.FirstOrDefault(f => f.EMAIL == CustomerName);
            }
            return customers;
        }
        public virtual List<TGO_ACNTS> WhereTest<T>(Expression<Func<TGO_ACNTS, bool>> predicate)
        {
            var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
            return context.Set<TGO_ACNTS>().Where(predicate).ToList();

        }


        //public void whereTest()
        //{
        //    var model = new List<TGO_ACNTS>();
        //    model = _earCustomer.WhereTest(f => f.CRID == 1 && f.CREL == "dtstechnology@outlook.com");
        //}


        //CONTAINS
        //var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
        //var searchIds = new List<int> { 1, 2, 3, 4, 5 }; 
        //return context.Set<TGO_ACNTS>().Where(p => p.CREL.Any(l => searchIds.Contains(p.CRID))).ToList();






    }
}
