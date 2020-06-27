using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    [Serializable]
    public class Goal : IGoal
    {
        #region Properties
        private bool[] _progress { get; set; }

        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFinished { get; private set; }
        public bool[] Progress 
        { 
            get
            {
                if (_progress == null)
                {
                    if (StartDate <= EndDate)
                        return new bool[(int)(EndDate - StartDate).TotalDays];
                    else
                        return new bool[0];
                }
                else return _progress;
            }

            set
            {
                _progress = value;
            }
        }
        #endregion

        #region Constructors
        public Goal(string goalName, DateTime startDate, DateTime endDate)
        {
            GoalName = goalName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Goal(string goalName, string goalDescription, DateTime startDate, DateTime endDate)
        {
            GoalName = goalName;
            GoalDescription = goalDescription;
            StartDate = startDate;
            EndDate = endDate;
        }

        [Obsolete("DO NOT USE. USED FOR CONSTRUCTION VIA JSON SERIALIZATION.")]
        public Goal() { }
        #endregion

        #region Methods

        public string ViewProgress()
        {
            string prog = "Progress:" + Environment.NewLine;

            for (int i = 0; i < Progress.Length; i++)
            {
                prog += $"\tDate: {StartDate.AddDays(i)}\tMade Progress: {Progress[i]}" + Environment.NewLine;
            }

            return prog;
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
            _progress = null;
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
