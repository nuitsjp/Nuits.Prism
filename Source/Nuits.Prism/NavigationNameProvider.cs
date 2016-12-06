using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Prism.Mvvm;

namespace Nuits.Prism
{
    /// <summary>
    /// This class provides Provide Navigation Name from ViewModel.
    /// </summary>
    public static class NavigationNameProvider
    {
        /// <summary>
        /// Provider which is set by default in <see cref="NavigationNameResolver"/>.
        /// </summary>
        public static readonly Func<Type, string> DefaultNavigationNameResolver = ResolveNavigationName;
        /// <summary>
        /// Cache of page navigation names.
        /// </summary>
        private static readonly IDictionary<Type, string> NavigationNamesCache = new Dictionary<Type, string>();
        /// <summary>
        /// Func to Resolve the page navigation name from ViewModel.
        /// </summary>
        public static Func<Type, string> NavigationNameResolver { get; set; } = DefaultNavigationNameResolver;
        /// <summary>
        /// Get the page navigation name of ViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel type.</typeparam>
        /// <returns>Page navigation name.</returns>
        public static string GetNavigationName<TViewModel>() where TViewModel : class, INotifyPropertyChanged
        {
            if(!NavigationNamesCache.ContainsKey(typeof(TViewModel)))
                throw new ArgumentException($"{typeof(TViewModel).Name} is not registered.");

            return NavigationNamesCache[typeof(TViewModel)];
        }

        /// <summary>
        /// Register the page navigation name of ViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">ViewModel type.</typeparam>
        /// <returns>Registerd page navigation name.</returns>
        public static string RegisterNavigation<TViewModel>()
        {
            if (NavigationNamesCache.ContainsKey(typeof(TViewModel)))
            {
                NavigationNamesCache.Remove(typeof(TViewModel));
            }

            var attribute = typeof(TViewModel).GetTypeInfo().GetCustomAttribute<NavigationNameAttribute>();
            var navigationName = attribute == null ? NavigationNameResolver(typeof(TViewModel)) : attribute.Name;

            NavigationNamesCache[typeof(TViewModel)] = navigationName;

            return navigationName;
        }

        /// <summary>
        /// Resolve page navigation name.
        /// </summary>
        /// <param name="type">Type to Resolve.</param>
        /// <returns>Page navigation name.</returns>
        private static string ResolveNavigationName(Type type)
        {
            if (type.Name.EndsWith("ViewModel"))
            {
                return type.Name.Substring(0, type.Name.LastIndexOf("ViewModel", StringComparison.Ordinal));
            }
            else
            {
                return type.Name;
            }
        }
    }
}