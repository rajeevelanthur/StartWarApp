using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using StartWar.UI.Service;
using StartWar.UI.Utilities;
using StarWar.Model;

namespace StartWar.UI.ViewModel
{
    public class PlanetListViewModel : INotifyPropertyChanged
    {

        private List<string> _planetListURLs = null;
        private List<Planet> _planetList = null;
        private Planet _selectedVehicle = null;

        public Action ShowPeople { get; set; }
        public PlanetListViewModel()
        {

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
        public PlanetListViewModel(List<string> planets)
        {
            _planetListURLs = planets;
        }

        public List<Planet> PlanetList
        {
            get
            {
                return _planetList;
            }
            set
            {
                _planetList = value;
                NotifyPropertyChanged("PlanetList");
            }
        }
        public Planet SelectedPlanet
        {
            get
            {
                return _selectedVehicle;
            }
            set
            {
                _selectedVehicle = value;
                NotifyPropertyChanged("SelectedPlanet");
            }
        }
        public async void GetPlanetList()
        {
            IsLoading = true;
            var httpService = new HttpHelperService<Planet>();
            _planetList = new List<Planet>();
            if (_planetListURLs != null && _planetListURLs.Any())
            {
                foreach (var url in _planetListURLs)
                {
                    var qryurl = Utility.GetURLPart(url);
                    var ppl = await httpService.Get(qryurl);
                    if (ppl != null)
                    {
                        _planetList.Add(ppl);

                    }
                }
                NotifyPropertyChanged("PlanetList");

            }
            IsLoading = false;
        }
        public ICommand ShowMore
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ShowPeople();
                });
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
