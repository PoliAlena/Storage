using Storage.Models;
using Storage.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Storage.ViewModels
{
    public class PalletsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Pallet> Pallets { get; set; }
        public ObservableCollection<Pallet> TopThreePallets { get; set; }
        public CollectionViewSource GroupedPallets { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PalletsListViewModel()
        {
            try
            {
                var dataService = new DataService();
                //Базовое отображение всех паллет
                var pallets = dataService.LoadPallets();
                //3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема
                var top3 = pallets
                    .Where(p => p.ExpirationDate.HasValue)
                    .OrderByDescending(p => p.ExpirationDate.Value)
                    .Take(3)
                    .OrderBy(p => p.TotalPalletVolume);

                Pallets = new ObservableCollection<Pallet>(pallets);
                TopThreePallets = new ObservableCollection<Pallet>(top3);
                GroupedPallets = new CollectionViewSource
                {
                    Source = Pallets
                };
            }
            catch(Exception ex) 
            {
                 MessageBox.Show(ex.ToString());
            }
          
        }

        public void GroupAndSort()
        {
            var groupedSorted = Pallets
                .OrderBy(p => p.ExpirationDate) //Срок годности
                .ThenBy(p => p.Weight) //Вес
                .ToList();

            Pallets.Clear();
            foreach (var p in groupedSorted)
                Pallets.Add(p);

            GroupedPallets.GroupDescriptions.Clear();
            //Добавление описания к группам паллет с датой, по которой они сгруппированы
            GroupedPallets.GroupDescriptions.Add(new PropertyGroupDescription("FormattedExpiration"));
            GroupedPallets.View.Refresh();
        }
    }
}