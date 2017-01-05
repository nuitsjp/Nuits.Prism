using System;
using System.Threading.Tasks;
using Moq;
using Nuits.Prism.Navigation;
using Prism.Mvvm;
using Prism.Navigation;
using Xunit;

// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable ClassNeverInstantiated.Local

namespace Nuits.Prism.Forms.Tests
{
    public class NavigationServiceExtensionsFixture
    {
        [Fact]
        public void NavigateAsyncWithNavigationNameProvideInProvider()
        {
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(NavigationServiceExtensionsFixturePageViewModel));

            var navigationService = new Mock<INavigationService>();
            var task = Task.CompletedTask;
            navigationService
                .Setup(m => m.NavigateAsync("NavigationServiceExtensionsFixturePage", null, null, true))
                .Returns(task);

            Assert.Equal(task, navigationService.Object.NavigateAsync<NavigationServiceExtensionsFixturePageViewModel>());
        }

        [Fact]
        public void NavigateAsyncWithFullParameterAndNavigationNameProvideInProvider()
        {
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(NavigationServiceExtensionsFixturePageViewModel));

            var navigationService = new Mock<INavigationService>();
            var task = Task.CompletedTask;
            var parameters = new NavigationParameters();
            navigationService
                .Setup(m => m.NavigateAsync("NavigationServiceExtensionsFixturePage", parameters, true, false))
                .Returns(task);

            Assert.Equal(task, navigationService.Object.NavigateAsync<NavigationServiceExtensionsFixturePageViewModel>(parameters, true, false));
        }

        [Fact]
        public void NavigateAsyncWhenNavigationIsZero()
        {
            var navigationService = new Mock<INavigationService>();
            var exception =
                Assert.ThrowsAny<ArgumentException>(() => navigationService.Object.NavigateAsync());

            Assert.Equal("Navigations is 0.", exception.Message);
        }
        [Fact]
        public void NavigateAsyncBySingleNavigation()
        {
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(NavigationServiceExtensionsFixturePageViewModel));

            var navigationService = new Mock<INavigationService>();
            var task = Task.CompletedTask;

            var navigation = new PageNavigation<NavigationServiceExtensionsFixturePageViewModel>();
            navigation.Parameters["key1"] = "value1";
            navigationService
                .Setup(m => m.NavigateAsync("NavigationServiceExtensionsFixturePage?key1=value1", null, null, true))
                .Returns(task);

            // ReSharper disable once RedundantExplicitParamsArrayCreation
            Assert.Equal(task, navigationService.Object.NavigateAsync(new PageNavigation[] { navigation }));

        }

        [Fact]
        public void NavigateAsyncByDeepLink()
        {
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(NavigationServiceExtensionsFixturePageViewModel));
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(NavigationServiceExtensionsFixturePageSecondPageViewModel));

            var navigationService = new Mock<INavigationService>();
            var task = Task.CompletedTask;

            var firstNavigation = new PageNavigation<NavigationServiceExtensionsFixturePageViewModel>();
            firstNavigation.Parameters["key1"] = "value1";
            var secondNavigation = new PageNavigation<NavigationServiceExtensionsFixturePageSecondPageViewModel>();
            secondNavigation.Parameters["key2"] = "value2";


            navigationService
                .Setup(m => m.NavigateAsync("/NavigationServiceExtensionsFixturePage?key1=value1/NavigationServiceExtensionsFixturePageSecondPage?key2=value2", null, null, true))
                .Returns(task);

            Assert.Equal(task, navigationService.Object.NavigateAsync(firstNavigation, secondNavigation));

        }

        [Fact]
        public void NavigateAsyncByDeepLinkWithParams()
        {
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(NavigationServiceExtensionsFixturePageViewModel));
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null, typeof(NavigationServiceExtensionsFixturePageSecondPageViewModel));

            var navigationService = new Mock<INavigationService>();
            var task = Task.CompletedTask;

            var firstNavigation = new PageNavigation<NavigationServiceExtensionsFixturePageViewModel>();
            firstNavigation.Parameters["key1"] = "value1";
            var secondNavigation = new PageNavigation<NavigationServiceExtensionsFixturePageSecondPageViewModel>();
            secondNavigation.Parameters["key2"] = "value2";


            navigationService
                .Setup(m => m.NavigateAsync("/NavigationServiceExtensionsFixturePage?key1=value1/NavigationServiceExtensionsFixturePageSecondPage?key2=value2", null, true, false))
                .Returns(task);

            Assert.Equal(task, navigationService.Object.NavigateAsync(new PageNavigation[] { firstNavigation, secondNavigation }, true, false));

        }
    }
    public class NavigationServiceExtensionsFixturePage
    {
    }

    public class NavigationServiceExtensionsFixturePageSecondPage
    {
    }

    public class NavigationServiceExtensionsFixturePageViewModel : BindableBase
    {
    }

    public class NavigationServiceExtensionsFixturePageSecondPageViewModel : BindableBase
    {
    }
}