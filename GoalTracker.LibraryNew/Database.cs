﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GoalTracker.LibraryNew
{
    public class Database : IDatabase
    {
        public List<Goal> GoalList { get; set; }

        public override string ToString()
        {
            if (GoalList != null && GoalList.Count > 0)
            {
                string o = string.Empty;

                for (int i = 0; i < GoalList.Count; i++)
                {
                    o += $"[{i+1}/{GoalList.Count}] - {GoalList[i]}";
                }

                return o;
            }
            else
            {
                return "No goals exist yet!";
            }
        }
    }
}