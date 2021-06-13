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
    /// Interaction logic for VehicleListPage.xaml
    /// </summary>
    public partial class VehicleListPage : Page
    {
        private VehicleListViewModel _viewmodel = null;
        public VehicleListPage()
        {
            InitializeComponent();
            _viewmodel = new VehicleListViewModel();
            this.DataContext = _viewmodel;
        }
        public VehicleListPage(List<string> listurl)
        {
            InitializeComponent();

            _viewmodel = new VehicleListViewModel(listurl);
            _viewmodel.ShowDetail = NavigateUI;

            this.DataContext = _viewmodel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_viewmodel.VehicleList == null || !_viewmodel.VehicleList.Any())
            {
                _viewmodel.GetVehicleList();
            }
        }
        private void NavigateUI()
        {
           this.NavigationService.Navigate(new VehicleDetailsPage(_viewmodel.SelectedVehicle));
        }
    }
}
