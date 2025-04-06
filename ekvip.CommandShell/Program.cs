using ekvip.CommandShell.Commands;
using ekvip.CommandShell.Contracts;
using ekvip.CommandShell.Invoker;

// NOTE: Initial value is read from command - line argument as required.
if (args.Length < 1 || !int.TryParse(args[0], out int result))
{
    Console.WriteLine("Usage: dotnet run <initialValue>");
    return;
}

//var result = 0;
var invoker = new CommandInvoker();

while (true)
{
    Console.Write("Enter proper command: ");
    var input = Console.ReadLine()?.Trim().ToLower();

    if (string.IsNullOrEmpty(input)) continue;

    ICommand? command = input switch
    {
        "increment" => new IncrementCommand(),
        "decrement" => new DecrementCommand(),
        "double" => new DoubleCommand(),
        "randadd" => new RandAddCommand(),
        "undo" => null,
        _ => null
    };

    result = HandleCommand(result, invoker, input, command);

}

static int HandleCommand(int result, CommandInvoker invoker, string input, ICommand? command)
{
    switch (input)
    {
        case "undo":
            result = invoker.UndoLast(result);
            Console.WriteLine($"Undo applied. Result: {result}");
            break;

        case var _ when command is not null:
            result = invoker.ExecuteCommand(command, result);
            Console.WriteLine($"Result: {result}");
            break;

        default:
            Console.WriteLine("Unknown command.");
            break;
    }

    return result;
}