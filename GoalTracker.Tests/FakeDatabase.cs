using GoalTracker.LibraryNew;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.Tests
{
    internal class FakeDatabase : IDatabase
    {
        public List<Goal> GoalList { get; set; }

        public FakeDatabase()
        {
            GoalList = new List<Goal>()
            {
                new Goal("Do a thing", DateTime.Now.AddDays(-5), DateTime.Now),
                new Goal("Do another thing", DateTime.Now.AddDays(-5), DateTime.Now),
                new Goal("Do one final thing", DateTime.Now.AddDays(-5), DateTime.Now)
            };
        }
    }
}
