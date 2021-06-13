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
    public class StartShipListViewModel : INotifyPropertyChanged
    {
        private List<string> _starshipListURLs = null;
        private List<Starship> _starshipList = null;
        private Starship _selectedStarShip= null;

        public Action ShowDetail { get; set; }
        public StartShipListViewModel()
        {

        }
        public StartShipListViewModel(List<string> strships)
        {
            _starshipListURLs = strships;
        }

        public List<Starship> StarShipList
        {
            get
            {
                return _starshipList;
            }
            set
            {
                _starshipList = value;
                NotifyPropertyChanged("VehicleList");
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
        public Starship SelectedStarShip
        {
            get
            {
                return _selectedStarShip;
            }
            set
            {
                _selectedStarShip = value;
                NotifyPropertyChanged("SelectedVehicle");
            }
        }
        public async void GetStarShipList()
        {
            IsLoading = true;
            var httpService = new HttpHelperService<Starship>();
            _starshipList = new List<Starship>();
            if (_starshipListURLs != null && _starshipListURLs.Any())
            {
                foreach (var url in _starshipListURLs)
                {
                    var qryurl = Utility.GetURLPart(url);
                    var ppl = await httpService.Get(qryurl);
                    if (ppl != null)
                    {
                        _starshipList.Add(ppl);

                    }
                }
                NotifyPropertyChanged("StarShipList");

            }
            IsLoading = false;
        }
        public ICommand ShowMore
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ShowDetail();
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
