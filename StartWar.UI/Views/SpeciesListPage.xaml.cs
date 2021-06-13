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
    /// Interaction logic for SpeciesListPage.xaml
    /// </summary>
    public partial class SpeciesListPage : Page
    {
        private SpeciesListViewModel _viewmodel = null;
        public SpeciesListPage()
        {
            InitializeComponent();
            _viewmodel = new SpeciesListViewModel();
            this.DataContext = _viewmodel;
        }
        public SpeciesListPage(List<string> listurl)
        {
            InitializeComponent();

            _viewmodel = new SpeciesListViewModel(listurl);
            _viewmodel.ShowPeople = NavigateUI;

            this.DataContext = _viewmodel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_viewmodel.SpeciesList == null || !_viewmodel.SpeciesList.Any())
            {
                _viewmodel.GetSpeciesList();
            }
        }
        private void NavigateUI()
        {
            this.NavigationService.Navigate(new SpeciesDetailsPage(_viewmodel.SelectedSpecies));
        }
    }
}
