﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS.Logic.Layer.ViewModels.DTOs
{
    public class W_TGO_CRS
    {

        public int CRID { get; set; }
        public string CRNE { get; set; }
        public string CREL { get; set; }
        public string CRPD { get; set; }
        public string CRLL { get; set; }
        public string CRRE { get; set; }
        public bool CRCR { get; set; }
        public string CRLLN { get; set; }
        public bool CRACT { get; set; }
        public List<W_TGO_CRS> W_TGO_CRS_LIST { get; set; }
    }


}
