using System;

namespace Nuits.Prism.Navigation
{
    public class PageNavigationInfo
    {
        public string Name { get; }

        public Type ViewModelType { get; }

        public Type ViewType { get; }

        public PageNavigationInfo(string name, Type viewType, Type viewModelType)
        {
            Name = name;
            ViewModelType = viewModelType;
            ViewType = viewType;
        }
    }
}
