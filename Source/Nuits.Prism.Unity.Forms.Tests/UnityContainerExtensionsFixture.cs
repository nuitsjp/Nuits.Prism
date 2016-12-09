using System.ComponentModel;
using Microsoft.Practices.Unity;
using Moq;
using Prism.Mvvm;
using Xamarin.Forms;
using Xunit;

namespace Nuits.Prism.Unity.Forms.Tests
{
    public class UnityContainerExtensionsFixture
    {
        [Fact]
        public void RegisterTypeForViewModelNavigation()
        {
            var unityExtensionsProxy = new Mock<UnityExtensionsProxy>();
            UnityContainerExtensions.UnityExtensionsProxy = unityExtensionsProxy.Object;
            try
            {
                var unityContainer = new Mock<IUnityContainer>().Object;

                unityExtensionsProxy
                    .Setup(
                        m => m.RegisterTypeForNavigation(
                            unityContainer,
                            typeof(UnityContainerExtensionsFixturePage),
                            "UnityContainerExtensionsFixturePage"))
                    .Returns(unityContainer);

                var result = unityContainer.RegisterTypeForViewModelNavigation<UnityContainerExtensionsFixturePageViewModel>();
                Assert.Equal(unityContainer, result);

                var page = new UnityContainerExtensionsFixturePage();
                ViewModelLocator.SetAutowireViewModel(page, true);

                Assert.NotNull(page.BindingContext);
                Assert.Equal(typeof(UnityContainerExtensionsFixturePageViewModel), page.BindingContext.GetType());
            }
            finally
            {
                UnityContainerExtensions.UnityExtensionsProxy = new UnityExtensionsProxy();
            }
        }

        [Fact]
        public void RegisterTypeForViewModelNavigationWithViewType()
        {
            var unityExtensionsProxy = new Mock<UnityExtensionsProxy>();
            UnityContainerExtensions.UnityExtensionsProxy = unityExtensionsProxy.Object;
            try
            {
                var unityContainer = new Mock<IUnityContainer>().Object;

                unityExtensionsProxy
                    .Setup(
                        m => m.RegisterTypeForNavigation(
                            unityContainer,
                            typeof(UnityContainerExtensionsFixturePage),
                            "UnityContainerExtensionsFixturePage"))
                    .Returns(unityContainer);

                var result = unityContainer.RegisterTypeForViewModelNavigation<UnityContainerExtensionsFixturePage, UnityContainerExtensionsFixturePageViewModel>();
                Assert.Equal(unityContainer, result);

                var page = new UnityContainerExtensionsFixturePage();
                ViewModelLocator.SetAutowireViewModel(page, true);

                Assert.NotNull(page.BindingContext);
                Assert.Equal(typeof(UnityContainerExtensionsFixturePageViewModel), page.BindingContext.GetType());
            }
            finally
            {
                UnityContainerExtensions.UnityExtensionsProxy = new UnityExtensionsProxy();
            }
        }

        [Fact]
        public void RegisterTypeForViewModelNavigationOnPlatform()
        {
            var unityExtensionsProxy = new Mock<UnityExtensionsProxy>();
            UnityContainerExtensions.UnityExtensionsProxy = unityExtensionsProxy.Object;
            try
            {
                var unityContainer = new Mock<IUnityContainer>().Object;

                var androidView = typeof(string);
                // ReSharper disable once InconsistentNaming
                var iOSView = typeof(short);
                var otherView = typeof(int);
                var windowsView = typeof(long);
                var winPhoneView = typeof(bool);

                unityExtensionsProxy
                    .Setup(
                        m => m.RegisterTypeForNavigationOnPlatform<UnityContainerExtensionsFixturePage, UnityContainerExtensionsFixturePageViewModel>(
                            unityContainer,
                            "UnityContainerExtensionsFixturePage",
                            androidView,
                            iOSView,
                            otherView,
                            windowsView,
                            winPhoneView))
                    .Returns(unityContainer);

                var result = 
                    unityContainer.RegisterTypeForViewModelNavigationOnPlatform<UnityContainerExtensionsFixturePage, UnityContainerExtensionsFixturePageViewModel>(
                        androidView,
                        iOSView,
                        otherView,
                        windowsView,
                        winPhoneView);
                Assert.Equal(unityContainer, result);
            }
            finally
            {
                UnityContainerExtensions.UnityExtensionsProxy = new UnityExtensionsProxy();
            }
        }

        [Fact]
        public void RegisterTypeForNavigationOnIdiom()
        {
            var unityExtensionsProxy = new Mock<UnityExtensionsProxy>();
            UnityContainerExtensions.UnityExtensionsProxy = unityExtensionsProxy.Object;
            try
            {
                var unityContainer = new Mock<IUnityContainer>().Object;

                var desktopView = typeof(string);
                var tabletView = typeof(short);
                var phoneView = typeof(int);

                unityExtensionsProxy
                    .Setup(
                        m => m.RegisterTypeForNavigationOnIdiom<UnityContainerExtensionsFixturePage, UnityContainerExtensionsFixturePageViewModel>(
                            unityContainer,
                            "UnityContainerExtensionsFixturePage",
                            desktopView,
                            tabletView,
                            phoneView))
                    .Returns(unityContainer);

                var result =
                    unityContainer.RegisterTypeForViewModelNavigationOnIdiom<UnityContainerExtensionsFixturePage, UnityContainerExtensionsFixturePageViewModel>(
                        desktopView,
                        tabletView,
                        phoneView);
                Assert.Equal(unityContainer, result);
            }
            finally
            {
                UnityContainerExtensions.UnityExtensionsProxy = new UnityExtensionsProxy();
            }
        }
    }

    public class UnityContainerExtensionsFixturePage : Page
    {
    }

    public class UnityContainerExtensionsFixturePageViewModel : BindableBase
    {
    }
}

