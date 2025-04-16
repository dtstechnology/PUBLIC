using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.MultipleDBTest
{
    public class ConnectionFactory
    {
        public static IConnection GetCon()
        {
            return new MySQLConnection();
        }
    }
}
