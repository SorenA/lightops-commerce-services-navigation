using System;
using LightOps.DependencyInjection.Configuration;

namespace LightOps.Commerce.Services.Navigation.Configuration
{
    public static class DependencyInjectionRootComponentExtensions
    {

        public static IDependencyInjectionRootComponent AddNavigationService(this IDependencyInjectionRootComponent rootComponent, Action<INavigationServiceComponent> componentConfig = null)
        {
            var component = new NavigationServiceComponent();

            // Invoke config delegate
            componentConfig?.Invoke(component);

            // Attach to root component
            rootComponent.AttachComponent(component);

            return rootComponent;
        }
    }
}
