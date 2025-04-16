using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.MultipleDBTest
{
    public class ConnectionHelper
    {
        private IConnection _connection;
        public ConnectionHelper(IConnection connection)
        {
            _connection = connection;
        }
        public DbContext GetDb()
        {
            return _connection.GetDb();
        }
    }
}
