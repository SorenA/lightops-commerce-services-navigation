using System.Linq;
using LightOps.Commerce.Proto.Services.Navigation.V1;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Api.Services;

// ReSharper disable UseObjectOrCollectionInitializer

namespace LightOps.Commerce.Services.Navigation.Domain.Mappers
{
    public class NavigationGrpcMapperV1 : IMapper<INavigation, Proto.Services.Navigation.V1.Navigation>
    {
        private readonly IMappingService _mappingService;

        public NavigationGrpcMapperV1(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public Proto.Services.Navigation.V1.Navigation Map(INavigation source)
        {
            var dest = new Proto.Services.Navigation.V1.Navigation();

            dest.Id = source.Id;
            dest.Handle = source.Handle;

            dest.ParentNavigationId = source.ParentNavigationId;

            dest.Header = _mappingService
                .Map<INavigationLink, NavigationLink>(source.Header);

            var links = _mappingService
                .Map<INavigationLink, NavigationLink>(source.Links)
                .ToList();
            dest.Links.AddRange(links);

            // Can't use IMappingService to resolve self
            var subNavigations = source.SubNavigations
                .Select(Map)
                .ToList();
            dest.SubNavigations.AddRange(subNavigations);

            return dest;
        }
    }
}