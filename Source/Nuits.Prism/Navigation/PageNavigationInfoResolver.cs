using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace Nuits.Prism.Navigation
{
    public class PageNavigationInfoResolver
    {
        public virtual PageNavigationInfo Resolve(Type viewType, Type viewModelType)
        {
            var viewTypeName = viewModelType.Name.Substring(0, viewModelType.Name.IndexOf("ViewModel", StringComparison.Ordinal));
            var viewTypeFullName = $"{viewModelType.Namespace.Replace("ViewModels", "Views")}.{viewTypeName}";
            var type = viewType ?? viewModelType.GetTypeInfo().Assembly.GetType(viewTypeFullName);
            return 
                new PageNavigationInfo(
                    viewTypeName,
                    ResolveViewTypeForViewModelType(viewType, viewModelType), 
                    viewModelType);
        }

        protected virtual Type ResolveViewTypeForViewModelType(Type viewType, Type viewModelType)
        {
            if (viewType == null)
            {
                var viewTypeName = viewModelType.Name.Substring(0, viewModelType.Name.IndexOf("ViewModel", StringComparison.Ordinal));
                var viewTypeFullName = $"{viewModelType.Namespace.Replace("ViewModels", "Views")}.{viewTypeName}";
                return viewModelType.GetTypeInfo().Assembly.GetType(viewTypeFullName);
            }
            else
            {
                return viewType;
            }
        }
    }
}
