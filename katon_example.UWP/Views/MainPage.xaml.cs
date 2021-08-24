using katon_example.UWP.ViewModels;
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
    }
}