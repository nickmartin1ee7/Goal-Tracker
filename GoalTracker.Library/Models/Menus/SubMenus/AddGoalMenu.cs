﻿using System;
using GoalTracker.Library.Models.DataContexts;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.Menus.SubMenus
{
    public class AddGoalMenu : IMenu
    {
        private IDisplay _display;
        private IDataContext _dataContext { get; set; }

        public AddGoalMenu(IDisplay display, IDataContext dataContext)
        {
            _display = display;
            _dataContext = dataContext;
        }

        public void StartUI()
        {
            while (true)
            {
                _display.Clear();

                string goalName;
                string goalDesc;
                DateTime startDate;
                DateTime endDate;

                _display.Print("Goal Name: ");
                goalName = _display.ReadLine();

                _display.Print("Goal Description: ");
                goalDesc = _display.ReadLine();

                try
                {
                    _display.Print("Goal Start Date: ");
                    startDate = DateTime.Parse(_display.ReadLine());

                    _display.Print("Goal End Date: ");
                    endDate = DateTime.Parse(_display.ReadLine());

                    if (startDate <= endDate && SaveNewGoal(goalName, goalDesc, startDate, endDate))
                    {
                        _display.PrintLine($"Successfully added goal: {goalName}");
                    }
                    else
                    {
                        _display.PrintError($"Failed to add goal: {goalName}");
                    }

                    break;
                }
                catch (FormatException e)
                {
                    _display.PrintError(e.Message);
                }
            }
        }

        private bool SaveNewGoal(string goalName, string goalDesc, DateTime startDate, DateTime endDate)
        {
            IGoal newGoal = Factory.GetGoal(goalName, goalDesc, startDate, endDate);
            return InsertNewGoalIntoRepository(newGoal);
        }

        private bool InsertNewGoalIntoRepository(IGoal newGoal)
        {
            IGoalRepository repo = _dataContext.ReadRepository();
            repo.GoalList.Add((Goal)newGoal);
            return _dataContext.WriteRepository(repo);
        }
    }
}