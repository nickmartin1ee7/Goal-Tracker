using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoalTracker.LibraryNew
{
    [Serializable]
    public class Goal : IGoal
    {
        #region Properties
        [JsonProperty]
        private bool[] _progress { get; set; }
        [JsonProperty]
        private bool _isFinished { get; set; }

        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public bool IsFinished
        {
            get
            {
                // Check if Progress is all true
                if (!_isFinished)
                    if (!Progress.Contains(false))
                        _isFinished = true;

                return _isFinished;
            }
        }
        [JsonIgnore]
        public bool[] Progress 
        { 
            get
            {
                if (_progress == null)
                {
                    return new bool[(int)(EndDate - StartDate).TotalDays + 1];
                }
                else return _progress;
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
                prog += $"\tDate: {StartDate.AddDays(i).ToShortDateString()}\tMade Progress: {Progress[i]}" + Environment.NewLine;
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
                    bool[] tProg = Progress;
                    tProg[i] = madeProgress;
                    _progress = tProg;

                    if (Progress[i] == madeProgress)
                        return true;
                    else return false;
                }
            }
            return false;
        }

        public void Finish()
        {
            _progress = null;
            _isFinished = true;
            EndDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Goal: {GoalName}\nDescription: {GoalDescription}\nIs Finished: {IsFinished}\nStart Date: {StartDate.ToShortDateString()}\nEnd Date: {EndDate.ToShortDateString()}";
        }
        #endregion
    }
}
