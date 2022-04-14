using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace lab_9.Models
{
    public class ElementImage : FileElement
    {
        public ElementImage(FileElement item)
        {
            NameEl = item.NameEl;
            PathEl = item.PathEl;
            ImageBitmap = new Bitmap(PathEl);
        }
        public Bitmap ImageBitmap { get; set; }
    }
}