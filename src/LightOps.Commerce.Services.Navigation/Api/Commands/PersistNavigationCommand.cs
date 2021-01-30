using LightOps.CQRS.Api.Commands;

namespace LightOps.Commerce.Services.Navigation.Api.Commands
{
    public class PersistNavigationCommand : ICommand
    {
        /// <summary>
        /// The id of the navigation to persist
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The navigation to persist
        /// </summary>
        public Proto.Types.Navigation Navigation { get; set; }
    }
}