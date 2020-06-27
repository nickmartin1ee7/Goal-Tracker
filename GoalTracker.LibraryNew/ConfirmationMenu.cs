using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class ConfirmationMenu : IConfirmationMenu
    {
        private IDisplay _display { get; set; }
        private string SelectedOption { get; set; }

        public bool UserApproval { get; private set; } = false;

        public ConfirmationMenu(IDisplay display, string selectedOption)
        {
            _display = display;
            SelectedOption = selectedOption;
        }

        public void StartUI()
        {
            while (true)
            {
                _display.Print($"Are you sure you want to: {SelectedOption}? Y/N ");

                string op = _display.ReadLine();

                if (op.ToUpper() == "Y")
                {
                    UserApproval = true;
                    break;
                }
                else if (op.ToUpper() == "N")
                {
                    UserApproval = false;
                    break;
                }
                else
                    _display.PrintError($"{op} is an invalid response!");
            }
        }
    }
}
