using System;
using System.Collections.Generic;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.Menus.MenuOptions
{
    public class MenuOptions : IMenuOptions
    {
        public List<string> Options { get; set; }

        /// <summary>
        /// If for some reason you want to specify different options, you must implement them in this class under OptionImplementations()
        /// </summary>
        /// <param name="optionsList">Custom options</param>
        public MenuOptions(List<string> optionsList)
        {
            Options = optionsList;
        }

        /// <summary>
        /// Used implemented default list
        /// </summary>
        public MenuOptions()
        {
            Options = new List<string>()
            {
                "View Goal",
                "Add Goal",
                "Make Progress towards Goal",
                "Finish Goal",
                "Delete Goal"
            };
        }

        public void OptionImplementations(int optionIndex)
        {
            switch (optionIndex)
            {
                case 0: // View Goal
                    IMenu viewGoalMenu = Factory.GetViewGoalMenu();
                    viewGoalMenu.StartUI();
                    break;
                case 1: // Add Goal
                    IMenu addGoalMenu = Factory.GetAddGoalMenu();
                    addGoalMenu.StartUI();
                    break;
                case 2: // Make progress towards goal
                    IMenu makeProgressMenu = Factory.GetMakeProgressMenu();
                    makeProgressMenu.StartUI();
                    break;
                case 3: // Finish Goal
                    IMenu finishGoalMenu = Factory.GetFinishGoalMenu();
                    finishGoalMenu.StartUI();
                    break;
                case 4: // Finish Goal
                    IMenu deleteGoalMenu = Factory.GetDeleteGoalMenu();
                    deleteGoalMenu.StartUI();
                    break;
                default:    // INVALID OPTION
                    throw new NotImplementedException($"Specified menu option has no implementation!");
            }
        }

        public override string ToString()
        {
            if (Options != null && Options.Count > 0)
            {
                string o = string.Empty;
                for (int i = 0; i < Options.Count; i++)
                {
                    o += $"[{i+1}] - " + Options[i] + Environment.NewLine;
                }
                return o;
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
