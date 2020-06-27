namespace GoalTracker.LibraryNew
{
    internal class AddGoalMenu : IMenu
    {
        private IDisplay _display;

        public AddGoalMenu(IDisplay display)
        {
            _display = display;
        }

        public void StartUI()
        {
            throw new System.NotImplementedException();
        }
    }
}