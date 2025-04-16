using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class GetRecipientDataByIDCommand<T> : CommandDispatcherBase<T>
    {
        public GetRecipientDataByIDCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "SICIL_VEYA_MERNISTEN_BILGILERI_GETIR";
            PageName = "RG_BASITFATURA";
        }
    }
}
