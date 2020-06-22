namespace LightOps.Commerce.Services.Navigation.Api.Models
{
    public interface INavigationLink
    {
        string Title { get; set; }
        string Url { get; set; }
        string Target { get; set; }
    }
}