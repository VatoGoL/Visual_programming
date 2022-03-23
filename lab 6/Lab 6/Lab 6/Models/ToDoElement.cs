using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.Models
{
    public class ToDoElement
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }

        public ToDoElement(string name, string todo, DateTimeOffset date)
        {
            Title = name;
            Text = todo;
            Date = date;
        }

        public override string ToString()
        {
            return Title + " " + Text + " " + Date.ToString();
        }
    }
}
