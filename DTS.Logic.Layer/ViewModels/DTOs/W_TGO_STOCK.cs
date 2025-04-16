using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;
using DTS.Ear.Library.Models.UpdateInvoice;

namespace DTS.Logic.Layer.ViewModels.DTOs
{
    public class W_TGO_STOCK
    {
        public int STID { get; set; }

        public int ACID { get; set; }
        public int CRID { get; set; }
        public bool TRASH { get; set; }
        public DateTime TARIH { get; set; }
        public string STOKKODU { get; set; }
        public string STOKADI { get; set; }
        public string URUNHIZMETTURU { get; set; }
        public string BARKOD { get; set; }
        public decimal ALISFIYAT { get; set; }
        public decimal SATISFIYAT { get; set; }
        public byte KDVORAN { get; set; }
        public int MIKTAR { get; set; }
        public string BIRIM { get; set; }



        public bool SELECTED { get; set; }
        public string TEST_FILED { get; set; }

        public string STID64
        {
            get
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(STID.ToString()));
            }
        }


        public partial class StockMalHizmetTable
        {
            public string STID { get; set; }
            public string malHizmet { get; set; }
            public decimal miktar { get; set; }
            public string birim { get; set; }

            [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
            public decimal birimFiyat { get; set; }

            [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
            public decimal fiyat { get; set; }

            public decimal iskontoOrani { get; set; }
            public decimal iskontoTutari { get; set; }
            public string iskontoNedeni { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
            public decimal malHizmetTutari { get; set; }
            public decimal kdvOrani { get; set; }
            public int vergiOrani { get; set; } = 0;
            [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
            public decimal kdvTutari { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
            public string vergininKdvTutari { get; set; } = "0";
            public decimal ozelMatrahTutari { get; set; }
            public string hesaplananotvtevkifatakatkisi { get; set; } = "0";


        }
    }
}
