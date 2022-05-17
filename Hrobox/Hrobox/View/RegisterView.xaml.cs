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
    public partial class RegisterView
    {
        public RegisterView(RegisterViewModel registerViewModel) : base(registerViewModel)
        {
            InitializeComponent();
        }
    }
}