using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.ViewModels
{
    public class W_TGO_STOCK_ACTV_LIST
    { 
        public W_TGO_STOCK_ACTV STOCK_ACTV { get; set; }
        public List<W_TGO_STOCK_ACTV> STOCK_ACTV_LIST { get; set; }
    }
}
