using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using LoginControl;
using MainAppSample.Interface;

namespace MainAppSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IDialogService _ds;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var actualMainWindow = new MainWindow();

            int maxTries = 5;
            int trycount = 0;
            while (!CredentialHolder.Singleton.IsAuthenticated)
            {
                var authWindow = new AuthenticationWindow();
                authWindow.ShowDialog();
                trycount++;
                if (trycount >= maxTries) break;
            }

            if (CredentialHolder.Singleton.IsAuthenticated)
            {
                actualMainWindow.ShowDialog();
            }
            else
            {
                _ds?.ShowError("授权失败，应用将关闭！", "错误信息", "OK");
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Close();
                }
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //_ds = Ioc.Default.GetService<IDialogService>();
            base.OnStartup(e);
        }

        private void ContainerRegistration()
        {

        }
    }
}
