using ekvip.CommandShell.Contracts;

namespace ekvip.CommandShell.Commands
{
    public class DecrementCommand : ICommand
    {
        public int Execute(int current) => current - 1;
        public int Undo(int current) => current + 1;
    }
}
