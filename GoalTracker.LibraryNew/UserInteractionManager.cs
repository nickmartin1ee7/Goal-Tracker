﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class UserInteractionManager : IUserInteractionManager
    {
        private IMenuOptions _menuOptions { get; set; }
        private IDisplay _display { get; set; }

        public UserInteractionManager(IDisplay display, IMenuOptions menuOptions)
        {
            _menuOptions = menuOptions;
            _display = display;
        }

        public void UserRequest(int userOption)
        {
            IConfirmationMenu confirmUserOption = Factory.GetConfirmationMenu(_menuOptions.Options.ElementAt(userOption));
            confirmUserOption.StartUI();
            if (confirmUserOption.UserApproval)
            {
                _menuOptions.OptionImplementations(userOption);
            }
            else
            {
                _display.PrintLine($"Action cancelled.");
            }
        }
    }
}
