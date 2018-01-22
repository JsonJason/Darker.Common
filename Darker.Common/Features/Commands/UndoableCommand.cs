namespace Darker.Common
{
    public interface UndoableCommand : Command
    {
        void Undo();
    }
}