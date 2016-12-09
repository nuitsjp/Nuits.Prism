using System;
using System.Collections.Generic;
using System.Reflection;
using Prism.Mvvm;

namespace Nuits.Prism.Navigation
{
    public static class PageNavigationInfoProvider
    {
        public static PageNavigationInfoResolver PageNavigationInfoResolver { get; set; } = new PageNavigationInfoResolver();
        private static Dictionary<Type, PageNavigationInfo> PageNavigationInfos { get; } = new Dictionary<Type, PageNavigationInfo>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModelType"></param>
        /// <returns></returns>
        public static PageNavigationInfo RegisterPageNavigationInfo(Type viewType, Type viewModelType)
        {
            var pageNavigationInfo = PageNavigationInfoResolver.Resolve(viewType, viewModelType);

            PageNavigationInfos[viewModelType] = pageNavigationInfo;

            return pageNavigationInfo;
        }

        public static PageNavigationInfo GetPageNavigationInfo<TViewModel>() where TViewModel : BindableBase
        {
            return GetPageNavigationInfo(typeof(TViewModel));
        }

        public static PageNavigationInfo GetPageNavigationInfo(Type viewModelType)
        {
            PageNavigationInfo result;
            if (PageNavigationInfos.TryGetValue(viewModelType, out result))
            {
                return result;
            }
            else
            {
                throw new InvalidOperationException($"PageNavigationInfo is not registerd. View model type is {viewModelType.Name}.");
            }
        }
    }
}
