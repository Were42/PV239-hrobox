using System.Threading.Tasks;

namespace Hrobox.ViewModel.Interfaces
{
    public interface  IViewModel
    {
        Task OnAppearingAsync();
    }

    public interface IViewModel<TViewModelParameter> : IViewModel
    {
        void SetViewModelParameter(TViewModelParameter? parameter);
    }
}