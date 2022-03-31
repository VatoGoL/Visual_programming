using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab_7.ViewModels;
using lab_7.Models;

namespace lab_7.Views
{
    public partial class New_Students : Window
    {
        public New_Students()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OK").Click += async delegate
            {
                var context = this.DataContext as Add_StudentsViewModel;
                context.StudentToReturn.PropertyChanged -=
                context.resetEnable;
                Close(new Student(context.StudentToReturn));
            };
            this.FindControl<Button>("Cancel").Click += async delegate
            {
                Close(null);
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new Add_StudentsViewModel();
        }
    }
}
