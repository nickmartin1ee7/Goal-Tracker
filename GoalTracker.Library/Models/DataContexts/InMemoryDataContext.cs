using System;
using GoalTracker.Library.Models.Interfaces;

namespace GoalTracker.Library.Models.DataContexts
{
    [Obsolete("This data context will not be passed around. And is re-instantiated every time it's referenced")]
    public class InMemoryDataContext : IDataContext
    {
        private IGoalRepository _repo { get; set; } = Factory.GetRepository();

        public IGoalRepository ReadRepository()
        {
            return _repo;
        }

        public bool WriteRepository(IGoalRepository repository)
        {
            if (repository != null)
            {
                _repo = repository;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
