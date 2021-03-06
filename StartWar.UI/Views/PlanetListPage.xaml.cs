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
    /// Interaction logic for PlanetListPage.xaml
    /// </summary>
    public partial class PlanetListPage : Page
    {
        private PlanetListViewModel _viewmodel = null;
        public PlanetListPage()
        {
            InitializeComponent();
            _viewmodel = new PlanetListViewModel();
            this.DataContext = _viewmodel;
        }
        public PlanetListPage(List<string> listurl)
        {
            InitializeComponent();

            _viewmodel = new PlanetListViewModel(listurl);
            _viewmodel.ShowPeople = NavigateUI;

            this.DataContext = _viewmodel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_viewmodel.PlanetList == null || !_viewmodel.PlanetList.Any())
            {
                _viewmodel.GetPlanetList();
            }
        }
        private void NavigateUI()
        {
            this.NavigationService.Navigate(new PlanetDetailPage(_viewmodel.SelectedPlanet));
        }
    }
}
