using katon_example.Form.ViewModels;
using Xamarin.Forms;

namespace katon_example.Form.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainPageModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}