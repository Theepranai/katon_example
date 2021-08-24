using katon_example.Core.Models;
using katon_example.Core.Services;
using System.Collections.Generic;
using System.ComponentModel;

namespace katon_example.UWP.ViewModels
{
    public class MainPageModel : INotifyPropertyChanged
    {
        private UserServices _userServices;

        public MainPageModel()
        {
            _userServices = new UserServices();
        }

        public List<UserModelDTO> Source = new List<UserModelDTO>();

        private UserModelDTO _selectedItem;

        public UserModelDTO SelectedItem
        {
            get => _selectedItem; set
            {
                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadData()
        {
            Source.Clear();

            var data = _userServices.GetAll();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void ClickItem(object item)
        {
            System.Diagnostics.Debug.WriteLine("Click on itemlist");
            SelectedItem = (UserModelDTO)item;
        }
    }
}