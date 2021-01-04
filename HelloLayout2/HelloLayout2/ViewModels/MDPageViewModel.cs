using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloLayout2.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MDPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;

        public DelegateCommand ToMainCommand { get; set; }

        public DelegateCommand ToScrollCommand { get; set; }

        public DelegateCommand ToPhotoCommand { get; set; }

        public MDPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            ToMainCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("/MDPage/NaviPage/MainPage");
            });

            ToScrollCommand = new DelegateCommand(()=>
            {
                navigationService.NavigateAsync("/MDPage/NaviPage/TestScrollPage");
            });

            ToPhotoCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("/MDPage/NaviPage/PhotoPage");
            });

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
