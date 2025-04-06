using ekvip.CommandShell.Commands;
using ekvip.CommandShell.Invoker;

namespace ekvip.CommandShell.IntegrationTest.Command
{
    public class CommandIntegrationTests
    {
        [Fact]
        public void FullCommandSequence_WithUndo_WorksAsExpected()
        {
            var invoker = new CommandInvoker();
            int result = 1;

            result = invoker.ExecuteCommand(new IncrementCommand(), result); 
            Assert.Equal(2, result);

            result = invoker.ExecuteCommand(new IncrementCommand(), result); 
            Assert.Equal(3, result);

            result = invoker.ExecuteCommand(new IncrementCommand(), result); 
            Assert.Equal(4, result);

            // double
            result = invoker.ExecuteCommand(new DoubleCommand(), result); 
            Assert.Equal(8, result);

            // undo
            result = invoker.UndoLast(result); 
            Assert.Equal(4, result);

            // undo
            result = invoker.UndoLast(result); 
            Assert.Equal(3, result);
        }

        [Fact]
        public void RandAddCommand_ExecuteAndUndo_MaintainsIntegrity()
        {
            var invoker = new CommandInvoker();
            int initial = 50;
            var randCmd = new RandAddCommand();
            int result = invoker.ExecuteCommand(randCmd, initial);
            result = invoker.UndoLast(result);
            Assert.Equal(initial, result);
        }

        [Fact]
        public void MixedCommandSequence_ProducesExpectedResults()
        {
            var invoker = new CommandInvoker();
            int result = 10;

            result = invoker.ExecuteCommand(new DecrementCommand(), result); 
            Assert.Equal(9, result);

            result = invoker.ExecuteCommand(new DoubleCommand(), result); 
            Assert.Equal(18, result);

            result = invoker.ExecuteCommand(new IncrementCommand(), result); 
            Assert.Equal(19, result);

            result = invoker.UndoLast(result); 
            Assert.Equal(18, result);

            result = invoker.UndoLast(result);
            Assert.Equal(9, result);
        }
    }
}
