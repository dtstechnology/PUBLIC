using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.MySQL.MySQLEntities
{
    public partial class MySQLEntities : DbContext
    {
        public MySQLEntities()
        {
        }

        public MySQLEntities(DbContextOptions<MySQLEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<tgo_acnts> tgo_acnts { get; set; }
        public virtual DbSet<tgo_bls> tgo_bls { get; set; }
        public virtual DbSet<tgo_crs> tgo_crs { get; set; }
        public virtual DbSet<tgo_crs_easet> tgo_crs_easet { get; set; }
        public virtual DbSet<tgo_crs_profile> tgo_crs_profile { get; set; }
        public virtual DbSet<tgo_stck> tgo_stck { get; set; }
        public virtual DbSet<tgo_stck_actv> tgo_stck_actv { get; set; }

          
    }
}
