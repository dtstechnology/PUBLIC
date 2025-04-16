using System.Collections.Generic;
using DTS.Ear.Library.Models;
using DTS.Ear.Library.Models.UpdateInvoice;
using DTS.Logic.Layer.ViewModels.DTOs;
using static DTS.Logic.Layer.ViewModels.DTOs.W_TGO_STOCK;

namespace DTS.Logic.Layer.ViewModels
{
    public class W_TGO_BILLS_ADD : ViewModelBase
    {
        public W_TGO_ACNTS ACCOUNT { get; set; }
        public List<W_TGO_ACNTS> ACCOUNT_LIST { get; set; }

        public W_TGO_STOCK_LIST STOCK_LIST { get; set; }
        
        //public W_TGO_STOCK STOCK { get; set; }
        //public List<W_TGO_STOCK> STOCK_LIST { get; set; }
        public W_TGO_BILLS BILL { get; set; }
        public List<W_TGO_BILLS> BILL_LIST { get; set; }
        public StockMalHizmetTable MALHIZMET { get; set; }
        public List<StockMalHizmetTable> MALHIZMET_LIST { get; set; }

    }
}