using System.Linq;
using Google.Protobuf.WellKnownTypes;
using LightOps.Commerce.Proto.Types;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Api.Services;

namespace LightOps.Commerce.Services.Navigation.Domain.Mappers
{
    public class NavigationProtoMapper : IMapper<INavigation, NavigationProto>
    {
        private readonly IMappingService _mappingService;

        public NavigationProtoMapper(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public NavigationProto Map(INavigation src)
        {
            var dest = new NavigationProto
            {
                Id = src.Id,
                ParentId = src.ParentId,
                Handle = src.Handle,
                Type = src.Type,
                CreatedAt = Timestamp.FromDateTime(src.CreatedAt.ToUniversalTime()),
                UpdatedAt = Timestamp.FromDateTime(src.UpdatedAt.ToUniversalTime()),
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