using System.Collections.Generic;

namespace GoalTracker.LibraryNew
{
    public interface IGoalRepository
    {
        List<Goal> GoalList { get; set; }

        string ToString();
    }
}