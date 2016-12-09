using System;
using System.ComponentModel;
using Microsoft.Practices.Unity;
using Nuits.Prism.Navigation;
using Prism.Mvvm;
using Xamarin.Forms;

namespace Nuits.Prism.Unity
{
    public static class UnityContainerExtensions
    {
        /// <summary>
        /// Proxy of IUnityContainer.
        /// </summary>
        internal static UnityExtensionsProxy UnityExtensionsProxy = new UnityExtensionsProxy();

        /// <summary>
        /// Registers a Page for navigation.
        /// </summary>
        /// <typeparam name="TView">The Type of Page to register</typeparam>
        /// <typeparam name="TViewModel">The ViewModel to use as the BindingContext for the Page</typeparam>
        /// <param name="container"></param>
        public static IUnityContainer RegisterTypeForViewModelNavigation<TViewModel>(this IUnityContainer container)
            where TViewModel : BindableBase
        {
            var pageNavigationInfo = PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(TViewModel));

            ViewModelLocationProvider.Register(pageNavigationInfo.ViewType.Name, typeof(TViewModel));

            return UnityExtensionsProxy.RegisterTypeForNavigation(container, pageNavigationInfo.ViewType, pageNavigationInfo.Name);
        }


        /// <summary>
        /// Registers a Page for navigation.
        /// </summary>
        /// <typeparam name="TView">The Type of Page to register</typeparam>
        /// <typeparam name="TViewModel">The ViewModel to use as the BindingContext for the Page</typeparam>
        /// <param name="container"></param>
        public static IUnityContainer RegisterTypeForViewModelNavigation<TView, TViewModel>(this IUnityContainer container)
            where TView : Page
            where TViewModel : INotifyPropertyChanged
        {
            var pageNavigationInfo = PageNavigationInfoProvider.RegisterPageNavigationInfo(typeof(TView), typeof(TViewModel));

            ViewModelLocationProvider.Register(pageNavigationInfo.ViewType.Name, typeof(TViewModel));

            return UnityExtensionsProxy.RegisterTypeForNavigation(container, pageNavigationInfo.ViewType, pageNavigationInfo.Name);
        }

        /// <summary>
        /// Registers a Page for navigation based on the current Device OS using a shared ViewModel
        /// </summary>
        /// <typeparam name="TView">Default View Type to be shared across multiple Device Operating Systems if they are not specified directly.</typeparam>
        /// <typeparam name="TViewModel">Shared ViewModel Type</typeparam>
        /// <param name="container"><see cref="IUnityContainer"/> used to register type for PageNavigation.</param>
        /// <param name="androidView">Android Specific View Type</param>
        /// <param name="iOSView">iOS Specific View Type</param>
        /// <param name="otherView">Other Platform Specific View Type</param>
        /// <param name="windowsView">Windows Specific View Type</param>
        /// <param name="winPhoneView">Windows Phone Specific View Type</param>
        /// <returns><see cref="IUnityContainer"/></returns>
        // ReSharper disable once InconsistentNaming
        public static IUnityContainer RegisterTypeForViewModelNavigationOnPlatform<TView, TViewModel>(this IUnityContainer container, Type androidView = null, Type iOSView = null, Type otherView = null, Type windowsView = null, Type winPhoneView = null)
            where TView : Page
            where TViewModel : class, INotifyPropertyChanged
        {
            var pageNavigationInfo = PageNavigationInfoProvider.RegisterPageNavigationInfo(typeof(TView), typeof(TViewModel));
            return UnityExtensionsProxy.RegisterTypeForNavigationOnPlatform<TView, TViewModel>(container, pageNavigationInfo.Name, androidView, iOSView, otherView, windowsView, winPhoneView);
        }

        /// <summary>
        /// Registers a Page for navigation based on the Device Idiom using a shared ViewModel
        /// </summary>
        /// <typeparam name="TView">Default View Type to be used across multiple Idioms if they are not specified directly.</typeparam>
        /// <typeparam name="TViewModel">The shared ViewModel</typeparam>
        /// <param name="container"><see cref="IUnityContainer"/> used to register type for PageNavigation.</param>
        /// <param name="desktopView">Desktop Specific View Type</param>
        /// <param name="tabletView">Tablet Specific View Type</param>
        /// <param name="phoneView">Phone Specific View Type</param>
        /// <returns><see cref="IUnityContainer"/></returns>
        public static IUnityContainer RegisterTypeForViewModelNavigationOnIdiom<TView, TViewModel>(this IUnityContainer container, Type desktopView = null, Type tabletView = null, Type phoneView = null)
            where TView : Page
            where TViewModel : class, INotifyPropertyChanged
        {
            var pageNavigationInfo = PageNavigationInfoProvider.RegisterPageNavigationInfo(typeof(TView), typeof(TViewModel));
            return UnityExtensionsProxy.RegisterTypeForNavigationOnIdiom<TView, TViewModel>(container, pageNavigationInfo.Name, desktopView, tabletView, phoneView);
        }
    }
}