using katon_example.Core.Models;
using katon_example.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katon_example.UWP.ViewModels
{
    public class MainPageModel
    {
        private UserServices _userServices;

        public MainPageModel()
        {
            _userServices = new UserServices();
        }

        public ObservableCollection<UserModelDTO> Source = new ObservableCollection<UserModelDTO>();

        public void LoadData()
        {
            Source.Clear();

            var data = _userServices.GetAll();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

    }
}
