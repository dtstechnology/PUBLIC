using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    class SendSignSMSCodeCommand<T> : CommandDispatcherBase<T>
    {
        public SendSignSMSCodeCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_SMSSIFRE_GONDER";
            PageName = "RG_SMSONAY";
        }
    }
}
