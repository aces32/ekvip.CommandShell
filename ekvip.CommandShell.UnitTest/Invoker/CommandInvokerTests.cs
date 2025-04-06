using ekvip.CommandShell.Commands;
using ekvip.CommandShell.Invoker;

namespace ekvip.CommandShell.UnitTest.Invoker
{
    public class CommandInvokerTests
    {
        [Fact]
        public void CommandInvoker_ExecuteCommand_UpdatesResult()
        {
            var invoker = new CommandInvoker();
            int result = invoker.ExecuteCommand(new IncrementCommand(), 5);
            Assert.Equal(6, result);
        }

        [Fact]
        public void CommandInvoker_UndoLastCommand_RevertsResult()
        {
            var invoker = new CommandInvoker();
            int result = invoker.ExecuteCommand(new IncrementCommand(), 5);
            result = invoker.UndoLast(result);
            Assert.Equal(5, result);
        }

        [Fact]
        public void CommandInvoker_UndoWithNoHistory_DoesNothing()
        {
            var invoker = new CommandInvoker();
            int result = invoker.UndoLast(5);
            Assert.Equal(5, result);
        }

        [Fact]
        public void MultipleCommands_ExecuteAndUndo_WorksCorrectly()
        {
            var invoker = new CommandInvoker();
            int result = 1;
            result = invoker.ExecuteCommand(new IncrementCommand(), result); 
            result = invoker.ExecuteCommand(new IncrementCommand(), result); 
            result = invoker.ExecuteCommand(new DoubleCommand(), result); 
            result = invoker.UndoLast(result); 
            result = invoker.UndoLast(result);
            Assert.Equal(2, result);
        }
    }
}
