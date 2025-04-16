using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.Models
{
    public class TGO_CRS_PROFILE
    {
        [Key]
        public int PROFILEID { get; set; }
        public int CRID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string ROLE { get; set; }
        public string PROFILEIMG { get; set; }

    }
}
