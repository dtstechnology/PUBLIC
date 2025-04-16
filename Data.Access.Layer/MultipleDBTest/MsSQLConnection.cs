using Data.Access.Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.MultipleDBTest
{
    public class MsSQLConnection : IConnection
    {
        public DbContext GetDb()
        {
            return new DatabaseContext(DatabaseContext.ops.dbOptions);
        }
    }
}
