using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrobox.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hrobox.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGameView
    {
        public NewGameView(CreateGameViewModels createGameViewModels) : base(createGameViewModels)
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