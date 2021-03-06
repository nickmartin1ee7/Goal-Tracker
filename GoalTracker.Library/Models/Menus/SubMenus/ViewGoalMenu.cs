﻿using System.Linq;
using GoalTracker.Library.Models.DataContexts;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.Menus.SubMenus
{
    public class ViewGoalMenu : IMenu
    {
        private IDisplay _display;
        private IDataContext _dataContext { get; set; }

        public ViewGoalMenu(IDisplay display, IDataContext dataContext)
        {
            _display = display;
            _dataContext = dataContext;
        }

        public void StartUI()
        {
            if (_dataContext.ReadRepository().GoalList.Count > 0)
            {
                while (true)
                {
                    _display.Clear();

                    _display.PrintLine(_dataContext.ReadRepository().ToString());

                    _display.Print("Select a goal # to View: ");
                    if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _dataContext.ReadRepository().GoalList.Count)
                    {
                        --userOption;   // Options display from 1-Length. Normalize back to index.
                        PrintGoalDetails(userOption);
                        break;
                    }
                    else
                    {
                        _display.PrintError($"{userOption} is not a valid goal number!");
                    }
                }
            }
            else
            {
                _display.PrintError($"No goals exist yet!");
            }
        }

        private void PrintGoalDetails(int targetGoalIndex)
        {
            IGoal targetGoal = _dataContext.ReadRepository().GoalList.ElementAt(targetGoalIndex);
            _display.PrintLine(targetGoal.ToString());
            _display.PrintLine(targetGoal.ViewProgress());
        }
    }
}