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
        private readonly Dictionary<Assembly, Assembly> assemblies = new Dictionary<Assembly, Assembly>();

        public void AddAssemblies(Assembly viewTypeAssembly, Assembly viewModelTypeAssembly)
        {
            if (viewTypeAssembly == null) throw new ArgumentNullException(nameof(viewTypeAssembly));
            if (viewModelTypeAssembly == null) throw new ArgumentNullException(nameof(viewModelTypeAssembly));

            assemblies[viewModelTypeAssembly] = viewTypeAssembly;
        }

        public virtual PageNavigationInfo Resolve(Type viewType, Type viewModelType)
        {
            var pageNavigationAttribute = viewModelType.GetTypeInfo().GetCustomAttribute<PageNavigationAttribute>();

            var pageNavigationName = pageNavigationAttribute?.NavigationName ?? ResolveNavigationName(viewModelType);

            Type pageNavigationViewType;
            if (viewType == null)
            {
                var viewTypeFullName = ResolveViewTypeFullName(viewModelType, pageNavigationAttribute?.ViewTypeName);
                pageNavigationViewType = ResolveViewType(viewModelType, viewTypeFullName);
            }
            else
            {
                pageNavigationViewType = viewType;
            }

            if (pageNavigationViewType == null)
            {
                throw new InvalidOperationException($"View corresponding to ViewModel does not exist. ViewModel is {viewModelType.Name}.");
            }

            return new PageNavigationInfo(pageNavigationName, pageNavigationViewType, viewModelType);
        }

        protected virtual string ResolveNavigationName(Type viewModelType)
        {
            return viewModelType.Name.Substring(0, viewModelType.Name.IndexOf("ViewModel", StringComparison.Ordinal));
        }

        protected virtual string ResolveViewTypeFullName(Type viewModelType, string viewTypeNameOfAttribute)
        {
            var viewTypeName = viewTypeNameOfAttribute ?? viewModelType.Name.Substring(0, viewModelType.Name.IndexOf("ViewModel", StringComparison.Ordinal));
            return $"{viewModelType.Namespace.Replace("ViewModels", "Views")}.{viewTypeName}";
        }

        protected Assembly GetViewTypeAssembly(Assembly viewModelTypeAssembly)
        {
            Assembly viewTypeAssembly;
            if (!assemblies.TryGetValue(viewModelTypeAssembly, out viewTypeAssembly))
            {
                viewTypeAssembly = viewModelTypeAssembly;
                assemblies[viewModelTypeAssembly] = viewTypeAssembly;
            }
            return viewTypeAssembly;
        }

        protected virtual Type ResolveViewType(Type viewModelType, string viewTypeFullName)
        {
            return GetViewTypeAssembly(viewModelType.GetTypeInfo().Assembly).GetType(viewTypeFullName);
        }
    }
}
