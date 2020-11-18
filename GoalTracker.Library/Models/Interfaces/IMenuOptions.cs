using System.Collections.Generic;

namespace GoalTracker.Library.Models.Interfaces
{
    public interface IMenuOptions
    {
        List<string> Options { get; }

        void OptionImplementations(int optionIndex);
        string ToString();
    }
}