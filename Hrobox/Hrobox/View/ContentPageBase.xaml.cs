using Hrobox.ViewModel.Interfaces;
using Xamarin.Forms;

namespace Hrobox.View
{
    public partial class ContentPageBase : ContentPage
    {
        public ContentPageBase(IViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is IViewModel viewModel)
            {
                await viewModel.OnAppearingAsync();
            }
        }
    }
}