using System.Collections.Generic;
using System.Threading.Tasks;
using LightOps.Commerce.Services.Navigation.Api.Models;

namespace LightOps.Commerce.Services.Navigation.Api.Services
{
    public interface INavigationService
    {
        Task<INavigation> GetByIdAsync(string id);
        Task<IList<INavigation>> GetByIdAsync(IList<string> ids);

        Task<INavigation> GetByHandleAsync(string handle);
        Task<IList<INavigation>> GetByHandleAsync(IList<string> handles);

        Task<IList<INavigation>> GetByParentIdAsync(string parentId);
        Task<IList<INavigation>> GetByParentIdAsync(IList<string> parentIds);

        Task<IList<INavigation>> GetByRootAsync();
    }
}