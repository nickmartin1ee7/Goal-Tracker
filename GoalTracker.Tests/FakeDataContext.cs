using GoalTracker.LibraryNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.Tests
{
    internal class FakeDataContext : IDataContext
    {
        public IGoalRepository Db { get; set; } = new FakeDatabase();
        public IGoalRepository LoadDatabase()
        {
            return Db;
        }

        public bool SaveDatabase(IGoalRepository database)
        {
            Db = database;
            return true;
        }
    }
}
