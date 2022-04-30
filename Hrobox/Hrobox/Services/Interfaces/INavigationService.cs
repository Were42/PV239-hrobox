using System.Threading.Tasks;
using Hrobox.ViewModel.Interfaces;

namespace Hrobox.Services.Interfaces
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel;

        Task PushAsync<TViewModel, TViewModelParameter>(
            TViewModelParameter? viewModelParameter = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;

        Task PopAsync(bool animated = default);
        Task PopToRootAsync(bool animated = default);
    }
}