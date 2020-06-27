using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class ConsoleMainMenu : IMenu
    {
        private IDisplay _display { get; set; }
        private IMenuOptions _menuOptions { get; set; }
        private IBusinessLogic _logic{ get; set; }

        public ConsoleMainMenu(IDisplay display, IMenuOptions menuOptions, IBusinessLogic logic)
        {
            _display = display;
            _menuOptions = menuOptions;
            _logic = logic;
        }

        public void StartUI()
        {
            while (true)
            {
                Console.Clear();

                // Header
                _display.PrintLine("== Goal Tracker =="
                    + Environment.NewLine);

                // Display options
                _display.PrintLine(_menuOptions.ToString());

                // Capture user input
                _display.Print("Select an option: ");
                if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _menuOptions.Options.Count)
                {
                    --userOption;   // Options display from 1-Length. Normalize back to index.
                    _logic.UserRequest(userOption);
                    _display.WaitForKey();
                }
                else
                {
                    _display.PrintError($"{userOption} is not a valid menu item!");
                    _display.WaitForKey();
                }

                // TODO Make IBusinessLogic
            }
        }
    }
}
