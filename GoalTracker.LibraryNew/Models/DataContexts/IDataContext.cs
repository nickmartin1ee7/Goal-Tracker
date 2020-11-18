using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.DataContexts
{
    public interface IDataContext
    {
        IGoalRepository LoadDatabase();
        bool SaveDatabase(IGoalRepository database);
    }
}