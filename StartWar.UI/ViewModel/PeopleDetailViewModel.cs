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
    public class PeopleDetailViewModel : INotifyPropertyChanged
    {
        private People _people = null;
        public Action<string> NavigateTo { get; set; }
        public PeopleDetailViewModel()
        {

        }
        public PeopleDetailViewModel(People people)
        {
            _people = people;
        }
        public People People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                NotifyPropertyChanged("People");
            }
        }
        public ICommand ShowVehiclesCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigateTo(Constant.vehicleslist);
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
