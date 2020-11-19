using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.Menus.SubMenus
{
    public class DeleteGoalMenu : IMenu
    {
        private IDisplay _display;
        private IDataContext _dataContext { get; set; }

        public DeleteGoalMenu(IDisplay display, IDataContext dataContext)
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

                    _display.Print("Select a goal # to Delete: ");
                    if (int.TryParse(_display.ReadLine(), out int userOption) && userOption > 0 && userOption <= _dataContext.ReadRepository().GoalList.Count)
                    {
                        --userOption;   // Options display from 1-Length. Normalize back to index.
                        var repo = _dataContext.ReadRepository();
                        repo.GoalList.RemoveAt(userOption);
                        _dataContext.WriteRepository(repo);
                        if (repo == _dataContext.ReadRepository())
                            _display.PrintError("Failed to Delete goal!");
                        else
                            _display.PrintLine("Goal successfully Deleted.");
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
    }
}
