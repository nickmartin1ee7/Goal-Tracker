using System;
using System.Linq;

namespace GoalTracker.LibraryNew
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
            if (_dataContext.LoadDatabase().GoalList?.Count > 0)
            {
                while (true)
                {
                    Console.Clear(); // TODO remove

                    _display.PrintLine(_dataContext.LoadDatabase().ToString());

                    _display.Print("Select a goal # to Finish: ");
                    if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _dataContext.LoadDatabase().GoalList.Count)
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
            IDatabase db = _dataContext.LoadDatabase();
            db.GoalList.ElementAt(targetGoalIndex).Finish();
            return _dataContext.SaveDatabase(db);
        }
    }
}