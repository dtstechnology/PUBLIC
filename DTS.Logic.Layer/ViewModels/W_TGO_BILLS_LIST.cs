using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;
using DTS.Ear.Library.Models.UpdateInvoice;
using DTS.Logic.Layer.ViewModels.DTOs;
using static DTS.Logic.Layer.ViewModels.DTOs.W_TGO_STOCK;

namespace DTS.Logic.Layer.ViewModels
{
    public class W_TGO_BILLS_LIST
    {
        public W_TGO_BILLS BILL { get; set; }
        public List<W_TGO_BILLS> BILL_LIST { get; set; }
        public List<StockMalHizmetTable> malHizmetList { get; set; }
    }
}