using ekvip.CommandShell.Contracts;

namespace ekvip.CommandShell.Invoker
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> _history = new();

        public int ExecuteCommand(ICommand command, int current)
        {
            int result = command.Execute(current);
            _history.Push(command);
            return result;
        }

        public int UndoLast(int current)
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("Nothing to undo.");
                return current;
            }

            ICommand last = _history.Pop();
            return last.Undo(current);
        }
    }

}
