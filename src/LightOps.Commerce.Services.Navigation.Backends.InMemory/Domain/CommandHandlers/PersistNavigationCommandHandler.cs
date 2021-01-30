using System;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.CommandHandlers;
using LightOps.Commerce.Services.Navigation.Api.Commands;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.CommandHandlers
{
    public class PersistNavigationCommandHandler : IPersistNavigationCommandHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public PersistNavigationCommandHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }

        public Task HandleAsync(PersistNavigationCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                throw new ArgumentException("ID missing.");
            }

            if (command.Navigation.Id != command.Id)
            {
                throw new ArgumentException("Provided ID and entity ID do not match.");
            }

            // Check if entity already exists
            var entity = _inMemoryNavigationProvider
                .Navigations?
                .FirstOrDefault(x => x.Id == command.Id);

            // Delete old if found
            if (entity != null)
            {
                _inMemoryNavigationProvider.Navigations?.Remove(entity);
            }

            // Add entity to provider
            _inMemoryNavigationProvider.Navigations?.Add(command.Navigation);

            return Task.CompletedTask;
        }
    }
}