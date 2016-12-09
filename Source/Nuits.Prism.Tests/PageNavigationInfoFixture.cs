using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuits.Prism.Navigation;
using Xunit;

namespace Nuits.Prism.Tests
{
    public class PageNavigationInfoFixture
    {
        [Fact]
        public void NameProperty()
        {
            var actual = new PageNavigationInfo("navigationName", typeof(string), typeof(int));
            Assert.Equal("navigationName", actual.Name);
        }

        [Fact]
        public void ViewTypeProperty()
        {
            var actual = new PageNavigationInfo("navigationName", typeof(string), typeof(int));
            Assert.Equal(typeof(string), actual.ViewType);
        }

        [Fact]
        public void ViewModelTypeProperty()
        {
            var actual = new PageNavigationInfo("navigationName", typeof(string), typeof(int));
            Assert.Equal(typeof(int), actual.ViewModelType);
        }
    }
}
