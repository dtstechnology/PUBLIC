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
    public class W_TGO_INVCREATE
    {

        public W_TGO_CRS CRS { get; set; }
        public List<W_TGO_CRS> CRS_LIST { get; set; }
        public InvoiceDetailsModel INVOICE_MODEL { get; set;} 
        public InvoiceDetailsItemModel ITEM_MODEL { get; set; }

    }
}
