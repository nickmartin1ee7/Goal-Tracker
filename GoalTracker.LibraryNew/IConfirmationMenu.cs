namespace GoalTracker.LibraryNew
{
    public interface IConfirmationMenu
    {
        bool UserApproval { get; }

        void StartUI();
    }
}