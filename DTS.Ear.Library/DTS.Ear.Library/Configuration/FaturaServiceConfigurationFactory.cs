using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS.Ear.Library.Configuration
{
    public class FaturaServiceConfigurationFactory
    {
        public static IFaturaServiceConfiguration Create()
        {
            return new FaturaServiceConfiguration();
        }
    }
}
