using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Lab5.ViewModels;

namespace Lab5.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            

            this.Find<Button>("OkButton").Click += delegate
            {
                (this.DataContext as MainWindowViewModel).RegularStart = true;
                Close();
            };
            this.Find<Button>("CancelButton").Click += delegate
            {
                (this.DataContext as MainWindowViewModel).RegularStart = false;
                Close();
            };
        }

        

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

        }
    }
}
