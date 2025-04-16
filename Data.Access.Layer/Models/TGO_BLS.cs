using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Access.Layer.Models
{
    public partial class TGO_BLS
    {
        [Key]
        public int BLID { get; set; }
        public int ACID { get; set; }
        public int CRID { get; set; }
        public string ETTN { get; set; }
        public string BELGENO { get; set; }
        public DateTime TARIH { get; set; }
        public TimeSpan SAAT { get; set; }
        public string PARABIRIMI { get; set; }
        public decimal DOVIZKURU { get; set; }
        public string TURU { get; set; }
        public string TIPI { get; set; }
        public bool ONAY { get; set; }
        public string VKNTCKN { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string UNVAN { get; set; }
        public string VERGIDAIRESI { get; set; }
        public string ULKE { get; set; }
        public string ADRES { get; set; }
        public string MALHIZMET { get; set; }
        public decimal TOPLAMTUTAR { get; set; }
        public decimal TOPLAMISKONTO { get; set; }
        public decimal HESAPLANANKDV { get; set; }
        public decimal TEVKIFAT_TUTAR { get; set; }
        public decimal TEVKIFAT_KDV { get; set; }
        public decimal HESAPLANAN_KDV_TEVKIFAT { get; set; }
        public decimal VERGILERDAHILTOPLAM { get; set; }
        public decimal ODENECEKTUTAR { get; set; }

        public string NOTLAR { get; set; }

     

    }
}
