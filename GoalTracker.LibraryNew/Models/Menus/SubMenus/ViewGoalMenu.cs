using System.Linq;

namespace GoalTracker.LibraryNew
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
            if (_dataContext.LoadDatabase().GoalList?.Count > 0)
            {
                while (true)
                {
                    System.Console.Clear(); // TODO remove

                    _display.PrintLine(_dataContext.LoadDatabase().ToString());

                    _display.Print("Select a goal # to View: ");
                    if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _dataContext.LoadDatabase().GoalList.Count)
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
            IGoal targetGoal = _dataContext.LoadDatabase().GoalList.ElementAt(targetGoalIndex);
            _display.PrintLine(targetGoal.ToString());
            _display.PrintLine(targetGoal.ViewProgress());
        }
    }
}