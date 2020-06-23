using LightOps.Commerce.Proto.Services.Navigation.V1;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Mapping.Api.Mappers;

namespace LightOps.Commerce.Services.Navigation.Domain.Mappers.V1
{
    public class ProtoNavigationLinkMapper : IMapper<INavigationLink, ProtoNavigationLink>
    {
        public ProtoNavigationLink Map(INavigationLink source)
        {
            var dest = new ProtoNavigationLink();

            dest.Title = source.Title;
            dest.Url = source.Url;
            dest.Target = source.Target;

            return dest;
        }
    }
}