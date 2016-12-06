using System;
using System.Reflection;

namespace Nuits.Prism
{
    public class ViewTypeToViewModelTypeResolver
    {
        private readonly Assembly _assembly;

        public ViewTypeToViewModelTypeResolver(Assembly assembly)
        {
            _assembly = assembly;
        }

        public Type Resolve(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));

            // ReSharper disable once PossibleNullReferenceException
            var vmTypeName = $"{viewType.Namespace.Replace("Views", "ViewModels")}.{viewType.Name}ViewModel";
            var vmType = _assembly.GetType(vmTypeName);
            return vmType;
        }
    }
}
