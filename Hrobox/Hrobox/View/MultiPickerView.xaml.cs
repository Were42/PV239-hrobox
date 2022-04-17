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
    public partial class MultiPickerView : ContentPage
    {
        public MultiPickerView()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}