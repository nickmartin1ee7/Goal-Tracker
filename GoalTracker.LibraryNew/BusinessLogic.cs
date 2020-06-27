using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class BusinessLogic : IBusinessLogic
    {
        private IMenuOptions _menuOptions { get; set; }
        private IDisplay _display { get; set; }

        public BusinessLogic(IDisplay display, IMenuOptions menuOptions)
        {
            _menuOptions = menuOptions;
            _display = display;
        }

        public void UserRequest(int userOption)
        {
            // Confirm user meant to select menu item
            IConfirmationMenu confirmUserOption = Factory.GetConfirmationMenu(_menuOptions.Options.ElementAt(userOption));
            confirmUserOption.StartUI();
            if (confirmUserOption.UserApproval)
            {
                _menuOptions.OptionImplementations(userOption);
            }
            else
            {
                _display.PrintLine($"Cancelled action");
            }
        }
    }
}
