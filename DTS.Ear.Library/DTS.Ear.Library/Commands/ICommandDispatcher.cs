using System.Threading.Tasks;

namespace DTS.Ear.Library.Commands
{
    public interface ICommandDispatcher<T>
    {
        public string CommandName { get; }
        public string PageName { get; }
        object Data { get; set; }

        public Task<T> Dispatch();
    }
}
