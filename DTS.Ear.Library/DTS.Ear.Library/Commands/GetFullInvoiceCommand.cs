using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class GetFullInvoiceCommand<T> : CommandDispatcherBase<T>
    {
        public GetFullInvoiceCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_GETIR";
            PageName = "RG_BASITFATURA";
        }
    }
}
