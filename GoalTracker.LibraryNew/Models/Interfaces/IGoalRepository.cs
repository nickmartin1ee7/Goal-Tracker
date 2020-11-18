using System.Collections.Generic;

namespace GoalTracker.Library.Models.Interfaces
{
    public interface IGoalRepository
    {
        List<Goal> GoalList { get; set; }

        string ToString();
    }
}