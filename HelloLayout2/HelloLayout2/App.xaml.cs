using HelloLayout2.ViewModels;
using HelloLayout2.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace HelloLayout2
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/MDPage/NaviPage/MainPage");
            // await NavigationService.NavigateAsync("/MDPage/NaviPage/TestPage");
            // await NavigationService.NavigateAsync("/MDPage/NaviPage/TestScrollPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MDPage, MDPageViewModel>();
            containerRegistry.RegisterForNavigation<NaviPage, NaviPageViewModel>();
            containerRegistry.RegisterForNavigation<Content2Page, Content2PageViewModel>();
            containerRegistry.RegisterForNavigation<TestPage, TestPageViewModel>();
            containerRegistry.RegisterForNavigation<TestScrollPage, TestScrollPageViewModel>();
            containerRegistry.RegisterForNavigation<PhotoPage, PhotoPageViewModel>();
        }
    }
}
