using Storage.Models;
using Storage.Services;
using Storage.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Storage.Pages
{
    /// <summary>
    /// Логика взаимодействия для PalletsList.xaml
    /// </summary>
    public partial class PalletsList : Page
    {
        public PalletsList()
        {
            InitializeComponent();
        }

        private void GroupPalletsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is PalletsListViewModel vm) {
                vm.GroupAndSort();
            }        
        }
    }
}
