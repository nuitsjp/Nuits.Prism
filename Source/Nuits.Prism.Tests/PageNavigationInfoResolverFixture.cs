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

        [Fact]
        public void ResolveWhenAttachedPageNavigationAttribute()
        {
            var pageNavigationInfoResolver = new PageNavigationInfoResolver();
            var actual = pageNavigationInfoResolver.Resolve(null, typeof(NamedPageNavigationInfoResolverFixturePageViewModel));

            Assert.NotNull(actual);

            Assert.NotNull(actual.Name);
            Assert.Equal("PageNavigationInfoResolverFixturePage", actual.Name);

            Assert.NotNull(actual.ViewType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixturePage), actual.ViewType);

            Assert.NotNull(actual.ViewModelType);
            Assert.Equal(typeof(NamedPageNavigationInfoResolverFixturePageViewModel), actual.ViewModelType);
        }

        [Fact]
        public void ResolveWhenNavigationNameIsNull()
        {
            var pageNavigationInfoResolver = new PageNavigationInfoResolver();
            var actual = pageNavigationInfoResolver.Resolve(null, typeof(PageNavigationInfoResolverFixtureWhenNavigationNameIsNullPageViewModel));

            Assert.NotNull(actual);

            Assert.NotNull(actual.Name);
            Assert.Equal("PageNavigationInfoResolverFixtureWhenNavigationNameIsNullPage", actual.Name);

            Assert.NotNull(actual.ViewType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixtureWhenNavigationNameIsNullPage), actual.ViewType);

            Assert.NotNull(actual.ViewModelType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixtureWhenNavigationNameIsNullPageViewModel), actual.ViewModelType);
        }

        [Fact]
        public void ResolveWhenViewTypeNameIsNull()
        {
            var pageNavigationInfoResolver = new PageNavigationInfoResolver();
            var actual = pageNavigationInfoResolver.Resolve(null, typeof(PageNavigationInfoResolverFixtureWhenViewTypeNameIsNullPageViewModel));

            Assert.NotNull(actual);

            Assert.NotNull(actual.Name);
            Assert.Equal("PageNavigationInfoResolverFixtureWhenViewTypeNameIsNullPage", actual.Name);

            Assert.NotNull(actual.ViewType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixtureWhenViewTypeNameIsNullPage), actual.ViewType);

            Assert.NotNull(actual.ViewModelType);
            Assert.Equal(typeof(PageNavigationInfoResolverFixtureWhenViewTypeNameIsNullPageViewModel), actual.ViewModelType);
        }

        [Fact]
        public void ResolveWhenNotExistView()
        {
            var pageNavigationInfoResolver = new PageNavigationInfoResolver();
            var actual = Assert.Throws<InvalidOperationException>(() =>
            {
                pageNavigationInfoResolver.Resolve(
                    null,
                    typeof(PageNavigationInfoResolverFixtureWhenNotExistViewViewModel));
            });
            Assert.Equal("View corresponding to ViewModel does not exist. ViewModel is PageNavigationInfoResolverFixtureWhenNotExistViewViewModel.", actual.Message);
        }
    }

    public class PageNavigationInfoResolverFixturePage
    {
    }

    public class PageNavigationInfoResolverFixturePageViewModel
    {
    }

    [PageNavigation("PageNavigationInfoResolverFixturePage", "PageNavigationInfoResolverFixturePage")]
    public class NamedPageNavigationInfoResolverFixturePageViewModel
    {
    }

    public class PageNavigationInfoResolverFixtureWhenNavigationNameIsNullPage
    {
    }

    [PageNavigation(null, "PageNavigationInfoResolverFixtureWhenNavigationNameIsNullPage")]
    public class PageNavigationInfoResolverFixtureWhenNavigationNameIsNullPageViewModel
    {
    }

    public class PageNavigationInfoResolverFixtureWhenViewTypeNameIsNullPage
    {
    }

    [PageNavigation("PageNavigationInfoResolverFixtureWhenViewTypeNameIsNullPage")]
    public class PageNavigationInfoResolverFixtureWhenViewTypeNameIsNullPageViewModel
    {
    }

    public class PageNavigationInfoResolverFixtureWhenNotExistViewViewModel
    {
    }
}
