namespace GoalTracker.Library.Models.Interfaces
{
    public interface IDataContext
    {
        IGoalRepository ReadRepository();
        bool WriteRepository(IGoalRepository repository);
    }
}