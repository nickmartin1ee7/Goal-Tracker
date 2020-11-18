using System;
using System.Linq;
using GoalTracker.Library.Models.Interfaces;
using Newtonsoft.Json;

namespace GoalTracker.Library.Models
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
                    int span = (int)(EndDate.Date - StartDate.Date).TotalDays + 1;

                    if (span > 0)
                        _progress = new bool[span];
                    else
                        throw new ArithmeticException("End date cannot be before Start date!");
                }
                return _progress;
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
            _isFinished = true;

            for (int i = 0; i < Progress.Length; i++)
            {
                Progress[i] = true;
            }

            if (DateTime.Now.Date < StartDate) EndDate = StartDate;
            else EndDate = DateTime.Now;
        }

        public override string ToString()
        {
            double percent = 0;
            try
            {
                percent = (double)Progress.Count(x => x) / (double)Progress.Length;
            }
            catch (Exception){}

            return $"Goal: {GoalName}\nDescription: {GoalDescription}\nIs Finished: {IsFinished}\nStart Date: {StartDate.ToShortDateString()}\nEnd Date: {EndDate.ToShortDateString()}\nPercent Complete: {percent:P}";
        }
        #endregion
    }
}
