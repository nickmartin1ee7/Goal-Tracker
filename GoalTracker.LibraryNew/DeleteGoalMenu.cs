namespace GoalTracker.LibraryNew
{
    public class DeleteGoalMenu : IMenu
    {
        private IDisplay _display;
        private IDataContext _dataContext { get; set; }

        public DeleteGoalMenu(IDisplay display, IDataContext dataContext)
        {
            _display = display;
            _dataContext = dataContext;
        }

        public void StartUI()
        {
            throw new System.NotImplementedException();
        }
    }
}