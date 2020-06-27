namespace GoalTracker.LibraryNew
{
    internal class ViewGoalMenu : IMenu
    {
        private IDisplay _display;

        public ViewGoalMenu(IDisplay display)
        {
            _display = display;
        }

        public void StartUI()
        {
            throw new System.NotImplementedException();
        }
    }
}