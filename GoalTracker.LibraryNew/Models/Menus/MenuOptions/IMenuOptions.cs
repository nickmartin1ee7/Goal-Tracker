using System.Collections.Generic;

namespace GoalTracker.LibraryNew
{
    public interface IMenuOptions
    {
        List<string> Options { get; }

        void OptionImplementations(int optionIndex);
        string ToString();
    }
}