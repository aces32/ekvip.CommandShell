using ekvip.CommandShell.Commands;

namespace ekvip.CommandShell.UnitTest.Commands
{
    public class RandAddCommandTests
    {
        [Fact]
        public void RandAddCommand_ExecuteAndUndo_RestoresValue()
        {
            var cmd = new RandAddCommand();
            int original = 10;
            int result = cmd.Execute(original);
            int restored = cmd.Undo(result);
            Assert.Equal(original, restored);
        }

    }
}
