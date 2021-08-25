using katon_example.Core.Models;
using katon_example.Core.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace katon_example.Form.ViewModels
{
    public class MainPageModel : INotifyPropertyChanged
    {
        private UserServices _userServices;

        private UserModelDTO _selectedItem = new UserModelDTO();

        public ObservableCollection<UserModelDTO> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command SaveItemCommand { get; }
        public Command ResetItemCommand { get; }
        public Command DeleteItemCommand { get; }
        public Command<UserModelDTO> ItemTapped { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageModel()
        {
            Items = new ObservableCollection<UserModelDTO>();

            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);

            ItemTapped = new Command<UserModelDTO>(OnItemSelected);

            SaveItemCommand = new Command(OnSaveItem);

            ResetItemCommand = new Command(OnResetItem);

            DeleteItemCommand = new Command(OnDeleteItem);

            _userServices = new UserServices();
        }

        public UserModelDTO SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        private void ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();

                var data = _userServices.GetAll();

                foreach (var item in data)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
            }
        }

        public void OnAppearing()
        {
            ExecuteLoadItemsCommand();
            SelectedItem = new UserModelDTO();
        }

        private void OnSaveItem(object obj)
        {
            var x = _selectedItem;

            if (x.Id == 0) _userServices.Add(x);
            else _userServices.Edit(x);

            ExecuteLoadItemsCommand();
        }

        private void OnResetItem(object obj)
        {
            SelectedItem = new UserModelDTO();
        }

        private void OnDeleteItem(object obj)
        {
            var x = obj as UserModelDTO;
            _userServices.Delete(x.Id);
            ExecuteLoadItemsCommand();
        }

        private void OnItemSelected(UserModelDTO item)
        {
            Debug.WriteLine("Click item");

            if (item == null)
                return;
            SelectedItem = item;
        }
    }
}