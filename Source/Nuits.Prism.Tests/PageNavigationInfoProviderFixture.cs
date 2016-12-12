using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuits.Prism.Navigation;
using Prism.Mvvm;
using Xunit;

namespace Nuits.Prism.Tests
{
    public class PageNavigationInfoProviderFixture
    {
        [Fact]
        public void PageNavigationInfoResolver()
        {
            var original = PageNavigationInfoProvider.PageNavigationInfoResolver;
            try
            {
                var custum = new CustumPageNavigationInfoResolver();
                PageNavigationInfoProvider.PageNavigationInfoResolver = custum;
                Assert.Equal(custum, PageNavigationInfoProvider.PageNavigationInfoResolver);
            }
            finally
            {
                PageNavigationInfoProvider.PageNavigationInfoResolver = original;
            }

        }

        private class CustumPageNavigationInfoResolver : PageNavigationInfoResolver
        {
        }

        [Fact]
        public void PageNavigationInfoProviderWhenRegisterd()
        {
            PageNavigationInfoProvider.RegisterPageNavigationInfo(
                typeof(PageNavigationInfoProviderFixturePage),
                typeof(PageNavigationInfoProviderFixturePageViewModel));

            var actual =
                PageNavigationInfoProvider.GetPageNavigationInfo<PageNavigationInfoProviderFixturePageViewModel>();

            Assert.NotNull(actual);
            Assert.Equal("PageNavigationInfoProviderFixturePage", actual.Name);
            Assert.Equal(typeof(PageNavigationInfoProviderFixturePage), actual.ViewType);
            Assert.Equal(typeof(PageNavigationInfoProviderFixturePageViewModel), actual.ViewModelType);
        }

        [Fact]
        public void PageNavigationInfoProviderWhenNotRegisterd()
        {
            var actual = Assert.ThrowsAny<InvalidOperationException>(PageNavigationInfoProvider.GetPageNavigationInfo<NotRegisteredPageNavigationInfoProviderFixturePageViewModel>);

            Assert.Equal("PageNavigationInfo is not registerd. View model type is NotRegisteredPageNavigationInfoProviderFixturePageViewModel.", actual.Message);
        }

        private class PageNavigationInfoProviderFixturePage
        {
        }

        private class PageNavigationInfoProviderFixturePageViewModel : BindableBase
        {
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class NotRegisteredPageNavigationInfoProviderFixturePageViewModel : BindableBase
        {
        }
    }
}
