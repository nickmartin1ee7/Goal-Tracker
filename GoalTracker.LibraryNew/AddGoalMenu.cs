namespace GoalTracker.LibraryNew
{
    public class AddGoalMenu : IMenu
    {
        private IDisplay _display;
        private IDataContext _dataContext { get; set; }

        public AddGoalMenu(IDisplay display, IDataContext dataContext)
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