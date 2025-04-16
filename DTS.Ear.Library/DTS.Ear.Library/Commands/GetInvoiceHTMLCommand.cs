using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class GetInvoiceHTMLCommand<T> : CommandDispatcherBase<T>
    {
        public GetInvoiceHTMLCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_GOSTER";
            PageName = "RG_BASITTASLAKLAR";
        }
    }
}
