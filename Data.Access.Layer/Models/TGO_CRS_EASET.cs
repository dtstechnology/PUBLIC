using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Data.Access.Layer.Models
{
    public class TGO_CRS_EASET
    {
        [Key]
        public int EASETID { get; set; }
        public int CRID { get; set; } 
        public string EAU { get; set; } //USER
        public string EAP { get; set; } //PASS
        public string EAT { get; set; } //TOKEN
    }
}
