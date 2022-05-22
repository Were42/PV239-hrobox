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
        private readonly INavigationService _navigationService;
        public ICommand ClosePicker { get; set; }
        public MultiPickerViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            ClosePicker = new AsyncCommand(ClosePickerFunction, null, null, false);
        }

        public async Task ClosePickerFunction()
        {
            await _navigationService.PopAsync();
        }

        public void SetViewModelParameter(ObservableCollection<TagModel>? parameter)
        {
            Tags = parameter;
        }
    }
}
