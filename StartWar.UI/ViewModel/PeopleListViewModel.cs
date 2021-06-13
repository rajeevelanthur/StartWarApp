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
    public class PeopleListViewModel : INotifyPropertyChanged
    {

        private List<string> _peopleListURLs = null;
        private List<People> _peopleList = null;
        private People _selectedPeople = null;
        

        public Action ShowPeople { get; set; }
        public PeopleListViewModel()
        {

        }
        public PeopleListViewModel(List<string> pplListUrl)
        {
            _peopleListURLs = pplListUrl;
           
           
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
        public List<People> PeopleList
        {
            get
            {
                return _peopleList;
            }
            set
            {
                _peopleList = value;
                NotifyPropertyChanged("PeopleList");
            }
        }
        public People SelectedPeople
        {
            get
            {
                return _selectedPeople;
            }
            set
            {
                _selectedPeople = value;
                NotifyPropertyChanged("SelectedPeople");
            }
        }
        public async void GetPeopleList()
        {
            IsLoading = true;
            var httpService = new HttpHelperService<People>();
            _peopleList = new List<People>();
            if (_peopleListURLs != null && _peopleListURLs.Any())
            {
                foreach (var url in _peopleListURLs)
                {
                    var qryurl = Utility.GetURLPart(url);
                    var ppl = await httpService.Get(qryurl);
                    if (ppl != null)
                    {
                        _peopleList.Add(ppl);
                       
                    }
                }
                NotifyPropertyChanged("PeopleList");

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
