using GoalTracker.Library;
using GoalTracker.Library.Models.Interfaces;

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
