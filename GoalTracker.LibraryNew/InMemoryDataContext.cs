using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
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
