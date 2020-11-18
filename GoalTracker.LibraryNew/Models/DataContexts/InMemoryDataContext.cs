using System;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.DataContexts
{
    [Obsolete("This data context will not be passed around. And is re-instantiated every time it's referenced")]
    public class InMemoryDataContext : IDataContext
    {
        private IGoalRepository _db { get; set; } = Factory.GetDatabase();

        public IGoalRepository LoadDatabase()
        {
            return _db;
        }

        public bool SaveDatabase(IGoalRepository database)
        {
            if (database != null)
            {
                _db = database;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
