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
    /// Interaction logic for PlanetDetailPage.xaml
    /// </summary>
    public partial class PlanetDetailPage : Page
    {
        private PlanetDetailViewModel _viewModel = null;
        public PlanetDetailPage()
        {
            InitializeComponent();
            _viewModel = new PlanetDetailViewModel();
            this.DataContext = _viewModel;
        }
        public PlanetDetailPage(PlanetDetailViewModel vmModel)
        {
            InitializeComponent();
            _viewModel = vmModel;
            this.DataContext = _viewModel;
        }
        public PlanetDetailPage(Planet starship)
        {
            InitializeComponent();
            _viewModel = new PlanetDetailViewModel(starship);
            _viewModel.NavigateTo = NavigateUI;
            this.DataContext = _viewModel;
        }

        private void NavigateUI(string type)
        {
            switch (type)
            {
                case Constant.peoplelist:
                    {
                        this.NavigationService.Navigate(new PoepleListPage(_viewModel.Planet.Residents));
                        break;
                    }
                default:
                    this.NavigationService.Navigate(new PoepleListPage(_viewModel.Planet.Residents));
                    break;
            }

        }
    }
}
