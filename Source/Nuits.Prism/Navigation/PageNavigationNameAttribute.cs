using System;

namespace Nuits.Prism.Navigation
{
    /// <summary>
    /// Attribute for giving ViewModel a special page navigation name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class PageNavigationNameAttribute : Attribute
    {
        /// <summary>
        /// The name of the target to navigate to.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create instance.
        /// </summary>
        /// <param name="name">Page navigation name.</param>
        public PageNavigationNameAttribute(string name)
        {
            Name = name;
        }
    }
}
