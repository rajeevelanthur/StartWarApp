using StartWar.UI.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StarWar.Model;

namespace StartWar.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //GetDe();
        }

        private async void GetDe()
        {
            var film = new HttpHelperService<Films>();
            var item = await film.Get("films/1");
            var det = await film.GetList("films");
        }

    }
}
