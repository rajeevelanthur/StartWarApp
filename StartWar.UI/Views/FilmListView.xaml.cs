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
    /// Interaction logic for FilmListView.xaml
    /// </summary>
    public partial class FilmListView : UserControl
    {
        private FilmListViewModel _filmListViewModel = null;
        public FilmListView()
        {
            InitializeComponent();
            _filmListViewModel = new FilmListViewModel();
            this.DataContext = _filmListViewModel;

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
