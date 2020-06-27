using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    [Obsolete("This data context will not be passed around. And is re-instantiated every time it's referenced")]
    public class InMemoryDataContext : IDataContext
    {
        private IDatabase _db { get; set; } = Factory.GetDatabase();

        public IDatabase LoadDatabase()
        {
            return _db;
        }

        public bool SaveDatabase(IDatabase database)
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
