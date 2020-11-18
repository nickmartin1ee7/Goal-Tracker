using System;

namespace GoalTracker.Library.Models.Interfaces
{
    public interface IGoal
    {
        string GoalName { get; set; }
        string GoalDescription { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool[] Progress { get; }
        bool IsFinished { get; }

        string ViewProgress();
        bool MakeProgress(DateTime targetDate, bool madeProgress);
        void Finish();
        string ToString();
    }
}