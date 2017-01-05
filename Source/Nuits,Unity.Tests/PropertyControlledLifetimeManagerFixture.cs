using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xunit;

namespace Nuits_Unity.Tests
{
    public class PropertyControlledLifetimeManagerFixture
    {
        [Fact]
        public void ConstructorWhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new PropertyControlledLifetimeManager<MockObject>(null));
        }

        [Fact]
        public void ConstructorWhenExpressionMemberIsNotMemberExpression()
        {
            Assert.Throws<ArgumentException>(() => new PropertyControlledLifetimeManager<MockObject>(x => true));
        }

        [Fact]
        public void SetValueWhenArgumentIsNull()
        {
            var actual = new PropertyControlledLifetimeManager<MockObject>(x => x.IsCompleted);
            Assert.Throws<ArgumentNullException>(() => actual.SetValue(null));
        }

        [Fact]
        public void SetValueWhenArgumentIsInvalidType()
        {
            var actual = new PropertyControlledLifetimeManager<MockObject>(x => x.IsCompleted);
            Assert.Throws<ArgumentException>(() => actual.SetValue(string.Empty));
        }

        [Fact]
        public void PropertyControlledLifetimeWhenValueIsNotDisposable()
        {
            var actual = new PropertyControlledLifetimeManager<MockObject>(x => x.IsCompleted);
            
            Assert.Null(actual.GetValue());

            var mock = new MockObject();
            actual.SetValue(mock);
            Assert.Equal(mock, actual.GetValue());

            mock.IsCompleted = false;
            Assert.Equal(mock, actual.GetValue());

            mock.IsCompleted = true;
            Assert.Null(actual.GetValue());
        }

        [Fact]
        public void PropertyControlledLifetimeWhenValueIsDisposable()
        {
            var actual = new PropertyControlledLifetimeManager<DisposableObject>(x => x.IsCompleted);

            var mock = new DisposableObject();
            actual.SetValue(mock);
            Assert.Equal(mock, actual.GetValue());

            mock.IsCompleted = true;
            Assert.Null(actual.GetValue());

            Assert.True(mock.Disposed);
        }

        private class MockObject : INotifyPropertyChanged
        {
            private bool _isCompleted = true;

            public bool IsCompleted
            {
                get { return _isCompleted; }
                set { SetProperty(ref _isCompleted, value); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private class DisposableObject : MockObject, IDisposable
        {
            public bool Disposed { get; set; }

            public DisposableObject()
            {
                IsCompleted = false;
            }

            public void Dispose()
            {
                Disposed = true;
            }
        }
    }
}
