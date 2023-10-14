using DrawBoard.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DrawBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        public App()
        {
            //_ = InstallCheck();
        }

        private async Task InstallCheck()
        {
            await new InstallHelper().InstallNET6Async();
        }
    }
}
