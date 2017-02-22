using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuits.Prism.Navigation;
using Nuits.Prism.Tests.ViewModels;
using Nuits.Prism.Tests.Views;
using Xunit;

namespace Nuits.Prism.Tests
{
    public class ViewTypeToViewModelTypeResolverFixture
    {
        [Fact]
        public void ResolveWhenViewOfSameAssembly()
        {
            var actual = ViewTypeToViewModelTypeResolver.Resolve(typeof(MockView));
            Assert.Equal(typeof(MockViewModel), actual);
        }

        [Fact]
        public void ResolveWhenPageOfSameAssembly()
        {
            var actual = ViewTypeToViewModelTypeResolver.Resolve(typeof(MockView));
            Assert.Equal(typeof(MockViewModel), actual);
        }

        [Fact]
        public void ResolveWhenPageOfDifferentAssembly()
        {
            ViewTypeToViewModelTypeResolver.MappingAssemblies(typeof(TestPage).Assembly, typeof(TestPageViewModel).Assembly);
            var actual = ViewTypeToViewModelTypeResolver.Resolve(typeof(TestPage));
            Assert.Equal(typeof(TestPageViewModel), actual);
        }

        [Fact]
        public void MappingAssembliesWhenViewTypeAssemblyIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => ViewTypeToViewModelTypeResolver.MappingAssemblies(null, GetType().Assembly));
        }

        [Fact]
        public void MappingAssembliesWhenViewModelTypeAssemblyIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => ViewTypeToViewModelTypeResolver.MappingAssemblies(GetType().Assembly, null));
        }
    }

    namespace Views
    {
        public class MockView
        {
        }

        public class MockPage
        {
        }
    }

    namespace ViewModels
    {
        public class MockViewModel
        {
        }

        public class MockPageViewModel
        {
        }
    }
}
