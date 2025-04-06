using ekvip.CommandShell.Commands;

namespace ekvip.CommandShell.UnitTest.Commands
{
    public class DecrementCommandTests
    {
        [Fact]
        public void DecrementCommand_Execute_DecreasesValue()
        {
            var cmd = new DecrementCommand();
            Assert.Equal(4, cmd.Execute(5));
        }

        [Fact]
        public void DecrementCommand_Undo_IncreasesValue()
        {
            var cmd = new DecrementCommand();
            Assert.Equal(6, cmd.Undo(5));
        }
    }
}
