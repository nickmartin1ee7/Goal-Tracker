using System;
using System.Collections.Generic;

namespace GoalTracker.LibraryNew
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
