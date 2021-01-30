using LightOps.Commerce.Services.Navigation.Api.Commands;
using LightOps.CQRS.Api.Commands;

namespace LightOps.Commerce.Services.Navigation.Api.CommandHandlers
{
    public interface IPersistNavigationCommandHandler : ICommandHandler<PersistNavigationCommand>
    {
        
    }
}