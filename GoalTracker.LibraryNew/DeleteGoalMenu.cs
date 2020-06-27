namespace GoalTracker.LibraryNew
{
    internal class DeleteGoalMenu : IMenu
    {
        private IDisplay _display;

        public DeleteGoalMenu(IDisplay display)
        {
            _display = display;
        }

        public void StartUI()
        {
            throw new System.NotImplementedException();
        }
    }
}