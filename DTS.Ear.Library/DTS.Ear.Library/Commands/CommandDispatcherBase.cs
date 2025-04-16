using DTS.Ear.Library.Configuration;
using DTS.Ear.Library.Services;
using System.Threading.Tasks;

namespace DTS.Ear.Library.Commands
{
    abstract public class CommandDispatcherBase<T>: ICommandDispatcher<T>
    {
        public string CommandName { get; protected set; }
        public string PageName { get; protected set; }
        public object Data { get; set; } = null;

        protected IFaturaServiceConfiguration _configuration;

        public CommandDispatcherBase(IFaturaServiceConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual async Task<T> Dispatch()
        {
            IHttpServices<T> services = new HttpServices<T>(_configuration);
            T response = await services.DispatchCommand(CommandName, PageName, Data);

            return response;
        }
    }
}
