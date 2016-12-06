using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Nuits.Prism;

namespace EmployeeManager.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigationSectionListCommand { get; }
        public DelegateCommand DeepLinkByLiteralCommand { get; }
        public DelegateCommand DeepLinkByViewModelCommand { get; }
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigationSectionListCommand = 
                new DelegateCommand(() => _navigationService.NavigateAsync<SectionListPageViewModel>());

            DeepLinkByLiteralCommand =
                new DelegateCommand(
                    () => _navigationService.NavigateAsync(
                        "/NavigationPage/MainPage/SectionListPage/SelectedSection?sectionId=5"));

            DeepLinkByViewModelCommand = new DelegateCommand(() =>
            {
                // ReSharper disable once UseObjectOrCollectionInitializer
                var sectionPageNavigation = new Navigation<SectionPageViewModel>();
                sectionPageNavigation.Parameters[SectionPageViewModel.SectionIdKey] = 9;

                _navigationService.NavigateAsync(
                    new Navigation("NavigationPage"),
                    new Navigation<MainPageViewModel>(),
                    new Navigation<SectionListPageViewModel>(),
                    sectionPageNavigation);
            });
        }
    }
}
