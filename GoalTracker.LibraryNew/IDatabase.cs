using System.Collections.Generic;

namespace GoalTracker.LibraryNew
{
    public interface IDatabase
    {
        List<Goal> GoalList { get; set; }
    }
}