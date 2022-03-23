using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using Lab_6.Models;

namespace Lab_6.ViewModels
{
    public class TitleViewModel : ViewModelBase
    {
        public TitleViewModel(List<ToDoElement> ItemsAll)
        {
            itemsAll = ItemsAll;
            currentDate = DateTime.Today;
            changeItems();
        }
        public void changeItems()
        {
            items.Clear();
            foreach (var item in itemsAll)
            {
                if (item.Date.Equals(CurrentDate)) items.Add(item);
            }
            ItemsSelected = new ObservableCollection<ToDoElement>(items);
        }

        public ObservableCollection<ToDoElement> itemsSelected;
        public ObservableCollection<ToDoElement> ItemsSelected
        {
            get
            {
                return itemsSelected;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref itemsSelected, value);
            }
        }
        private List<ToDoElement> items = new List<ToDoElement>();
        private List<ToDoElement> itemsAll;
        DateTimeOffset currentDate;
        public DateTimeOffset CurrentDate
        {
            get { return currentDate; }
            set
            {
                this.RaiseAndSetIfChanged(ref currentDate, value);
                changeItems();
            }
        }
    }
}

