using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hrobox.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamesView : ContentPage
    {
        public GamesView()
        {
            InitializeComponent();
        }

        private void OnTapSelectTags(object sender, EventArgs e)
        {
            var page = new MultiPickerView();
            page.BindingContext = BindingContext;
            Navigation.PushModalAsync(page);
        }
    }
}