using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Mapping.Api.Mappers;

namespace LightOps.Commerce.Services.Navigation.Domain.Mappers
{
    public class NavigationLinkGrpcMapperV1 : IMapper<INavigationLink, Proto.Services.Navigation.V1.NavigationLink>
    {
        public Proto.Services.Navigation.V1.NavigationLink Map(INavigationLink source)
        {
            var dest = new Proto.Services.Navigation.V1.NavigationLink();

            dest.Title = source.Title;
            dest.Url = source.Url;
            dest.Target = source.Target;

            return dest;
        }
    }
}