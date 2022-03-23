using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using ReactiveUI;
using Lab_6.Models;

namespace Lab_6.ViewModels
{
    public class ToDoViewModel : ViewModelBase
    {
        public ToDoViewModel(ToDoElement item)
        {
            Title = item.Title;
            Text = item.Text;
            var okEnabled = this.WhenAnyValue(
                    element => element.Title,
                    element => !string.IsNullOrWhiteSpace(element));

            OK = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    item.Title = Title;
                    item.Text = Text;
                    return Unit.Default;
                }, okEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }
        string title;
        string text;
        public string Title
        {
            get { return title; }
            set { this.RaiseAndSetIfChanged(ref title, value); }
        }
        public string Text
        {
            get { return text; }
            set { this.RaiseAndSetIfChanged(ref text, value); }
        }
        public ReactiveCommand<Unit, Unit> OK { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}