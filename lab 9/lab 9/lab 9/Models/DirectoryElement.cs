using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9.Models
{
    public class DirectoryElement : Element
    {
        public ObservableCollection<Element> Items { get; set; }
        public DirectoryElement()
        {
            Items = new ObservableCollection<Element>();
        }
    }
}