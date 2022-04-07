using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab_8.Views
{
    public partial class AboutView : Window
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
