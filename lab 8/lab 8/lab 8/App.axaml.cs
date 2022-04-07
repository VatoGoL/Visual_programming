using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using lab_8.ViewModels;
using lab_8.Views;

namespace lab_8
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                (desktop.MainWindow.DataContext as MainWindowViewModel).view = desktop.MainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
