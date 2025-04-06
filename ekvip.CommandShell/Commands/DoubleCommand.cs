using ekvip.CommandShell.Contracts;

namespace ekvip.CommandShell.Commands
{
    public class DoubleCommand : ICommand
    {
        public int Execute(int current) => current * 2;
        public int Undo(int current) => current / 2;
    }
}
