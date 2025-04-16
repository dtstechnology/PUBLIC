using System;
using System.Collections.Generic;

#nullable disable

namespace Data.MySQL.MySQLEntities
{
    public partial class tgo_crs_easet
    {
        public int EASETID { get; set; }
        public int CRID { get; set; }
        public string EAU { get; set; }
        public string EAP { get; set; }
        public string EAT { get; set; }
    }
}
