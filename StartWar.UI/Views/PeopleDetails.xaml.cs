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
    /// Interaction logic for PeopleDetails.xaml
    /// </summary>
    public partial class PeopleDetails : Page
    {
        private PeopleDetailViewModel _viewModel = null;
        public PeopleDetails()
        {
            InitializeComponent();
            _viewModel = new PeopleDetailViewModel();
            this.DataContext = _viewModel;
        }
        public PeopleDetails(PeopleDetailViewModel vmModel)
        {
            InitializeComponent();
            _viewModel = vmModel;
            this.DataContext = _viewModel;
        }
        public PeopleDetails(People people)
        {
            InitializeComponent();
            _viewModel = new PeopleDetailViewModel(people);
            _viewModel.NavigateTo = NavigateUI;
            this.DataContext = _viewModel;
        }

        private void NavigateUI(string type)
        {
            switch (type)
            {
                case Constant.vehicleslist:
                    {
                        this.NavigationService.Navigate(new VehicleListPage(_viewModel.People.Vehicles));
                        break;
                    }
                case Constant.planetlist:
                    {
                        this.NavigationService.Navigate(new PlanetListPage(new List<string>() { _viewModel.People.Homeworld }));
                        break;
                    }
                case Constant.starshiplist:
                    {
                        this.NavigationService.Navigate(new StarShipListPage(_viewModel.People.Starships));
                        break;
                    }
                case Constant.specieslist:
                    {
                        this.NavigationService.Navigate(new SpeciesListPage(_viewModel.People.Species));
                        break;
                    }
                default:
                    this.NavigationService.Navigate(new VehicleListPage(_viewModel.People.Vehicles));
                    break;
            }
           
        }
    }
}
