using StartWar.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartWar.UI.Views
{
    /// <summary>
    /// Interaction logic for StarShipListPage.xaml
    /// </summary>
    public partial class StarShipListPage : Page
    {
        private StartShipListViewModel _viewmodel = null;
        public StarShipListPage()
        {
            InitializeComponent();
            _viewmodel = new StartShipListViewModel();
            this.DataContext = _viewmodel;
        }
        public StarShipListPage(List<string> listurl)
        {
            InitializeComponent();

            _viewmodel = new StartShipListViewModel(listurl);
            _viewmodel.ShowDetail = NavigateUI;

            this.DataContext = _viewmodel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_viewmodel.StarShipList == null || !_viewmodel.StarShipList.Any())
            {
                _viewmodel.GetStarShipList();
            }
        }
        private void NavigateUI()
        {
            this.NavigationService.Navigate(new StarshipDetailsPage(_viewmodel.SelectedStarShip));
        }
    }
}
