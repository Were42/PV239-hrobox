using Hrobox.ViewModel.Interfaces;
using System.Threading.Tasks;

namespace Hrobox.Services
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