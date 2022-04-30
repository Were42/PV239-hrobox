﻿//using Hrobox.Factories;
//using Hrobox.Repositories;

using Hrobox.Annotations;
using Hrobox.Services;
using Hrobox.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hrobox.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton(dependencyInjectionService);

            //InstallFactories(serviceCollection);
            //InstallRepositories(serviceCollection);
            InstallViewModels(serviceCollection);
        }

        //private void InstallRepositories(IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddSingleton<IIngredientRepository, IngredientRepository>();
        //}

        //private void InstallFactories(IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();
        //}

        private void InstallViewModels(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(selector => selector
                .FromAssemblyOf<CoreInstaller>()
                .AddClasses(filter => filter.AssignableTo<IViewModel>())
                .AsSelf()
                .WithTransientLifetime());
        }
    }
}