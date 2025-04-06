using ekvip.CommandShell.Commands;

namespace ekvip.CommandShell.UnitTest.Commands
{
    public class IncrementCommandTests
    {
        [Fact]
        public void IncrementCommand_Execute_IncreasesValue()
        {
            var cmd = new IncrementCommand();
            Assert.Equal(6, cmd.Execute(5));
        }

        [Fact]
        public void IncrementCommand_Undo_DecreasesValue()
        {
            var cmd = new IncrementCommand();
            Assert.Equal(4, cmd.Undo(5));
        }
    }
}
