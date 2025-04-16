using Data.Access.Layer.DataContext;
using Data.Access.Layer.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer
{
    public class UnitofWork : IUnitofWork
    {
        IDbContextTransaction _transaction = null;
        private readonly DatabaseContext _context;
        private IRepository<TGO_CRS> _users;
        private IRepository<TGO_CRS_PROFILE> _usersProfile;
        private IRepository<TGO_CRS_EASET> _usersSetting;
        private IRepository<TGO_ACNTS> _accounts;
        private IRepository<TGO_BLS> _bills;
        private IRepository<TGO_STCK> _stock;
        private IRepository<TGO_STCK_ACTV> _stockActivities;
        public UnitofWork(DatabaseContext context)
        {
            _context = context;

        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public IRepository<TGO_CRS> Users => _users ??= new GenericRepository<TGO_CRS>(_context);
        public IRepository<TGO_CRS_PROFILE> UsersProfile => _usersProfile ??= new GenericRepository<TGO_CRS_PROFILE>(_context);
        public IRepository<TGO_CRS_EASET> UsersSetting => _usersSetting ??= new GenericRepository<TGO_CRS_EASET>(_context);
        public IRepository<TGO_ACNTS> Accounts => _accounts ??= new GenericRepository<TGO_ACNTS>(_context);
        public IRepository<TGO_BLS> Bills => _bills ??= new GenericRepository<TGO_BLS>(_context);
        public IRepository<TGO_STCK> Stock => _stock ??= new GenericRepository<TGO_STCK>(_context);
        public IRepository<TGO_STCK_ACTV> StockActivities => _stockActivities ??= new GenericRepository<TGO_STCK_ACTV>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }



    }
}
