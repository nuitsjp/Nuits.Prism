using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuits.Prism.Navigation;
using Xunit;

namespace Nuits.Prism.Tests
{
    public class PageNavigationInfoResolverFixture
    {
        [Fact]
        public void ResolveWhenDefault()
        {
            var pageNavigationInfoResolver = new PageNavigationInfoResolver();
            var actual = pageNavigationInfoResolver.Resolve(typeof(PageNavigationInfoResolverFixturePage), typeof(PageNavigationInfoResolverFixturePageViewModel));
            
            Assert.NotNull(actual);

            Assert.NotNull(actual.Name);
            Assert.Equal("PageNavigationInfoResolverFixturePage", actual.Name);

            Assert.NotNull(actual.ViewType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixturePage), actual.ViewType);

            Assert.NotNull(actual.ViewModelType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixturePageViewModel), actual.ViewModelType);
        }

        [Fact]
        public void ResolveWhenViewTypeIsNull()
        {
            var pageNavigationInfoResolver = new PageNavigationInfoResolver();
            var actual = pageNavigationInfoResolver.Resolve(null, typeof(PageNavigationInfoResolverFixturePageViewModel));

            Assert.NotNull(actual);

            Assert.NotNull(actual.Name);
            Assert.Equal("PageNavigationInfoResolverFixturePage", actual.Name);

            Assert.NotNull(actual.ViewType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixturePage), actual.ViewType);

            Assert.NotNull(actual.ViewModelType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixturePageViewModel), actual.ViewModelType);
        }
    }

    public class PageNavigationInfoResolverFixturePage
    {
    }

    public class PageNavigationInfoResolverFixturePageViewModel
    {
    }
}
