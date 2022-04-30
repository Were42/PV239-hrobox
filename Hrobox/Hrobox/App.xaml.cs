using System;
using Hrobox.Installers;
using Hrobox.Services;
using Hrobox.View;
using Hrobox.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hrobox
{
    public partial class App : Application
    {
        private readonly IDependencyInjectionService dependencyInjectionService;
        public App()
        {
            InitializeComponent();

            dependencyInjectionService = new DependencyInjectionService();
            var page = new NavigationPage();
            InstallDependencies(dependencyInjectionService, this, page.Navigation);
            var navService = dependencyInjectionService.Resolve<INavigationService>();
            navService.PushAsync<GamesViewModel>();

            MainPage = page;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        private void InstallDependencies(IDependencyInjectionService dependencyInjectionService, App application, INavigation navigation)
        {
            var serviceCollection = new ServiceCollection();

            new CoreInstaller().Install(serviceCollection, dependencyInjectionService);
            new AppInstaller().Install(serviceCollection, application, navigation);

            dependencyInjectionService.Build(serviceCollection);
        }
    }
}
