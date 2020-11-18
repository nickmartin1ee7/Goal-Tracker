namespace GoalTracker.Library.Models.Interfaces
{
    public interface IConfirmationMenu
    {
        bool UserApproval { get; }

        void StartUI();
    }
}