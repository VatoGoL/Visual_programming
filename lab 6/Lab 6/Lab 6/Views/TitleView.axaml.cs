using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab_6.Views
{
    public partial class TitleView : UserControl
    {
        public TitleView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
