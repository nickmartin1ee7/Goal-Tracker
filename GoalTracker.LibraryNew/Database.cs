using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class Database : IDatabase
    {
        public List<Goal> GoalList { get; set; }
    }
}
