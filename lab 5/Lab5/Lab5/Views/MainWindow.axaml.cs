using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Lab5.ViewModels;

namespace Lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Find<Button>("OpFile").Click += async delegate
            {
                var Plan = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await Plan;

                var context = this.DataContext as MainWindowViewModel;
                if(path != null)
                {
                    context.pathOpenFile = string.Join(@"\", path);
                }
                
            };

            this.Find<Button>("SvFile").Click += async delegate
            {
                var Plan = new SaveFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string path = await Plan;

                var context = this.DataContext as MainWindowViewModel;
                if(path != null)
                {
                    context.pathSaveFile = path;
                }
                
            };
            

        }

        private async void MyClickEventHandler(object sender, RoutedEventArgs e)
        {
            var x = new RegexWindow();
            x.DataContext = this.DataContext as MainWindowViewModel;
            x.ShowDialog((Window)this.VisualRoot);
        }
    }
}
