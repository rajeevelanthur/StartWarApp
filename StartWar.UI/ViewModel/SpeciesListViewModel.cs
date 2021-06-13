
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
    public class SpeciesListViewModel : INotifyPropertyChanged
    {
        private List<string> _speciesListURLs = null;
        private List<Species> _speciesList = null;
        private Species _selectedSpecies= null;

        public Action ShowPeople { get; set; }
        public SpeciesListViewModel()
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
        public SpeciesListViewModel(List<string> species)
        {
            _speciesListURLs = species;
        }

        public List<Species> SpeciesList
        {
            get
            {
                return _speciesList;
            }
            set
            {
                _speciesList = value;
                NotifyPropertyChanged("SpeciesList");
            }
        }
        public Species SelectedSpecies
        {
            get
            {
                return _selectedSpecies;
            }
            set
            {
                _selectedSpecies = value;
                NotifyPropertyChanged("SelectedSpecies");
            }
        }
        public async void GetSpeciesList()
        {
            IsLoading = true;
            var httpService = new HttpHelperService<Species>();
            _speciesList = new List<Species>();
            if (_speciesListURLs != null && _speciesListURLs.Any())
            {
                foreach (var url in _speciesListURLs)
                {
                    var qryurl = Utility.GetURLPart(url);
                    var ppl = await httpService.Get(qryurl);
                    if (ppl != null)
                    {
                        _speciesList.Add(ppl);

                    }
                }
                NotifyPropertyChanged("SpeciesList");

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
