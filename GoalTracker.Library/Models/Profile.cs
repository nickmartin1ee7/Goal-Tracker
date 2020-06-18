using System;

namespace GoalTracker.Library
{
    [Serializable]
    public class Profile
    {
        #region Properties
        public string Goal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  bool[] Progress
        {
            get
            {
                return new bool[(int)(EndDate - StartDate).TotalDays];
            }
        }
        public DateTime[] DateSpan
        {
            get
            {
                var t = new DateTime[Progress.Length];
                for (int i = 0; i < t.Length; i++)
                    t[i] = StartDate.AddDays(i);
                return t;
            }
        }
        #endregion

        #region Constructors
        public Profile(string name, DateTime startDate, DateTime endDate)
        {
            Goal = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        [Obsolete("Used for JSON serialization only. Does not create a stable profile on it's own.")]
        public Profile() {}
        #endregion

        #region Public
        /// <summary>
        /// Set progress for timeline towards goal
        /// </summary>
        /// <param name="targetDate"></param>
        /// <param name="madeProgress"></param>
        /// <returns>Boolean if targetDate exists within Profile's DateSpan, indicating parallel array for Progress was updated</returns>
        public bool MakeProgress(DateTime targetDate, bool madeProgress)
        {
            for (int i = 0; i < DateSpan.Length; ++i)
            {
                if (DateSpan[i].Date == targetDate.Date)
                {
                    Progress[i] = madeProgress;
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            var r =  $"Goal: {Goal}\nStart Date: {StartDate}\nEnd Date: {EndDate}";
            r += Environment.NewLine;
            r += "[#]\tDate:\t\tCompleted:";
            r += Environment.NewLine;
            for (int i = 0; i < Progress.Length; ++i)
            {
                r += $"[{i}]\t{DateSpan[i].ToShortDateString()}\t{Progress[i]}{Environment.NewLine}";
            }
            r += Environment.NewLine;

            return r;

        }
        #endregion
        
        #region Private
        
        #endregion

    }
}
