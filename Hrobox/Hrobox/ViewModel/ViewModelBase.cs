using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Hrobox.ViewModel.Interfaces;

namespace Hrobox.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task OnAppearingAsync()
        {
            return Task.CompletedTask;
        }
    }
    public abstract class ViewModelBase<TViewModelParameter> : ViewModelBase, IViewModel<TViewModelParameter>
    {
        protected TViewModelParameter? ViewModelParameter;

        public virtual void SetViewModelParameter(TViewModelParameter? parameter)
        {
            ViewModelParameter = parameter;
        }
    }
}