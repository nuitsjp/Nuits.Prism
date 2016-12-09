﻿using System.ComponentModel;
using Nuits.Prism.Navigation;
using Xamarin.Forms;
using Xunit;

// ReSharper disable ClassNeverInstantiated.Local

namespace Nuits.Prism.Forms.Tests
{
    //public class NavigationFixture
    //{
    //    [Fact]
    //    public void Constructor()
    //    {
    //        var actual = new PageNavigation("NameProperty");
    //        Assert.Equal("NameProperty", actual.Name);
    //        Assert.NotNull(actual.Parameters);
    //    }

    //    [Fact]
    //    public void GenericsConstructor()
    //    {
    //        NavigationNameProvider.RegisterNavigation<TestViewModel>();
    //        var actual = new PageNavigation<TestViewModel>();
    //        Assert.Equal("Test", actual.Name);
    //        Assert.NotNull(actual.Parameters);
    //    }

    //    [Fact]
    //    public void ToStringWhenEmptyParameters()
    //    {
    //        var actual = new PageNavigation("NameProperty");
    //        Assert.Equal("NameProperty", actual.ToString());
    //    }

    //    [Fact]
    //    public void ToStringWithParameters()
    //    {
    //        // ReSharper disable once UseObjectOrCollectionInitializer
    //        var actual = new PageNavigation("NameProperty");
    //        actual.Parameters["key1"] = "value1";
    //        actual.Parameters["key2"] = "value2";
    //        Assert.Equal("NameProperty?key1=value1&key2=value2", actual.ToString());
    //    }

    //    [Fact]
    //    public void FromView()
    //    {
    //        var actual = PageNavigation.FromView<TestPage>();
    //        Assert.NotNull(actual);
    //        Assert.Equal("TestPage", actual.Name);
    //    }


    //    private class TestViewModel : INotifyPropertyChanged
    //    {
    //        public event PropertyChangedEventHandler PropertyChanged;

    //        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    //        {
    //            PropertyChanged?.Invoke(this, e);
    //        }
    //    }

    //    private class TestPage : Page { }
    //}
}