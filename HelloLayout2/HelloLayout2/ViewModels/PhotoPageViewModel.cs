using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloLayout2.ViewModels
{
    using System.ComponentModel;
    using Plugin.Media;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    public class PhotoPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource MyImageSource { get; set; } = ImageSource.FromFile("DefaultImage.jpg");

        private readonly INavigationService navigationService;
        public readonly IPageDialogService _dialogService;

        public DelegateCommand TakeCommand { get; set; }

        public PhotoPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            _dialogService = dialogService;

            TakeCommand = new DelegateCommand(async () =>
            {
                // 進行 Plugin.Media 套件的初始化動作
                await CrossMedia.Current.Initialize();

                // 確認這個裝置是否具有拍照的功能
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await _dialogService.DisplayAlertAsync("No Camera", ":( No camera available.", "OK");
                    return;
                }

                // 啟動拍照功能，並且儲存到指定的路徑與檔案中
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "Sample.jpg"
                });

                if (file == null)
                    return;

                // 讀取剛剛拍照的檔案內容，轉換成為 ImageSource，如此，就可以顯示到螢幕上了
                MyImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
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
