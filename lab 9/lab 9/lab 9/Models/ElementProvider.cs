using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_9.Models
{
    public class ElementProvider
    {
        public ObservableCollection<Element> GetItems(string path)
        {
            var items = new ObservableCollection<Element>();

            var dirInfo = new DirectoryInfo(path);

            foreach (var directory in dirInfo.GetDirectories())
            {
                var item = new DirectoryElement
                {
                    NameEl = directory.Name,
                    PathEl = directory.FullName,
                    Items = GetItems(directory.FullName)
                };

                items.Add(item);
            }

            foreach (var file in dirInfo.GetFiles())
            {
                var item = new FileElement
                {
                    NameEl = file.Name,
                    PathEl = file.FullName
                };

                items.Add(item);
            }

            return items;
        }
        public ObservableCollection<Element> GetFilesNoRecursion(string path)
        {
            var items = new ObservableCollection<Element>();

            var dirInfo = new DirectoryInfo(path);

            foreach (var file in dirInfo.GetFiles())
            {
                var item = new FileElement
                {
                    NameEl = file.Name,
                    PathEl = file.FullName
                };

                items.Add(item);
            }
            return items;
        }
    }
}
