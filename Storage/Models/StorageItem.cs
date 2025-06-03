using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    abstract public class StorageItem
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public double Width { get; set; }
        public double Height { get; set; } 
        public double Depth { get; set; }
        public virtual double Weight { get; set; }
        public double Volume => Math.Round(Width * Height * Depth, 2);
    }
}
