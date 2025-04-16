using Data.Access.Layer;
using Data.Access.Layer.MultipleDBTest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS.Logic.Layer.MultipleDBTest
{
    public class TestDBRouter
    {

        private ConnectionHelper _connectionHelper;
        public TestDBRouter()
        {
            _connectionHelper = new ConnectionHelper(new MsSQLConnection());
        }

        public DbContext GetDb()
        {
            return _connectionHelper.GetDb();
        }



    }
}
