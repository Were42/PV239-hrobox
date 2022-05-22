//using Hrobox.Factories;
//using Hrobox.Repositories;

using Hrobox.Annotations;
using Hrobox.Repository;
using Hrobox.Services;
using Hrobox.Services.Interfaces;
using Hrobox.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hrobox.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton(dependencyInjectionService);

            InstallRepositories(serviceCollection);
            InstallViewModels(serviceCollection);
            serviceCollection.AddHttpClient<IGameRepository, GameRestRepository>();
            serviceCollection.AddHttpClient<ITagRepository, TagRestRepository>();
            serviceCollection.AddHttpClient<IUserRepository, UserRestRepository>();
            serviceCollection.AddSingleton<IMessageService, MessageService>();
        }

        private void InstallRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IGameRepository, GameRestRepository>();
            serviceCollection.AddSingleton<IUserRepository, UserRestRepository>();
            serviceCollection.AddSingleton<ITagRepository, TagRestRepository>();
        }

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