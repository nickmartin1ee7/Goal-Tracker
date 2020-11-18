namespace GoalTracker.LibraryNew
{
    public interface IDataContext
    {
        IGoalRepository LoadDatabase();
        bool SaveDatabase(IGoalRepository database);
    }
}