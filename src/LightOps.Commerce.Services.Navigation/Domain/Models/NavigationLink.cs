using LightOps.Commerce.Services.Navigation.Api.Models;

namespace LightOps.Commerce.Services.Navigation.Domain.Models
{
    public class NavigationLink : INavigationLink
    {
        public NavigationLink()
        {
            Target = "_self";
        }

        public string Title { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
    }
}