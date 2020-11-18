using System;
using System.Collections.Generic;

namespace GoalTracker.LibraryNew
{
    [Serializable]
    public class GoalRepository : IGoalRepository
    {
        private readonly string dblNewLine = Environment.NewLine + Environment.NewLine;

        public List<Goal> GoalList { get; set; } = new List<Goal>();
        
        public override string ToString()
        {
            if (GoalList?.Count > 0)
            {
                string o = string.Empty;

                for (int i = 0; i < GoalList.Count; i++)
                {
                    o += $"[{i+1}/{GoalList.Count}] - {GoalList[i]}" + dblNewLine;
                }

                return o;
            }
            else
            {
                return "No goals exist yet!" + dblNewLine;
            }
        }
    }
}