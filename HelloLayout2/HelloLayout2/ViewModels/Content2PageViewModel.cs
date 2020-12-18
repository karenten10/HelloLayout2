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
    public class Content2PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;

        public string SubTitle { get; set; } = "按電梯";
        public string Content { get; set; } = "小華有次進電梯以後，顧著照鏡子，忘記按電梯了，結果一個人剛好走進電梯，跟他說，你忘記按電梯了哄";

        public DelegateCommand GoNextCommand { get; set; }

        public Content2PageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            GoNextCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("/MDPage/NaviPage/MainPage");
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
