using Xunit;

namespace Nuits.Prism
{
    public class NavigationNameAttributeFixture
    {
        [Fact]
        public void NavigationNameAttribute()
        {
            var actual = new NavigationNameAttribute("NavigationName");
            Assert.Equal("NavigationName", actual.Name);
        }
    }
}