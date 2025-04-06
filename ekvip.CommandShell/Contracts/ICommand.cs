namespace ekvip.CommandShell.Contracts
{
    public interface ICommand
    {
        int Execute(int current);
        int Undo(int current);
    }
}
