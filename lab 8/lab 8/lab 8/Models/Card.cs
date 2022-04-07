using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.IO;
using System.Reflection;

namespace lab_8.Models
{
    public class Card : INotifyPropertyChanged
    {
        public Card()
        {
        }
        public Card(string n = "", string d = "", string? p = null)
        {
            Name = n;
            Description = d;
            if (p is not null)
            {
                ImagePath = p;
            }
        }
        string name = "";
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        string description = "";
        public string Description
        {
            get => description;
            set
            {
                description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }
        Bitmap? image = null;
        public Bitmap? Image
        {
            get => image;
            set
            {
                image = value;
                NotifyPropertyChanged(nameof(Image));
            }
        }
        string? imagePath = null;
        public string? ImagePath
        {
            get => imagePath;
            set
            {
                try
                {
                    var bm = new Bitmap(value);
                }
                catch (Exception ex)
                {
                    return;
                }
                imagePath = value;
                Image = new Bitmap(value);
                NotifyPropertyChanged(nameof(ImagePath));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
