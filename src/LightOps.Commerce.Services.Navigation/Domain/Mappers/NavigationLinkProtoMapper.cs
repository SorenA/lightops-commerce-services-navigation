using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Mapping.Api.Mappers;

namespace LightOps.Commerce.Services.Navigation.Domain.Mappers
{
    public class NavigationLinkProtoMapper : IMapper<INavigationLink, NavigationLinkProto>
    {
        public NavigationLinkProto Map(INavigationLink source)
        {
            return new NavigationLinkProto
            {
                Title = source.Title,
                Url = source.Url,
                Target = source.Target,
            };
        }
    }
}