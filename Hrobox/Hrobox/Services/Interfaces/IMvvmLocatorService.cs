﻿using Hrobox.ViewModel.Interfaces;
using System;
using Xamarin.Forms;

namespace Hrobox.Services
{
    public interface IMvvmLocatorService
    {
        Page? ResolveView<TViewModel>()
            where TViewModel : class, IViewModel;

        Page? ResolveView<TViewModel, TViewModelParameter>(TViewModelParameter? viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;

        Page? ResolveView(Type viewModelType);

        Type GetViewType<TViewModel>(TViewModel? viewModel = null)
            where TViewModel : class;
        Type GetViewType(Type viewModelType);
    }
}