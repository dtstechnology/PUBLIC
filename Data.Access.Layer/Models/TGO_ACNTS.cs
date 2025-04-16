using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Models
{
    public class TGO_ACNTS
    {
        [Key]
        public int ACID { get; set; }
        public int CRID { get; set; }
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
        public string COMMERCIALREGISTRYNO { get; set; }
        public string COUNTRY { get; set; }
        public string CITY { get; set; }
        public string ZIPCODE { get; set; }
        public string DISTRICT { get; set; }
        public string ADDRESS { get; set; }
        public string ADDRESSDELIVERY { get; set; }
    }
}
