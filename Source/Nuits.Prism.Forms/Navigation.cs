using System.ComponentModel;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Nuits.Prism
{
    /// <summary>
    /// This class abstracts page navigation.
    /// </summary>
    public class Navigation
    {
        /// <summary>
        /// Page navigation name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Parameters of page navigation.
        /// </summary>
        public NavigationParameters Parameters { get; set; }

        /// <summary>
        /// Create Instance.
        /// </summary>
        /// <param name="name">Page navigation name.</param>
        public Navigation(string name)
        {
            Name = name;
            Parameters = new NavigationParameters();
        }

        /// <summary>
        /// To page navigation string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Parameters != null && 0 < Parameters.Count)
            {
                return Name + Parameters;
            }
            else
            {
                return Name;
            }
        }

        /// <summary>
        /// Create instance from Page.
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <returns></returns>
        public static Navigation FromView<TView>() where TView : Page
        {
            return new Navigation(typeof(TView).Name);
        }
    }

    /// <summary>
    /// Class representing page navigation using ViewModel.
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class Navigation<TViewModel> : Navigation where TViewModel : class, INotifyPropertyChanged
    {
        public Navigation() : base(NavigationNameProvider.GetNavigationName<TViewModel>())
        {
        }
    }
}
