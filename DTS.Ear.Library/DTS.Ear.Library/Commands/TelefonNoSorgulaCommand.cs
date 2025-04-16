using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    class TelefonNoSorgulaCommand<T> : CommandDispatcherBase<T>
    {
        public TelefonNoSorgulaCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_TELEFONNO_SORGULA";
            PageName = "RG_BASITTASLAKLAR";
        }
    }
}
