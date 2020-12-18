using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloLayout2.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;

        public string Title { get; set; } = "首頁";

        public string SubTitle { get; set; } = "職業使然";
        public string Content { get; set; } = "小明每天都在滑Candy Crush，有一天在廁所蹲馬桶的時候，看著地上的馬賽克地磚，無意間開始構思怎麼滑Candy Crush";

        public DelegateCommand GoNextCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            GoNextCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("/MDPage/NaviPage/Content2Page");
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
