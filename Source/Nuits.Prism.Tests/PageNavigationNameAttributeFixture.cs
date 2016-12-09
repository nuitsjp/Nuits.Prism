using Nuits.Prism.Navigation;
using Xunit;

namespace Nuits.Prism.Tests
{
    public class PageNavigationNameAttributeFixture
    {
        [Fact]
        public void NameAttribute()
        {
            var actual = new PageNavigationNameAttribute("NavigationName");
            Assert.Equal("NavigationName", actual.Name);
        }
    }
}