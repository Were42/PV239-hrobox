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
    public partial class LoginView
    {
        public LoginView(LoginViewModel loginViewModel) : base(loginViewModel)
        {
            InitializeComponent();
        }
        private void Button_OnClicked(object sender, EventArgs e)
        {
            var page = new RegisterView();
            Navigation.PushAsync(page);
        }
    }
}