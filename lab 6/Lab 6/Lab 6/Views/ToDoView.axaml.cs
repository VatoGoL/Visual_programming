using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab_6.Views
{
    public partial class ToDoView : UserControl
    {
        public ToDoView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
