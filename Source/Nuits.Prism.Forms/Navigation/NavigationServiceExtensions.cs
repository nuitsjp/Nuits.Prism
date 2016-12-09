using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace Nuits.Prism.Navigation
{
    /// <summary>
    /// Extension methods of INavigationService.
    /// </summary>
    public static class NavigationServiceExtensions
    {
        /// <summary>
        /// Initiates navigation to the target specified by the <typeparamref name="TViewModel"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The type which will be used to identify the name of the navigation target.</typeparam>
        /// <param name="navigationService"></param>
        /// <param name="parameters">The navigation parameters</param>
        /// <param name="useModalNavigation">If <c>true</c> uses PopModalAsync, if <c>false</c> uses PopAsync</param>
        /// <param name="animated">If <c>true</c> the transition is animated, if <c>false</c> there is no animation on transition.</param>
        public static Task NavigateAsync<TViewModel>(this INavigationService navigationService, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
            where TViewModel : BindableBase
        {
            var pageNavigationInfo = PageNavigationInfoProvider.GetPageNavigationInfo<TViewModel>();
            return navigationService.NavigateAsync(pageNavigationInfo.Name, parameters, useModalNavigation, animated);
        }

        /// <summary>
        /// Initiates navigation to the target specified by the <param name="navigations"/>.
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="navigations"></param>
        /// <param name="useModalNavigation"></param>
        /// <param name="animated"></param>
        /// <returns></returns>
        public static Task NavigateAsync(this INavigationService navigationService, IEnumerable<PageNavigation> navigations, bool? useModalNavigation = null, bool animated = true)
        {
            if(!navigations.Any())
                throw new ArgumentException("Navigations is 0.");

            var builder = new StringBuilder();
            var delim = navigations.Count() == 1 ? string.Empty : "/";
            foreach (var navigation in navigations)
            {
                builder.Append(delim);
                builder.Append(navigation);
                delim = "/";
            }
            return navigationService.NavigateAsync(builder.ToString(), null, useModalNavigation, animated);
        }

        /// <summary>
        /// Initiates navigation to the target specified by the <param name="pageNavigations"/>.
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="pageNavigations"></param>
        /// <returns></returns>
        public static Task NavigateAsync(this INavigationService navigationService, params PageNavigation[] pageNavigations)
        {
            return NavigateAsync(navigationService, pageNavigations, null);
        }
    }
}