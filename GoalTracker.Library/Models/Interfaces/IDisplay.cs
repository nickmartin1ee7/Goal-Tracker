namespace GoalTracker.Library.Models.Interfaces
{
    public interface IDisplay
    {
        void PrintLine(string message);
        void Print(string message);
        void PrintError(string errorMessage);
        void WaitForKey();
        string ReadLine();
    }
}