using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Logic.Layer.ViewModels.DTOs;

namespace DTS.Logic.Layer.ViewModels
{
    public class ViewModelBase
    {
        public W_TGO_CRS_PROFILE CRS_PROFILE { get; set; }
        public string UNAME { get; set; }
        public string RESULT_MESSAGE { get; set; }
        public bool RESULT { get; set; }
    }
}
