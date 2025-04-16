using System;
using System.Collections.Generic;

#nullable disable

namespace Data.MySQL.MySQLEntities
{
    public partial class tgo_acnts
    {
        public int ACID { get; set; }
        public int CRID { get; set; }
        public string ACTYPE { get; set; }
        public bool ACACT { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string COMPANYNAME { get; set; }
        public string PHONE { get; set; }
        public string FAX { get; set; }
        public string MOBILEPHONE { get; set; }
        public string EMAIL { get; set; }
        public string WEBADDRESS { get; set; }
        public string TAXOFFICE { get; set; }
        public string TAXNO { get; set; }
        public string TCID { get; set; }
        public string COMMERCIALREGISTRYNO { get; set; }
        public string COUNTRY { get; set; }
        public string CITY { get; set; }
        public string ZIPCODE { get; set; }
        public string DISTRICT { get; set; }
        public string ADDRESS { get; set; }
        public string ADDRESSDELIVERY { get; set; }
        public string TCMBCURRENCY { get; set; }
        public string TCMBCURRENCYTYPE { get; set; }
        public decimal RISKLIMIT { get; set; }
        public double VADEFAIZORAN { get; set; }
        public double INDIRIMORAN { get; set; }
        public string KEPADRES { get; set; }
        public string YETKILILIST { get; set; }
        public string BANKALIST { get; set; }
    }
}
