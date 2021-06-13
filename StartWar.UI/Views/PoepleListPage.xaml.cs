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
    /// Interaction logic for PoepleListPage.xaml
    /// </summary>
    public partial class PoepleListPage : Page
    {
        private PeopleListViewModel _viewmodel = null;
        public PoepleListPage()
        {
            InitializeComponent();
            _viewmodel = new PeopleListViewModel();
            this.DataContext = _viewmodel;
        }
        public PoepleListPage(List<string> listurl)
        {
            InitializeComponent();
           
            _viewmodel = new PeopleListViewModel(listurl);
            _viewmodel.ShowPeople = NavigateUI;
            this.DataContext = _viewmodel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_viewmodel.PeopleList==null || !_viewmodel.PeopleList.Any())
            {
                _viewmodel.GetPeopleList();
            }
        }
        private void NavigateUI()
        {
           this.NavigationService.Navigate(new PeopleDetails(_viewmodel.SelectedPeople));
        }
    }
}
