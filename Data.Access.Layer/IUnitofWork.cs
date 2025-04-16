using Data.Access.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer
{
    public interface IUnitofWork : IDisposable
    {
        public void BeginTransaction();
        public void Commit();
        public void Rollback();
        IRepository<TGO_CRS> Users { get; }
        IRepository<TGO_CRS_PROFILE> UsersProfile { get; }
        IRepository<TGO_CRS_EASET> UsersSetting { get; }
        IRepository<TGO_ACNTS> Accounts { get; }
        IRepository<TGO_BLS> Bills { get; }
        IRepository<TGO_STCK> Stock { get; }
        IRepository<TGO_STCK_ACTV> StockActivities { get; }
        void Save();
    }
}
