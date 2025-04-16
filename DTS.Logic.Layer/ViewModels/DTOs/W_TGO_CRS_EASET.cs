using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;

namespace DTS.Logic.Layer.ViewModels.DTOs
{
    public class W_TGO_CRS_EASET
    {
        public int EASETID { get; set; }
        public int CRID { get; set; } 
        public string EAU { get; set; }
        public string EAP { get; set; }
        public string EAT { get; set; }

    }
}
