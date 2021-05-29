using Lands.App.ViewModels;

namespace Lands.App.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel MainViewModel { get; set; }

        public InstanceLocator()
        {
            this.MainViewModel = new MainViewModel();
        }
    }
}