using Prism.Navigation;

namespace Nuits.Prism.Navigation
{
    public interface INavigatable
    {
        INavigationService NavigationService { get; }
    }
}