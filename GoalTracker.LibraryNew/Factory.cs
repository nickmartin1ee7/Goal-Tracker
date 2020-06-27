using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
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
            return new ConsoleMainMenu(GetDisplay(), menuOptionsInstance, GetBusinessLogic(menuOptionsInstance));
        }

        public static IMenu GetMainMenu(List<string> menuOptions)
        {
            IMenuOptions menuOptionsInstance = GetMenuOptions(menuOptions);
            return new ConsoleMainMenu(GetDisplay(), menuOptionsInstance, GetBusinessLogic(menuOptionsInstance));
        }

        public static IBusinessLogic GetBusinessLogic(IMenuOptions menuOptions)
        {
            return new BusinessLogic(GetDisplay(), menuOptions);
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
            return new ViewGoalMenu(GetDisplay());
        }
        public static IMenu GetAddGoalMenu()
        {
            return new AddGoalMenu(GetDisplay());
        }

        public static IMenu GetDeleteGoalMenu()
        {
            return new DeleteGoalMenu(GetDisplay());
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
        }

        public static IDatabase GetDatabase()
        {
            return new Database();
        }

        public static IDisplay GetDisplay()
        {
            return new Display();
        }

        public static IConfirmationMenu GetConfirmationMenu(string selectedOption)
        {
            return new ConfirmationMenu(GetDisplay(), selectedOption);
        }
    }
}
