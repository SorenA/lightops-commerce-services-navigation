using LightOps.CQRS.Api.Commands;

namespace LightOps.Commerce.Services.Navigation.Api.Commands
{
    public class DeleteNavigationCommand : ICommand
    {
        /// <summary>
        /// The id of the navigation to delete
        /// </summary>
        public string Id { get; set; }
    }
}