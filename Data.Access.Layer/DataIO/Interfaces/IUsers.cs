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
    public interface IUsers 
    {
        TGO_CRS AddUser(string username, string emailAddress, string password, string authLevelId);

        List<TGO_CRS> GetAllUser();

        TGO_CRS_EASET GetUserSettings(int id);

        TGO_CRS SelectUserByID(int id);

        TGO_CRS SelectUserByUserName(string userName);

        TGO_CRS SelectUserByEmail(string eMail);

        List<TGO_CRS> WhereTest<T>(Expression<Func<TGO_CRS, bool>> predicate);



    }

}
