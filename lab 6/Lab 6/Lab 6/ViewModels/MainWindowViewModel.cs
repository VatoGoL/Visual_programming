using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using Lab_6.Models;

namespace Lab_6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<ToDoElement> ItemsAll { get; set; }

        ViewModelBase content;
        public MainWindowViewModel()
        {
            ButAdd = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    var newItem = new ToDoElement("", "", Fv.CurrentDate);
                    var sv = new ToDoViewModel(newItem);
                    Observable.Merge(
                    sv.OK,
                    sv.Cancel.Select(_ => Unit.Default))
                    .Take(1)
                    .Subscribe(unit =>
                    {
                        ItemsAll.Add(newItem);
                        Fv.changeItems();
                        Content = Fv;
                    });
                    Content = sv;
                    return Unit.Default;
                });
            ButZoom = ReactiveCommand.Create<ToDoElement, Unit>(
                (item) =>
                {
                    var sv = new ToDoViewModel(item);
                    Observable.Merge(
                sv.OK,
                sv.Cancel.Select(_ => Unit.Default))
                .Take(1)
                .Subscribe(unit =>
                {
                    Fv.changeItems();
                    Content = Fv;
                });
                    Content = sv;
                    return Unit.Default;
                });
            ButDelete = ReactiveCommand.Create<ToDoElement, Unit>((item) =>
            {
                ItemsAll.Remove(item);
                Fv.changeItems();
                return Unit.Default;
            });
            ItemsAll = BuildPlans();
            Content = Fv = new TitleViewModel(ItemsAll);
        }

        public ViewModelBase Content
        {
            set => this.RaiseAndSetIfChanged(ref content, value);
            get => content;
        }
        public TitleViewModel Fv
        {
            get;
        }
        public ReactiveCommand<Unit, Unit> ButAdd { get; }
        public ReactiveCommand<ToDoElement, Unit> ButZoom { get; }
        public ReactiveCommand<ToDoElement, Unit> ButDelete { get; }
        public ReactiveCommand<ToDoElement, Unit> ButOk { get; }
        public ReactiveCommand<ToDoElement, Unit> ButCancel { get; }
        private List<ToDoElement> BuildPlans()
        {
            return new List<ToDoElement>
            {
                new ToDoElement("�������","������\n���\n�������\n", DateTime.Today.AddDays(0)),
                new ToDoElement("�����","����", DateTime.Today.AddDays(0)),
                new ToDoElement("Element1","���-�� ��������", DateTime.Today.AddDays(0)),

                new ToDoElement("Element2_1","���-�� ��������", DateTime.Today.AddDays(1)),
                new ToDoElement("Element2_2","���-�� ��������", DateTime.Today.AddDays(1)),
                new ToDoElement("Element2_3","���-�� ��������", DateTime.Today.AddDays(1)),

                new ToDoElement("Element3_1","���-�� ��������", DateTime.Today.AddDays(2)),
                new ToDoElement("Element3_2","���-�� ��������", DateTime.Today.AddDays(2)),
                new ToDoElement("Element3_3","���-�� ��������", DateTime.Today.AddDays(2)),

                new ToDoElement("Element4_1","���-�� ��������", DateTime.Today.AddDays(3)),
                new ToDoElement("Element4_2","���-�� ��������", DateTime.Today.AddDays(3)),
                new ToDoElement("Element4_3","���-�� ��������", DateTime.Today.AddDays(3)),

                new ToDoElement("Element5_1","���-�� ��������", DateTime.Today.AddDays(4)),
                new ToDoElement("Element5_2","���-�� ��������", DateTime.Today.AddDays(4)),
                new ToDoElement("Element5_3","���-�� ��������", DateTime.Today.AddDays(4)),

            };
        }
    }
}
