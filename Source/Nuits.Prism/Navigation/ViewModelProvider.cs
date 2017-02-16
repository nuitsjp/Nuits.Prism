using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Nuits.Prism.Navigation
{
    public static class ViewModelProvider
    {
        private static Func<Type, object> _viewModelFactory = type => Activator.CreateInstance(type);

        public static void SetViewModelFactory(Func<Type, object> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public static object Create<TViewModel>() where TViewModel : BindableBase
        {
            var type = PageNavigationInfoProvider.GetViewModelType<TViewModel>();
            return _viewModelFactory(type);
        }
    }
}
