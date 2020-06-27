using GoalTracker.LibraryNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.Tests
{
    internal class FakeDataContext : IDataContext
    {
        public IDatabase Db { get; set; } = new FakeDatabase();
        public IDatabase LoadDatabase()
        {
            return Db;
        }

        public bool SaveDatabase(IDatabase database)
        {
            Db = database;
            return true;
        }
    }
}
