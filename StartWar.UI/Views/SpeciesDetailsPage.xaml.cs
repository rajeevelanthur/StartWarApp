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
    /// Interaction logic for SpeciesDetailsPage.xaml
    /// </summary>
    public partial class SpeciesDetailsPage : Page
    {
        private SpeciesDetailViewModel _viewModel = null;
        public SpeciesDetailsPage()
        {
            InitializeComponent();
            _viewModel = new SpeciesDetailViewModel();
            this.DataContext = _viewModel;
        }
        public SpeciesDetailsPage(SpeciesDetailViewModel vmModel)
        {
            InitializeComponent();
            _viewModel = vmModel;
            this.DataContext = _viewModel;
        }
        public SpeciesDetailsPage(Species species)
        {
            InitializeComponent();
            _viewModel = new SpeciesDetailViewModel(species);
            _viewModel.NavigateTo = NavigateUI;
            this.DataContext = _viewModel;
        }

        private void NavigateUI(string type)
        {
            switch (type)
            {
                case Constant.peoplelist:
                    {
                        this.NavigationService.Navigate(new PoepleListPage(_viewModel.Species.People));
                        break;
                    }
                default:
                    this.NavigationService.Navigate(new PoepleListPage(_viewModel.Species.People));
                    break;
            }

        }
    }
}
