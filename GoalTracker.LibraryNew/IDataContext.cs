namespace GoalTracker.LibraryNew
{
    public interface IDataContext
    {
        IDatabase LoadDatabase();
        bool SaveDatabase(IDatabase database);
    }
}