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
using System.Transactions;

namespace Data.Access.Layer.DataIO.Services
{
    public class Users : IUsers
    {
        public TGO_CRS AddUser(string username, string emailAddress, string password, string authLevelId)
        {
            

            TGO_CRS newCustomer = new TGO_CRS
            {
                CRNE = username,
                CRPD = password
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                //using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                //{
                //    // Do something 
                //    context.SaveChanges();
                //    // Do something else
                //    context.SaveChanges(); 
                //    scope.Complete();
                //} 
                context.TGO_CRS.AddAsync(newCustomer);
                context.SaveChangesAsync();
            }
            return newCustomer;
        }

        public List<TGO_CRS> GetAllUser()
        {
            List<TGO_CRS> customer = new List<TGO_CRS>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customer = context.TGO_CRS.ToList();
            }
            return customer;
        }
        public TGO_CRS_EASET GetUserSettings(int id)
        {
            TGO_CRS_EASET customerSettings = new TGO_CRS_EASET();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customerSettings = context.TGO_CRS_EASET.FirstOrDefault(f => f.CRID == id);
            }
            return customerSettings;
        }
         
         
        public TGO_CRS SelectUserByID(int id)
        {
            TGO_CRS customers = new TGO_CRS();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customers = context.TGO_CRS.FirstOrDefault(f => f.CRID == id);
            }
            return customers;
        }
        public TGO_CRS SelectUserByUserName(string userName)
        {
            TGO_CRS customers = new TGO_CRS();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customers = context.TGO_CRS.FirstOrDefault(f => f.CRNE == userName);
            }
            return customers;
        }


        public TGO_CRS SelectUserByEmail(string eMail)
        {
            TGO_CRS customers = new TGO_CRS();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                customers = context.TGO_CRS.FirstOrDefault(f => f.CREL == eMail);
            }
            return customers;
        }

        public virtual List<TGO_CRS> WhereTest<T>(Expression<Func<TGO_CRS, bool>> predicate)
        {
            var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
            return context.Set<TGO_CRS>().Where(predicate).ToList();

        }


        //public void whereTest()
        //{
        //    var model = new List<TGO_CRS>();
        //    model = _earCustomer.WhereTest(f => f.CRID == 1 && f.CREL == "dtstechnology@outlook.com");
        //}


        //CONTAINS
        //var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
        //var searchIds = new List<int> { 1, 2, 3, 4, 5 }; 
        //return context.Set<TGO_CRS>().Where(p => p.CREL.Any(l => searchIds.Contains(p.CRID))).ToList();






    }
}
