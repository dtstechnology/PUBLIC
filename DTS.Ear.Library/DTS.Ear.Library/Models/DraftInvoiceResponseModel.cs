﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS.Ear.Library.Models
{
    public class DraftInvoiceResponseModel
    {
        public string date { get; set; }
        public string uuid { get; set; }
        public string data { get; set; }
    }

    public class DraftInvoiceResponseMetaData
    {
        public string optime { get; set; }
    }
}
