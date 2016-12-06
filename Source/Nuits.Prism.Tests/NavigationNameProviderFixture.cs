using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nuits.Prism;
using Xunit;

// ReSharper disable ClassNeverInstantiated.Local

namespace Prism.Forms.Toolkit.Tests
{
    public class NavigationNameProviderFixture
    {
        [Fact]
        public void DefaultNavigationNameResolver()
        {
            Assert.Equal("TestPage", NavigationNameProvider.DefaultNavigationNameResolver(typeof(TestPageViewModel)));
            Assert.Equal("TestPageViewModel",
                NavigationNameProvider.DefaultNavigationNameResolver(typeof(TestPageViewModelViewModel)));
            Assert.Equal("TestBindable", NavigationNameProvider.DefaultNavigationNameResolver(typeof(TestBindable)));
        }

        [Fact]
        public void ProvideNavigationName()
        {
            Assert.Equal("TestPage", NavigationNameProvider.RegisterNavigation<TestPageViewModel>());
            Assert.Equal("TestPage", NavigationNameProvider.GetNavigationName<TestPageViewModel>());
        }

        [Fact]
        public void CanNotProvideNavigationNameWhenNotRegistered()
        {
            var exception =
                Assert.Throws<ArgumentException>(() => NavigationNameProvider.GetNavigationName<TestBindable>());

            Assert.Equal("TestBindable is not registered.", exception.Message);
        }

        [Fact]
        public void UpdateNavigationNameWhenChangedResolver()
        {
            try
            {
                NavigationNameProvider.RegisterNavigation<TestPageViewModel>();
                // Replace NavigationNameResolver
                NavigationNameProvider.NavigationNameResolver = type => type.Name;
                // Update navigation name
                Assert.Equal("TestPageViewModel", NavigationNameProvider.RegisterNavigation<TestPageViewModel>());
                Assert.Equal("TestPageViewModel", NavigationNameProvider.GetNavigationName<TestPageViewModel>());
            }
            finally
            {
                NavigationNameProvider.NavigationNameResolver = NavigationNameProvider.DefaultNavigationNameResolver;
            }
        }

        [Fact]
        public void ProvideNavigationNameWhenAttributedViewModel()
        {
            Assert.Equal("AttributedNavigationName", NavigationNameProvider.RegisterNavigation<AttributedViewModel>());
            Assert.Equal("AttributedNavigationName", NavigationNameProvider.GetNavigationName<AttributedViewModel>());
        }

        private class TestPageViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }

        private class TestPageViewModelViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }

        private class TestBindable : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }

        [NavigationName("AttributedNavigationName")]
        private class AttributedViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}