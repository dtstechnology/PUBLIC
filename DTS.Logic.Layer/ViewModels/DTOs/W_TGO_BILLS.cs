using Data.Access.Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;

namespace DTS.Logic.Layer.ViewModels.DTOs
{
    public class W_TGO_BILLS 
    {

         
        public string BLID64
        {
            get
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(BLID.ToString()));
            }
        }

        public string ADSOYAD
        {
            get
            {
                return AD + " " + SOYAD;
            }
        }

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

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TOPLAMTUTAR { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TOPLAMISKONTO { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal HESAPLANANKDV { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TEVKIFAT_TUTAR { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TEVKIFAT_KDV { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal HESAPLANAN_KDV_TEVKIFAT { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal VERGILERDAHILTOPLAM { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ODENECEKTUTAR { get; set; }

        public string NOTLAR { get; set; }

    }
}