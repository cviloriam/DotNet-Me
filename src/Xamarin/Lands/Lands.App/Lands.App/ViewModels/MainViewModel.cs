namespace Lands.App.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public LandsViewModel LandsViewModel { get; set; }
        public MainViewModel()
        {
            instance = this;
            this.LoginViewModel = new LoginViewModel();
        }

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();

            return instance;
        }
        #endregion
    }
}