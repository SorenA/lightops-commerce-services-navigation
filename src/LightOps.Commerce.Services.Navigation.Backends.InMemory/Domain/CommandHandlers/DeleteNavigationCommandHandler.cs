using System;
using System.Linq;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.CommandHandlers;
using LightOps.Commerce.Services.Navigation.Api.Commands;
using LightOps.Commerce.Services.Navigation.Backends.InMemory.Api.Providers;

namespace LightOps.Commerce.Services.Navigation.Backends.InMemory.Domain.CommandHandlers
{
    public class DeleteNavigationCommandHandler : IDeleteNavigationCommandHandler
    {
        private readonly IInMemoryNavigationProvider _inMemoryNavigationProvider;

        public DeleteNavigationCommandHandler(IInMemoryNavigationProvider inMemoryNavigationProvider)
        {
            _inMemoryNavigationProvider = inMemoryNavigationProvider;
        }

        public Task HandleAsync(DeleteNavigationCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                throw new ArgumentException("ID missing.");
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

            return Task.CompletedTask;
        }
    }
}