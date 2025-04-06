using ekvip.CommandShell.Contracts;

namespace ekvip.CommandShell.Commands
{
    public class RandAddCommand : ICommand
    {
        private int _delta;
        private static readonly Random _random = new();

        public RandAddCommand()
        {
            _delta = _random.Next(-10, 51); 
        }

        public int Execute(int current) => current + _delta;
        public int Undo(int current) => current - _delta;
    }
}
