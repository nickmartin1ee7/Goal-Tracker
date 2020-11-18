using GoalTracker.LibraryNew;

namespace GoalTracker.Console
{
    public class Program
    {
        public static void Main()
        {
            IApplication app = Factory.GetApplication();
            app.Run();
        }
    }
}
