using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    class VerifySignSMSCodeCommand<T> : CommandDispatcherBase<T>
    {
        public VerifySignSMSCodeCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "0lhozfib5410mp"; // "EARSIV_PORTAL_SMSSIFRE_DOGRULA";
            PageName = "RG_SMSONAY";
        }
    }
}
