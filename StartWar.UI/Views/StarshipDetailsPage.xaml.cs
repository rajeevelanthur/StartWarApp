using StartWar.UI.Utilities;
using StartWar.UI.ViewModel;
using StarWar.Model;
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
    /// Interaction logic for StarshipDetailsPage.xaml
    /// </summary>
    public partial class StarshipDetailsPage : Page
    {
        private StarShipDetailViewModel _viewModel = null;
        public StarshipDetailsPage()
        {
            InitializeComponent();
            _viewModel = new StarShipDetailViewModel();
            this.DataContext = _viewModel;
        }
        public StarshipDetailsPage(StarShipDetailViewModel vmModel)
        {
            InitializeComponent();
            _viewModel = vmModel;
            this.DataContext = _viewModel;
        }
        public StarshipDetailsPage(Starship starship)
        {
            InitializeComponent();
            _viewModel = new StarShipDetailViewModel(starship);
            _viewModel.NavigateTo = NavigateUI;
            this.DataContext = _viewModel;
        }

        private void NavigateUI(string type)
        {
            switch (type)
            {
                case Constant.peoplelist:
                    {
                        this.NavigationService.Navigate(new PoepleListPage(_viewModel.StarShip.Pilots));
                        break;
                    }
                default:
                    this.NavigationService.Navigate(new PoepleListPage(_viewModel.StarShip.Pilots));
                    break;
            }

        }
    }
}
