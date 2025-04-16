using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 

namespace Data.Access.Layer.DataContext
{
    public class DatabaseContextFactory: IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            opsBuilder.UseMySQL(appConfig.sqlConnectionString);
            return new DatabaseContext(opsBuilder.Options);


        }

        //DTS
        //public void createFactoryTest()
        //{
        //    DatabaseContextFactory asd = new DatabaseContextFactory();

        //    var x = asd.CreateDbContext(null);
        //    var xx = x.TGO_CRS.FirstOrDefault(f => f.CRID == 1);

        //}

    }
}
