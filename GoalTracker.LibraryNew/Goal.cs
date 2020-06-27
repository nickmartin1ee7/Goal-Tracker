using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class Goal : IGoal
    {
        #region Properties
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFinished { get; private set; }
        public bool[] Progress { get; private set; }
        #endregion

        #region Constructors
        public Goal(string goalName, DateTime startDate, DateTime endDate)
        {
            GoalName = goalName;
            StartDate = startDate;
            EndDate = endDate;
            GenerateProgressFromDateDifference();
        }

        public Goal(string goalName, string goalDescription, DateTime startDate, DateTime endDate)
        {
            GoalName = goalName;
            GoalDescription = goalDescription;
            StartDate = startDate;
            EndDate = endDate;
            GenerateProgressFromDateDifference();
        }
        #endregion

        #region Methods

        private void GenerateProgressFromDateDifference()
        {
            if (StartDate < EndDate)
                Progress = new bool[(int)(EndDate - StartDate).TotalDays];
            else
                throw new ArgumentOutOfRangeException("Start Date cannot be after End Date!");
        }

        public bool MakeProgress(DateTime targetDate, bool madeProgress)
        {
            DateTime[] span = new DateTime[Progress.Length];
            for (int i = 0; i < Progress.Length; i++)
                span[i] = StartDate.AddDays(i);

            for (int i = 0; i < span.Length; ++i)
            {
                if (span[i].Date == targetDate.Date)
                {
                    Progress[i] = madeProgress;
                    return true;
                }
            }
            return false;
        }

        public void GiveUp()
        {
            Progress = null;
            IsFinished = true;
            EndDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Goal: {GoalName}\nDescription: {GoalDescription}\nIs Finished: {IsFinished}\nStart Date: {StartDate.ToShortDateString()}\nEnd Date: {EndDate.ToShortDateString()}";
        }
        #endregion
    }
}
