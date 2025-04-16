using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.ViewModels
{
    public class W_TGO_EARDASHBOARD 
    {
        public W_TGO_CRS CRS { get; set; }
        public W_TGO_CRS_EASET CRS_SET { get; set; }
        public List<W_TGO_CRS> CRS_LIST { get; set; }
        public List<W_TGO_BILLS> BILL_LIST { get; set; } 
        public FoundDraftInvoiceResponseModel DRAFTINVOICE { get; set;}


    }
}
