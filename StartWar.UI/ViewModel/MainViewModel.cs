using StartWar.UI.Service;
using StartWar.UI.Views;
using StarWar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StartWar.UI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

            //Change on 31/01/2022
            //(FrameContent.Parent as Frame).NavigationService.Navigate(new FilmDetailView());
            //FrameContent.NavigationService.Navigate(new FilmDetailView());
            this.GetFilmList();
            //FrameContent = new FilmDetailView();
        }
        private int _count = 0;
        private string _next = string.Empty;
        private string _previous = string.Empty;
        private List<Films> _films = null;
        private Page _page = new Page();
        private Films _selectedFilm = null;
        public List<Films> Films
        {
            get
            {
                return _films;
            }
            set
            {
                _films = value;
                NotifyPropertyChanged("Films");
            }
        }
        public Page FrameContent
        {
            get
            {
                
                return _page;
            }

            set
            {
                _page = value;
                NotifyPropertyChanged("FrameContent");
            }
        }
        private bool _isLoading = false;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                NotifyPropertyChanged("IsLoading");
            }
        }

        public Films SelectedFilm
        {
            get
            {

                return _selectedFilm;
            }

            set
            {
                _selectedFilm = value;
                ShowFilmDetail();
                NotifyPropertyChanged("SelectedFilm");
            }
        }

        public async void GetFilmList()
        {
            IsLoading = true;
            var httpService = new HttpHelperService<Films>();
            var films = await httpService.GetList("films");
            if (films != null)
            {
                _films = films.Results;
                NotifyPropertyChanged("Films");
                SelectedFilm = _films[0];
            }
            IsLoading = false;

        }
        private void ShowFilmDetail()
        {
            FrameContent = new FilmDetailView(SelectedFilm);
        }

        // public FilmListViewModel FlmListViewModel { get; set; } = new FilmListViewModel();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
