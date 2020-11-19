using System;
using System.Linq;
using GoalTracker.Library.Models.DataContexts;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.Menus.SubMenus
{
    public class MakeProgressMenu : IMenu
    {
        private IDisplay _display;
        private IDataContext _dataContext { get; set; }

        public MakeProgressMenu(IDisplay display, IDataContext dataContext)
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

                    _display.Print("Select a goal # to Update progress: ");
                    if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _dataContext.ReadRepository().GoalList.Count)
                    {
                        --userOption;   // Options display from 1-Length. Normalize back to index.

                        PrintGoalDetails(userOption);

                        try
                        {
                            _display.Print("Enter target date to update: ");
                            DateTime targetDate = DateTime.Parse(_display.ReadLine());

                            IConfirmationMenu confirmationMenu = Factory.GetConfirmationMenu($"wanted to mark {targetDate.ToShortDateString()} as made progress");
                            confirmationMenu.StartUI();

                            if (UpdateGoalProgress(userOption, targetDate, confirmationMenu.UserApproval))
                                _display.PrintLine("Successfully updated progress for goal.");
                            else
                                _display.PrintError("Failed to update progress for goal!");
                        }
                        catch (FormatException)
                        {
                            _display.PrintError("Invalid date was entered!");
                        }
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

        private bool UpdateGoalProgress(int targetGoalIndex, DateTime targetDate, bool madeProgress)
        {
            IGoalRepository repo = _dataContext.ReadRepository();
            if (repo.GoalList.ElementAt(targetGoalIndex).MakeProgress(targetDate, madeProgress))
                return _dataContext.WriteRepository(repo);
            else return false;
        }

        private void PrintGoalDetails(int targetGoalIndex)
        {
            IGoal targetGoal = _dataContext.ReadRepository().GoalList.ElementAt(targetGoalIndex);
            _display.PrintLine(targetGoal.ToString());
            _display.PrintLine(targetGoal.ViewProgress());
        }
    }
}