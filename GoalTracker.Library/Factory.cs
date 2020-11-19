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
        public static IApplication GetApplication() =>
            new Application();

        public static IGoal GetGoal(string goalName, string goalDescription, DateTime startDate, DateTime endDate) =>
            new Goal(goalName, goalDescription, startDate, endDate);

        public static IDataContext GetDataContext() =>
            new JsonDataContext();

        public static IGoalRepository GetRepository() =>
            new GoalRepository();

        public static IDisplay GetDisplay() =>
            new ConsoleDisplay();

        #region GetMenus
        
        public static IUserInteractionManager GetUserInteractionManager(IMenuOptions menuOptions) =>
            new UserInteractionManager(GetDisplay(), menuOptions);

        public static IMenuOptions GetMenuOptions() =>
            new MenuOptions();

        public static IMenu GetMainMenu()
        {
            IMenuOptions menuOptionsInstance = GetMenuOptions();
            return new ConsoleMainMenu(GetDisplay(), menuOptionsInstance, GetUserInteractionManager(menuOptionsInstance), GetDataContext());
        }

        public static IMenu GetViewGoalMenu() =>
            new ViewGoalMenu(GetDisplay(), GetDataContext());
        public static IMenu GetMakeProgressMenu() =>
            new MakeProgressMenu(GetDisplay(), GetDataContext());

        public static IMenu GetAddGoalMenu() =>
            new AddGoalMenu(GetDisplay(), GetDataContext());

        public static IMenu GetFinishGoalMenu() =>
            new FinishGoalMenu(GetDisplay(), GetDataContext());

        public static IConfirmationMenu GetConfirmationMenu(string selectedOption) =>
            new ConfirmationMenu(GetDisplay(), selectedOption);

        public static IMenu GetDeleteGoalMenu() =>
            new DeleteGoalMenu(GetDisplay(), GetDataContext());

        #endregion
    }
}
