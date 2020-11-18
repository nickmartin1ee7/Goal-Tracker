using System;
using Xunit;
using GoalTracker.LibraryNew;

namespace GoalTracker.Tests
{
    public class GoalTests
    {
        [Fact]
        public void InstantiationTest()
        {
            IGoalRepository fDb = new FakeDatabase();

            fDb.GoalList.ForEach(goal => Console.WriteLine(goal.ToString()));

            Assert.True(fDb.GoalList != null);
        }
    }
}
