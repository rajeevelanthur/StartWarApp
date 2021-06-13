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
    public class VehicleListViewModel : INotifyPropertyChanged
    {

        private List<string> _vehicleListURLs = null;
        private List<Vehicles> _vehicleList = null;
        private Vehicles _selectedVehicle = null;

        public Action ShowDetail { get; set; }
        public VehicleListViewModel()
        {

        }
        public VehicleListViewModel(List<string> vehicles)
        {
            _vehicleListURLs = vehicles;
        }

        public List<Vehicles> VehicleList
        {
            get
            {
                return _vehicleList;
            }
            set
            {
                _vehicleList = value;
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
        public Vehicles SelectedVehicle
        {
            get
            {
                return _selectedVehicle;
            }
            set
            {
                _selectedVehicle = value;
                NotifyPropertyChanged("SelectedVehicle");
            }
        }
        public async void GetVehicleList()
        {
            IsLoading = true;
            var httpService = new HttpHelperService<Vehicles>();
            _vehicleList = new List<Vehicles>();
            if (_vehicleListURLs != null && _vehicleListURLs.Any())
            {
                foreach (var url in _vehicleListURLs)
                {
                    var qryurl = Utility.GetURLPart(url);
                    var ppl = await httpService.Get(qryurl);
                    if (ppl != null)
                    {
                        _vehicleList.Add(ppl);

                    }
                }
                NotifyPropertyChanged("VehicleList");

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
