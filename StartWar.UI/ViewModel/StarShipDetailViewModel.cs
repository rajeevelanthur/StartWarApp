
using Prism.Commands;
using StartWar.UI.Service;
using StartWar.UI.Utilities;
using StartWar.UI.Views;
using StarWar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace StartWar.UI.ViewModel
{
    public class StarShipDetailViewModel : INotifyPropertyChanged
    {
        private Starship _startship = null;
        public Action<string> NavigateTo { get; set; }
        public StarShipDetailViewModel()
        {

        }
        public StarShipDetailViewModel(Starship startship)
        {
            _startship = startship;
        }
        public Starship StarShip
        {
            get
            {
                return _startship;
            }
            set
            {
                _startship = value;
                NotifyPropertyChanged("StarShip");
            }
        }
        public ICommand ShowPeopleCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigateTo(Constant.peoplelist);
                });
            }

        }
        public ICommand ShowStarShipsCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigateTo(Constant.starshiplist);
                });
            }

        }
        public ICommand ShowPlanetsCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigateTo(Constant.planetlist);
                });
            }

        }
        public ICommand ShowSpeciesCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigateTo(Constant.specieslist);
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


