using katon_example.UWP.ViewModels;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace katon_example.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageModel ViewModel = new MainPageModel();

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel.LoadData();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.ClickItem(e.ClickedItem);
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var x = sender as Button;
            ViewModel.DeleteItem(x.DataContext);
        }

        private async void Button_Click_Save(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var x = ViewModel.SelectedItem;
            if (string.IsNullOrEmpty(x.Name) || string.IsNullOrEmpty(x.LastName))
            {
                var dialog = new MessageDialog("Please input Name and Lastname");
                await dialog.ShowAsync();
            }
            else
            {
                ViewModel.SaveItem(x);
            }
        }

        private void Button_Click_Clear(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.SelectedItem = new Core.Models.UserModelDTO();
        }
    }
}