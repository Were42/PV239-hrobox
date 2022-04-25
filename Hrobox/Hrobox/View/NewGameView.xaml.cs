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
    public partial class NewGameView : ContentPage
    {
        public NewGameView()
        {
            InitializeComponent();
        }
        //todo: remove when done with testing detail
        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameDetailView());
        }
    }
}