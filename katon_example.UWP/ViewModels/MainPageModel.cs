using katon_example.Core.Models;
using katon_example.Core.Services;
using System.Collections.ObjectModel;
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

        public ObservableCollection<UserModelDTO> Source = new ObservableCollection<UserModelDTO>();

        private UserModelDTO _selectedItem = new UserModelDTO();

        public UserModelDTO SelectedItem
        {
            get => _selectedItem;
            set
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

        public void DeleteItem(object item)
        {
            System.Diagnostics.Debug.WriteLine("Click delete item");

            var x = (UserModelDTO)item;
            _userServices.Delete(x.Id);
            LoadData();
        }

        public void SaveItem(object item)
        {
            System.Diagnostics.Debug.WriteLine("Click save item");

            var x = (UserModelDTO)item;
            if (x.Id == 0) _userServices.Add(x);
            else _userServices.Edit(x);

            LoadData();
        }
    }
}