﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism.Ioc;
using Prism.Navigation;
using Shiny;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Sample
{
    public class Startup : FrameworkStartup
    {
        public override void ConfigureApp(Application app, IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CreatePage, CreateViewModel>();
            containerRegistry.RegisterForNavigation<ManagedBeaconPage, ManagedBeaconViewModel>();
        }


        public override Task RunApp(INavigationService navigator)
            => navigator.Navigate("NavigationPage/ManagedBeaconPage");


        protected override void Configure(ILoggingBuilder builder, IServiceCollection services)
        {
            // we inject our db so we can use it in our shiny background events to store them for display later
            services.UseXfMaterialDialogs();
            services.UseGlobalCommandExceptionHandler();
            services.UseBeaconRanging();
        }
    }
}
