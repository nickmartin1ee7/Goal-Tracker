using System;
using System.Collections.Generic;
using GoalTracker.Library.Models;
using GoalTracker.Library.Models.DataContexts;
using GoalTracker.Library.Models.Interfaces;
using GoalTracker.Library.Models.Menus.MainMenus;
using GoalTracker.Library.Models.Menus.MenuOptions;
using GoalTracker.Library.Models.Menus.SubMenus;
using GoalTracker.Library.Models.Repositories;

namespace GoalTracker.Library
{
    /// <summary>
    /// Methods are used to return the current implementation of the needed interface.
    /// </summary>
    public static class Factory
    {
        public static IApplication GetApplication()
        {
            return new Application();
        }

        public static IMenu GetMainMenu()
        {
            IMenuOptions menuOptionsInstance = GetMenuOptions();
            return new ConsoleMainMenu(GetDisplay(), menuOptionsInstance, GetUserInteractionManager(menuOptionsInstance), GetDataContext());
        }

        public static IMenu GetMainMenu(List<string> menuOptions)
        {
            IMenuOptions menuOptionsInstance = GetMenuOptions(menuOptions);
            return new ConsoleMainMenu(GetDisplay(), menuOptionsInstance, GetUserInteractionManager(menuOptionsInstance), GetDataContext());
        }

        public static IUserInteractionManager GetUserInteractionManager(IMenuOptions menuOptions)
        {
            return new UserInteractionManager(GetDisplay(), menuOptions);
        }

        public static IMenuOptions GetMenuOptions()
        {
            return new MenuOptions();
        }

        public static IMenuOptions GetMenuOptions(List<string> menuOptions)
        {
            return new MenuOptions(menuOptions);
        }
        public static IMenu GetViewGoalMenu()
        {
            return new ViewGoalMenu(GetDisplay(), GetDataContext());
        }
        public static IMenu GetMakeProgressMenu()
        {
            return new MakeProgressMenu(GetDisplay(), GetDataContext());
        }

        public static IMenu GetAddGoalMenu()
        {
            return new AddGoalMenu(GetDisplay(), GetDataContext());
        }

        public static IMenu GetFinishGoalMenu()
        {
            return new FinishGoalMenu(GetDisplay(), GetDataContext());
        }

        public static IGoal GetGoal(string goalName, DateTime startDate, DateTime endDate)
        {
            return new Goal(goalName, startDate, endDate);
        }

        public static IGoal GetGoal(string goalName, string goalDescription, DateTime startDate, DateTime endDate)
        {
            return new Goal(goalName, goalDescription, startDate, endDate);
        }

        public static IDataContext GetDataContext()
        {
            return new JsonDataContext();
            /*
            // Test data
            IDataContext o = new InMemoryDataContext();
            IDatabase d = GetDatabase();
            d.GoalList = new List<Goal>()
            {
                new Goal("Test goal", DateTime.Now.AddDays(-5), DateTime.Now),
                new Goal("Test goal", DateTime.Now.AddDays(-5), DateTime.Now),
                new Goal("Test goal", DateTime.Now.AddDays(-5), DateTime.Now),
            };
            o.SaveDatabase(d);
            return o;
            */
        }

        public static IGoalRepository GetDatabase()
        {
            return new GoalRepository();
        }

        public static IDisplay GetDisplay()
        {
            return new ConsoleDisplay();
        }

        public static IConfirmationMenu GetConfirmationMenu(string selectedOption)
        {
            return new ConfirmationMenu(GetDisplay(), selectedOption);
        }
    }
}
