using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;

namespace DTS.Logic.Layer.ViewModels.DTOs
{
    public class W_TGO_STOCK_ACTV
    {
        public int STACTID { get; set; }
        public int STID { get; set; }
        public int CRID { get; set; }
        public bool TRASH { get; set; }
        public int ACID { get; set; }
        public string ACNAME { get; set; }
        public int BLID { get; set; }
        public DateTime TARIH { get; set; }
        public string ISLEMTURU { get; set; }
        public int MIKTAR { get; set; }
        public string ACIKLAMA { get; set; }

        public string STACTID64
        {
            get
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(STACTID.ToString()));
            }
        }

    }
}
