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
    /// Interaction logic for FilmDetailView.xaml
    /// </summary>
    public partial class FilmDetailView : Page
    {
        private FilmDetailViewModel _filmDetail;
        public FilmDetailView()
        {
            InitializeComponent();
            _filmDetail = new FilmDetailViewModel();
            this.DataContext = _filmDetail;
        }
        public FilmDetailView(Films film)
        {
            InitializeComponent();
            _filmDetail = new FilmDetailViewModel(film);
            this.DataContext = _filmDetail;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PeopleDetails());
        }
    }
}
;