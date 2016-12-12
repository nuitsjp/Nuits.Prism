using System;

namespace Nuits.Prism.Navigation
{
    /// <summary>
    /// Attribute for giving ViewModel a special page navigation navigationName.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class PageNavigationAttribute : Attribute
    {
        /// <summary>
        /// The navigationName of the target to navigate to.
        /// </summary>
        public string NavigationName { get; }
        /// <summary>
        /// 
        /// </summary>
        public string ViewTypeName { get; }

        /// <summary>
        /// Create instance.
        /// </summary>
        /// <param name="navigationName">Page navigation navigationName.</param>
        /// <param name="viewTypeName"></param>
        public PageNavigationAttribute(string navigationName, string viewTypeName = null)
        {
            NavigationName = navigationName;
            ViewTypeName = viewTypeName ?? NavigationName;
        }
    }
}
