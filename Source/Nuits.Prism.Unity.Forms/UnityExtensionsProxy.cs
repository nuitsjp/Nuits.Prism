using System;
using System.ComponentModel;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace Nuits.Prism.Unity
{
    internal class UnityExtensionsProxy
    {
        /// <summary>
        /// Registers a Page for navigation
        /// </summary>
        /// <param name="container"><see cref="IUnityContainer"/> used to register type for Navigation.</param>
        /// <param name="viewType">The type of Page to register</param>
        /// <param name="name">The unique name to register with the Page</param>
        /// <returns><see cref="IUnityContainer"/></returns>
        public virtual IUnityContainer RegisterTypeForNavigation(IUnityContainer container, Type viewType, string name)
        {
            return container.RegisterTypeForNavigation(viewType, name);
        }
        /// <summary>
        /// Registers a Page for navigation.
        /// </summary>
        /// <typeparam name="TView">The Type of Page to register</typeparam>
        /// <param name="container"><see cref="IUnityContainer"/> used to register type for Navigation.</param>
        /// <param name="name">The unique name to register with the Page</param>
        public virtual IUnityContainer RegisterTypeForNavigation<TView>(IUnityContainer container, string name = null) where TView : Page
        {
            return container.RegisterTypeForNavigation<TView>(name);
        }
        /// <summary>
        /// Registers a Page for navigation.
        /// </summary>
        /// <typeparam name="TView">The Type of Page to register</typeparam>
        /// <typeparam name="TViewModel">The ViewModel to use as the BindingContext for the Page</typeparam>
        /// <param name="name">The unique name to register with the Page</param>
        /// <param name="container"></param>
        public virtual IUnityContainer RegisterTypeForNavigation<TView, TViewModel>(IUnityContainer container, string name = null)
                where TView : Page
                where TViewModel : class, INotifyPropertyChanged
        {
            return container.RegisterTypeForNavigation<TView, TViewModel>(name);
        }
        /// <summary>
        /// Registers a Page for navigation based on the Device Idiom using a shared ViewModel
        /// </summary>
        /// <typeparam name="TView">Default View Type to be used across multiple Idioms if they are not specified directly.</typeparam>
        /// <typeparam name="TViewModel">The shared ViewModel</typeparam>
        /// <param name="container"><see cref="IUnityContainer"/> used to register type for Navigation.</param>
        /// <param name="name">The common name used for Navigation. If left empty or null will default to the ViewModel root name. i.e. MyPageViewModel => MyPage</param>
        /// <param name="desktopView">Desktop Specific View Type</param>
        /// <param name="tabletView">Tablet Specific View Type</param>
        /// <param name="phoneView">Phone Specific View Type</param>
        /// <returns><see cref="IUnityContainer"/></returns>
        public virtual IUnityContainer RegisterTypeForNavigationOnIdiom<TView, TViewModel>(IUnityContainer container, string name = null, Type desktopView = null, Type tabletView = null, Type phoneView = null)
                where TView : Page
                where TViewModel : class, INotifyPropertyChanged
        {
            return container.RegisterTypeForNavigationOnIdiom<TView, TViewModel>(name, desktopView, tabletView, phoneView);
        }
        /// <summary>
        /// Registers a Page for navigation based on the current Device OS using a shared ViewModel
        /// </summary>
        /// <typeparam name="TView">Default View Type to be shared across multiple Device Operating Systems if they are not specified directly.</typeparam>
        /// <typeparam name="TViewModel">Shared ViewModel Type</typeparam>
        /// <param name="container"><see cref="IUnityContainer"/> used to register type for Navigation.</param>
        /// <param name="name">The unique name to register with the Page. If left empty or null will default to the ViewModel root name. i.e. MyPageViewModel => MyPage</param>
        /// <param name="androidView">Android Specific View Type</param>
        /// <param name="iOSView">iOS Specific View Type</param>
        /// <param name="otherView">Other Platform Specific View Type</param>
        /// <param name="windowsView">Windows Specific View Type</param>
        /// <param name="winPhoneView">Windows Phone Specific View Type</param>
        /// <returns><see cref="IUnityContainer"/></returns>
        // ReSharper disable once InconsistentNaming
        public virtual IUnityContainer RegisterTypeForNavigationOnPlatform<TView, TViewModel>(IUnityContainer container, string name = null, Type androidView = null, Type iOSView = null, Type otherView = null, Type windowsView = null, Type winPhoneView = null)
            where TView : Page
            where TViewModel : class, INotifyPropertyChanged
        {
            return container.RegisterTypeForNavigationOnPlatform<TView, TViewModel>(name, androidView, iOSView, otherView, windowsView);
        }
    }
}