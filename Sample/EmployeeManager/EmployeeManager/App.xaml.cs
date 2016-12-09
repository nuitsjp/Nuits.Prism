﻿using EmployeeManager.Models.Services;
using EmployeeManager.Models.Services.Local;
using EmployeeManager.Models.Usecases;
using EmployeeManager.ViewModels;
using Prism.Unity;
using EmployeeManager.Views;
using Microsoft.Practices.Unity;
using Nuits.Prism;
using Nuits.Prism.Navigation;
using Nuits.Prism.Unity;
using Xamarin.Forms;
using ContainerControlledLifetimeManager = Microsoft.Practices.Unity.ContainerControlledLifetimeManager;

namespace EmployeeManager
{
    public partial class App
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void RegisterTypes()
        {
            // Add Services.
            Container.RegisterType(typeof(IEmployeeService), typeof(EmployeeService), new ContainerControlledLifetimeManager());
            //// Add Usecases.
            Container.RegisterType(typeof(IReferSections), typeof(ReferSections), new ContainerControlledLifetimeManager());

            // Add Views.
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForViewModelNavigation<MainPageViewModel>();
            Container.RegisterTypeForViewModelNavigation<SectionListPageViewModel>();
            Container.RegisterTypeForViewModelNavigation<SectionPageViewModel>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(
                new PageNavigation(nameof(NavigationPage)),
                new PageNavigation<MainPageViewModel>());
        }
    }
}
