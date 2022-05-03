using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Services.Interfaces;
using Hrobox.ViewModel.Interfaces;
using Xamarin.Forms;

namespace Hrobox.ViewModel
{
    public class MultiPickerViewModel : ViewModelBase, IViewModel<ObservableCollection<TagModel>>
    {
        public ObservableCollection<TagModel> Tags { get; set; }
        public string Teststring { get; set; } = "HEJ";
        private readonly INavigationService navigationService;
        private ICommand closePicker;
        public ICommand ClosePicker => closePicker;
        public MultiPickerViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            closePicker = new AsyncCommand(ClosePickerFunction, null, null, false);
        }

        public async Task ClosePickerFunction()
        {
            await navigationService.PopAsync();
        }

        public void SetViewModelParameter(ObservableCollection<TagModel>? parameter)
        {
            Tags = parameter;
        }
    }
}
