using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class CreateDraftInvoiceCommand<T>: CommandDispatcherBase<T>
    {
        public CreateDraftInvoiceCommand(IFaturaServiceConfiguration configuration): base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_OLUSTUR";
            PageName = "RG_BASITFATURA";
        }
    }
}
