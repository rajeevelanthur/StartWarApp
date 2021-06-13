using Prism.Commands;
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
using System.Windows.Input;

namespace StartWar.UI.ViewModel
{
    public class FilmDetailViewModel : INotifyPropertyChanged
    {

        public FilmDetailViewModel()
        {
           
        }
        public FilmDetailViewModel(Films film)
        {
            _film = film;   
        }

        private Films _film = new Films();
        private Page _listContentFrame = new Page();

        public Films Film
        {
            get
            {
                return _film;
            }
            set
            {
                _film = value;
                NotifyPropertyChanged("Film");
            }
        }
        public Page ListContentFrame
        {
            get
            {

                return _listContentFrame;
            }

            set
            {
                _listContentFrame = value;
                NotifyPropertyChanged("ListContentFrame");
            }
        }
        public ICommand ShowActorsCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ListContentFrame = null;

                    ListContentFrame = new PoepleListPage(_film.Characters);
                });
            }

        }
        public ICommand ShowVehiclesCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ListContentFrame = null;

                    ListContentFrame = new VehicleListPage(_film.Vehicles);
                });
            }

        }
        public ICommand ShowStarShipsCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ListContentFrame = null;

                    ListContentFrame = new StarShipListPage(_film.Starships);
                });
            }

        }
        public ICommand ShowPlanetsCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ListContentFrame = null;
                    ListContentFrame = new PlanetListPage(_film.Planets);
                });
            }

        }
        public ICommand ShowSpeciesCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ListContentFrame = null;

                    ListContentFrame = new SpeciesListPage(_film.Species);
                });
            }

        }
        //



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
