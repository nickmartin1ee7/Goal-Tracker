using System;
using System.Linq;
using GoalTracker.Library.Models.DataContexts;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.Menus.SubMenus
{
    public class FinishGoalMenu : IMenu
    {
        private IDisplay _display;
        private IDataContext _dataContext { get; set; }

        public FinishGoalMenu(IDisplay display, IDataContext dataContext)
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

                    _display.Print("Select a goal # to Finish: ");
                    if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _dataContext.ReadRepository().GoalList.Count)
                    {
                        --userOption;   // Options display from 1-Length. Normalize back to index.
                        if (FinishGoal(userOption))
                            _display.PrintLine("Goal successfully Finished.");
                        else
                            _display.PrintError("Failed to Finish goal!");
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

        private bool FinishGoal(int targetGoalIndex)
        {
            IGoalRepository repo = _dataContext.ReadRepository();
            repo.GoalList.ElementAt(targetGoalIndex).Finish();
            return _dataContext.WriteRepository(repo);
        }
    }
}