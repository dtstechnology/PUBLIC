using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Access.Layer.Models
{
    public partial class TGO_STCK_ACTV
    {
        [Key]
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
    }
}
