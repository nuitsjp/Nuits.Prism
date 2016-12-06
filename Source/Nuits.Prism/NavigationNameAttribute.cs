using System;

namespace Nuits.Prism
{
    /// <summary>
    /// Attribute for giving ViewModel a special page navigation name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class NavigationNameAttribute : Attribute
    {
        /// <summary>
        /// The name of the target to navigate to.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create instance.
        /// </summary>
        /// <param name="name">Page navigation name.</param>
        public NavigationNameAttribute(string name)
        {
            Name = name;
        }
    }
}
