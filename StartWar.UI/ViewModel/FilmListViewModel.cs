using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartWar.UI.Service;
using StarWar.Model;

namespace StartWar.UI.ViewModel
{
    public class FilmListViewModel : INotifyPropertyChanged
    {
        public FilmListViewModel()
        {
            GetFilmList();
        }
        private int _count = 0;
        private string _next = string.Empty;
        private string _previous = string.Empty;
        private List<Films> _films = null;
        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                _count = value;
                NotifyPropertyChanged("Count");
            }
        }
        public string Next
        {
            get
            {
                return _next;
            }

            set
            {
                _next = value;
                NotifyPropertyChanged("Next");
            }
        }
        public string Previous
        {
            get
            {
                return _previous;
            }
            set
            {
                _previous = value;
                NotifyPropertyChanged("Previous");
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

        public async void GetFilmList()
        {
            var httpService = new HttpHelperService<Films>();
            var films = await httpService.GetList("films");
            if(films!=null)
            {
                _films = films.Results;
                NotifyPropertyChanged("Films");
            }

        }
        

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
