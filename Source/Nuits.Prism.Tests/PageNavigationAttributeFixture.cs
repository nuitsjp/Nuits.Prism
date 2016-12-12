using Nuits.Prism.Navigation;
using Xunit;

namespace Nuits.Prism.Tests
{
    public class PageNavigationAttributeFixture
    {
        [Fact]
        public void NavigationName()
        {
            var actual = new PageNavigationAttribute("NavigationName");
            Assert.Equal("NavigationName", actual.NavigationName);
        }

        [Fact]
        public void ViewTypeNameWhen()
        {
            var actual = new PageNavigationAttribute("NavigationName", "ViewTypeName");
            Assert.Equal("ViewTypeName", actual.ViewTypeName);
        }

        [Fact]
        public void ViewTypeNameWhenDefault()
        {
            var actual = new PageNavigationAttribute("NavigationName");
            Assert.Equal("NavigationName", actual.ViewTypeName);
        }
    }
}