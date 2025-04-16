using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class GetIncomingInvoiceCommand<T> : CommandDispatcherBase<T>
    {
        public GetIncomingInvoiceCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_ADIMA_KESILEN_BELGELERI_GETIR";
            PageName = "RG_ALICI_TASLAKLAR";
        }
    }
}
