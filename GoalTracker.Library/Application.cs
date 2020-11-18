using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library
{
    public class Application : IApplication
    {
        public void Run()
        {
            IMenu mainMenu = Factory.GetMainMenu();
            mainMenu.StartUI();
        }
    }
}
