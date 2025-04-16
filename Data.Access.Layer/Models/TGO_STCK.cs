using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Access.Layer.Models
{
    public partial class TGO_STCK
    {
        [Key]
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
    }
}
