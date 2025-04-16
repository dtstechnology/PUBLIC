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
    public interface IAccounts 
    {
        TGO_ACNTS AddCustomer(TGO_ACNTS model);
        List<TGO_ACNTS> GetAllCustomer();

        TGO_ACNTS SelectCustomerByID(int id);

        TGO_ACNTS SelectCustomerByCustomerName(string CustomerName);

        TGO_ACNTS SelectCustomerByEmail(string eMail);

        List<TGO_ACNTS> WhereTest<T>(Expression<Func<TGO_ACNTS, bool>> predicate);



    }

}
