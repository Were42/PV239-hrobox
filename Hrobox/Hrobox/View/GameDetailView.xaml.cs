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
    public partial class GameDetailView
    {
        public GameDetailView(GameDetailViewModel gameDetailViewModel) : base(gameDetailViewModel)
        {
            InitializeComponent();
        }
    }
}