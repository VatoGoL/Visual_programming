using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Interactivity;
using System.ComponentModel;
using ReactiveUI;
using System.Reactive;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using lab_8.Models;

namespace lab_8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(bool makeItems = true)
        {
            if (makeItems)
            {
                ItemsPlanned = makeCardTODO();
                ItemsInWork = makeCardInWork();
                ItemsCompleted = makeCardCompleted();
            }
            else
            {
                ItemsPlanned = new ObservableCollection<Card>();
                ItemsInWork = new ObservableCollection<Card>();
                ItemsCompleted = new ObservableCollection<Card>();
            }
            ButtonAddImage = ReactiveCommand.Create<Card, Unit>((item) =>
            {
                OpenImage(item);
                return Unit.Default;
            });
            ButtonDeletePlanned = ReactiveCommand.Create<Card, Unit>((item) =>
            {
                ItemsPlanned.Remove(item);
                return Unit.Default;
            });
            ButtonDeleteInWork = ReactiveCommand.Create<Card, Unit>((item) =>
            {
                ItemsInWork.Remove(item);
                return Unit.Default;
            });
            ButtonDeleteCompleted = ReactiveCommand.Create<Card, Unit>((item) =>
            {
                ItemsCompleted.Remove(item);
                return Unit.Default;
            });
        }
        ObservableCollection<Card> itemsPlanned;
        public ObservableCollection<Card> ItemsPlanned
        {
            get { return itemsPlanned; }
            set { this.RaiseAndSetIfChanged(ref itemsPlanned, value); }
        }
        ObservableCollection<Card> itemsInWork;
        public ObservableCollection<Card> ItemsInWork
        {
            get { return itemsInWork; }
            set { this.RaiseAndSetIfChanged(ref itemsInWork, value); }
        }
        ObservableCollection<Card> itemsCompleted;
        public ObservableCollection<Card> ItemsCompleted
        {
            get { return itemsCompleted; }
            set { this.RaiseAndSetIfChanged(ref itemsCompleted, value); }
        }
        private ObservableCollection<Card> makeCardTODO()
        {
            return new ObservableCollection<Card>
            {
                new Card("Поездка группы-докладчиков", "Забронировать номера в гостинице для докладчиков по теме 'Цифровая инженерия'"),
                new Card("Аренда серверов", "Решить вопрос с арендой серверов для приложений IsbushkaGramm"),
                new Card("Цикл разработки", "Согласовать цикл разработки приложения, пример приложен ниже:",
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + "/Assets/bstudio_1_big.jpg")
            };
        }
        private ObservableCollection<Card> makeCardInWork()
        {
            return new ObservableCollection<Card>
            {
                new Card("разработка окон 1", "Разработка основных окон приложения"),
                new Card("Разработка иерархии классов", "Разработка иерархии классов основных объектов",
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + "/Assets/tree.png")
            };
        }
        private ObservableCollection<Card> makeCardCompleted()
        {
            return new ObservableCollection<Card>
            {

                new Card("Дизайн макет приложения", "Разработать дизайн макета приложения",
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + "/Assets/travel_now.jpg"),
                
            };
        }
        public ReactiveCommand<Card, Unit> ButtonAddImage { get; }
        public ReactiveCommand<Card, Unit> ButtonDeletePlanned { get; }
        public ReactiveCommand<Card, Unit> ButtonDeleteInWork { get; }
        public ReactiveCommand<Card, Unit> ButtonDeleteCompleted { get; }
        private async void OpenImage(Card item)
        {
            string? path;
            string[]? pathArray = null;
            var taskPath = new OpenFileDialog()
            {
                Title = "Open file",
                Filters = new List<FileDialogFilter>()
            };
            taskPath.Filters.Add
                (new FileDialogFilter() { Name = "image", Extensions = { "png", "ico", "jpg", "jpeg", "jpe" } });

            pathArray = await taskPath.ShowAsync(view);
            path = pathArray is null ? null : string.Join(@"\", pathArray);
            if (path != null)
            {
                item.Image = new Bitmap(path);
            }
        }
        public Window? view = null;
    }
}