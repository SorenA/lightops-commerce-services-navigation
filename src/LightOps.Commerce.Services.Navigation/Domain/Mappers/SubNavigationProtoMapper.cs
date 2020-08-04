using System.Linq;
using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Api.Services;

namespace LightOps.Commerce.Services.Navigation.Domain.Mappers
{
    public class SubNavigationProtoMapper : IMapper<ISubNavigation, SubNavigationProto>
    {
        private readonly IMappingService _mappingService;

        public SubNavigationProtoMapper(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public SubNavigationProto Map(ISubNavigation src)
        {
            var dest = new SubNavigationProto
            {
                Header = _mappingService.Map<INavigationLink, NavigationLinkProto>(src.Header),
            };

            // Map links
            var links = _mappingService
                .Map<INavigationLink, NavigationLinkProto>(src.Links)
                .ToList();
            dest.Links.AddRange(links);

            // Map sub-navigations
            var subNavigationService = _mappingService
                .Map<ISubNavigation, SubNavigationProto>(src.SubNavigations)
                .ToList();
            dest.SubNavigations.AddRange(subNavigationService);

            return dest;
        }
    }
}