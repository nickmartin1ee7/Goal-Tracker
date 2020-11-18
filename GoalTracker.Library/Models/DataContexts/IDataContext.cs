using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.DataContexts
{
    public interface IDataContext
    {
        IGoalRepository ReadRepository();
        bool WriteRepository(IGoalRepository repository);
    }
}