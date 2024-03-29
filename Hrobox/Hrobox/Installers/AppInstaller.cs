﻿using Hrobox.Services;
using Hrobox.Services.Interfaces;
using Hrobox.View;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Hrobox.Installers
{
    public class AppInstaller
    {
        public void Install(IServiceCollection serviceCollection, Application application, INavigation navigation)
        {
            serviceCollection.AddSingleton(application);
            serviceCollection.AddSingleton(navigation);

            InstallServices(serviceCollection);
            InstallViews(serviceCollection);
        }

        private void InstallServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMvvmLocatorService, MvvmLocatorService>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
        }

        private void InstallViews(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(selector => selector
                .FromAssemblyOf<AppInstaller>()
                .AddClasses(filter => filter.AssignableTo<ContentPageBase>())
                .AsSelf()
                .WithTransientLifetime());
        }
    }
}