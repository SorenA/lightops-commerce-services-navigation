using System.Linq;
using LightOps.Commerce.Proto.Services.Navigation.V1;
using LightOps.Commerce.Services.Navigation.Api.Models;
using LightOps.Mapping.Api.Mappers;
using LightOps.Mapping.Api.Services;

// ReSharper disable UseObjectOrCollectionInitializer

namespace LightOps.Commerce.Services.Navigation.Domain.Mappers.V1
{
    public class ProtoNavigationMapper : IMapper<INavigation, ProtoNavigation>
    {
        private readonly IMappingService _mappingService;

        public ProtoNavigationMapper(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public ProtoNavigation Map(INavigation source)
        {
            var dest = new ProtoNavigation();

            dest.Id = source.Id;
            dest.Handle = source.Handle;

            dest.ParentNavigationId = source.ParentNavigationId;

            dest.Header = _mappingService
                .Map<INavigationLink, ProtoNavigationLink>(source.Header);

            var links = _mappingService
                .Map<INavigationLink, ProtoNavigationLink>(source.Links)
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