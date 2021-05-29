using GalaSoft.MvvmLight.Command;
using Lands.App.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;

        public string Email 
        {
            get { return this._email; }
            set { SetValue(ref this._email, value); }
        }
        public string Password 
        {
            get { return this._password; }
            set { SetValue(ref this._password, value); }
        }
        public bool IsRunning 
        {
            get { return this._isRunning; }
            set { SetValue(ref this._isRunning, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled 
        {
            get { return this._isEnabled; }
            set { SetValue(ref this._isEnabled, value); }
        }
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept"
                    );
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if ((this.Email != "cviloria") || (this.Password != "1234")) 
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept"
                    );

                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().LandsViewModel = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
    }
}