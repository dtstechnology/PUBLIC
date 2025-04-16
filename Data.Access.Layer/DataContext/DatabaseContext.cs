using Data.Access.Layer.Models; 
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Data.Access.Layer.DataContext
{
    public class DatabaseContext : DbContext //Data.MySQL.MySQLEntities.MySQLContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseMySQL(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;

            }

            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }

        }
         

        public static OptionsBuild ops = new OptionsBuild();
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<TGO_ACNTS> TGO_ACNTS { get; set; }
        public virtual DbSet<TGO_CRS> TGO_CRS { get; set; }
        public virtual DbSet<TGO_CRS_PROFILE> TGO_CRS_PROFILE { get; set; }
        public virtual DbSet<TGO_CRS_EASET> TGO_CRS_EASET { get; set; }
        public virtual DbSet<TGO_BLS> TGO_BLS { get; set; }
        public virtual DbSet<TGO_STCK> TGO_STCK { get; set; }
        public virtual DbSet<TGO_STCK_ACTV> TGO_STCK_ACTV { get; set; }



    }
}
