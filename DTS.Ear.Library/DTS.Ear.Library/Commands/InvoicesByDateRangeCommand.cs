using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class InvoicesByDateRangeCommand<T> : CommandDispatcherBase<T>
    {
        public InvoicesByDateRangeCommand(IFaturaServiceConfiguration configuration): base(configuration)
        {
            CommandName = "EARSIV_PORTAL_TASLAKLARI_GETIR";
            PageName = "RG_BASITTASLAKLAR";
        }
    }
}
