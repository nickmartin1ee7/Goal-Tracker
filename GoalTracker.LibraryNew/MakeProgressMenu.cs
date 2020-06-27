﻿using System;
using System.Linq;

namespace GoalTracker.LibraryNew
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
            if (_dataContext.LoadDatabase().GoalList?.Count > 0)
            {
                while (true)
                {
                    Console.Clear(); // TODO remove

                    _display.PrintLine(_dataContext.LoadDatabase().ToString());

                    _display.Print("Select a goal # to Update progress: ");
                    if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _dataContext.LoadDatabase().GoalList.Count)
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
                        catch (FormatException e)
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
            IDatabase db = _dataContext.LoadDatabase();
            if (db.GoalList.ElementAt(targetGoalIndex).MakeProgress(targetDate, madeProgress))
                return _dataContext.SaveDatabase(db);
            else return false;
        }

        private void PrintGoalDetails(int targetGoalIndex)
        {
            IGoal targetGoal = _dataContext.LoadDatabase().GoalList.ElementAt(targetGoalIndex);
            _display.PrintLine(targetGoal.ToString());
            _display.PrintLine(targetGoal.ViewProgress());
        }
    }
}