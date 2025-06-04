using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class Box : StorageItem
    {
        private DateOnly? _expirationDate;
        public DateOnly? ProductionDate { get; set; }

        public DateOnly? ExpirationDate { 
            get {
                if (_expirationDate.HasValue)
                {
                    return _expirationDate.Value;
                }
                if (ProductionDate.HasValue)
                {
                    return ProductionDate.Value.AddDays(100);
                }
                return null; 
            }
            set { _expirationDate = value; }
        }
        public bool IsItFitsPalletSize(Pallet pallet)
        {
            return Width <= pallet.Width && Depth <= pallet.Depth;
        }
        public string FormattedExpiration => ExpirationDate?.ToString("dd.MM.yyyy") ?? "Без срока";
    }
}
