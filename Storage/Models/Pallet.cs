using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class Pallet : StorageItem
    {
        public List<Box> Boxes { get; set; } = new List<Box>();
        public DateOnly? ExpirationDate { 
            get {   
                if (Boxes.Count == 0) return null;
                var BoxExpirationDate = Boxes.Where( x => x.ExpirationDate.HasValue ).Select( x => x.ExpirationDate.Value );
                return BoxExpirationDate.Any() ? BoxExpirationDate.Min() : null;
            } 
        } 
        public override double Weight {
            get { 
              double BoxecOnPalletWeight = Boxes.Sum(x => x.Weight);
                return BoxecOnPalletWeight + 30;
            }
        }
        public double TotalPalletVolume { 
            get { 
                double TotalBoxesVolume = Boxes.Sum(x => x.Volume);
                return Math.Round(base.Volume + TotalBoxesVolume, 2);
            } 
        }
        public string FormattedExpiration => ExpirationDate?.ToString("dd.MM.yyyy") ?? "Без срока";
    }
}
