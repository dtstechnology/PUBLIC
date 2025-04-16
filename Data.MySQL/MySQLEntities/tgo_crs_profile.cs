using System;
using System.Collections.Generic;

#nullable disable

namespace Data.MySQL.MySQLEntities
{
    public partial class tgo_crs_profile
    {
        public int PROFILEID { get; set; }
        public int CRID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string ROLE { get; set; }
        public string PROFILEIMG { get; set; }
    }
}
