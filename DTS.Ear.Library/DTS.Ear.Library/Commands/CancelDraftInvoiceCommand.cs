using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class CancelDraftInvoiceCommand<T> : CommandDispatcherBase<T>
    {
        public CancelDraftInvoiceCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_SIL";
            PageName = "RG_BASITTASLAKLAR";
        }
    }
}
