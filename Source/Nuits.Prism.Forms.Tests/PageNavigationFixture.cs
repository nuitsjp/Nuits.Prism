using System.ComponentModel;
using Nuits.Prism.Navigation;
using Prism.Mvvm;
using Xamarin.Forms;
using Xunit;

// ReSharper disable ClassNeverInstantiated.Local

namespace Nuits.Prism.Forms.Tests
{
    public class PageNavigationFixture
    {
        [Fact]
        public void Constructor()
        {
            var actual = new PageNavigation("NameProperty");
            Assert.Equal("NameProperty", actual.Name);
            Assert.NotNull(actual.Parameters);
        }

        [Fact]
        public void GenericsConstructor()
        {
            PageNavigationInfoProvider.RegisterPageNavigationInfo(null ,typeof(PageNavigationFixturePageViewModel));
            var actual = new PageNavigation<PageNavigationFixturePageViewModel>();
            Assert.Equal("PageNavigationFixturePage", actual.Name);
            Assert.NotNull(actual.Parameters);
        }

        [Fact]
        public void ToStringWhenEmptyParameters()
        {
            var actual = new PageNavigation("NameProperty");
            Assert.Equal("NameProperty", actual.ToString());
        }

        [Fact]
        public void ToStringWithParameters()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var actual = new PageNavigation("NameProperty");
            actual.Parameters["key1"] = "value1";
            actual.Parameters["key2"] = "value2";
            Assert.Equal("NameProperty?key1=value1&key2=value2", actual.ToString());
        }
    }

    public class PageNavigationFixturePageViewModel : BindableBase
    {
    }

    public class PageNavigationFixturePage : Page { }
}