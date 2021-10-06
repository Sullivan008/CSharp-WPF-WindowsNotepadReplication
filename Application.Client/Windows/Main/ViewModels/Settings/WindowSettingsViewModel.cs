using Application.Client.Common.ViewModels;
using Application.Client.Services.DocInfo.Interfaces;

namespace Application.Client.Windows.Main.ViewModels.Settings
{
    public class WindowSettingsViewModel : ViewModelBase
    {
        private readonly IDocInfoService _docInfoService;

        public WindowSettingsViewModel(IDocInfoService docInfoService)
        {
            _docInfoService = docInfoService;
        }

        private string _title;
        public string Title
        {
            get
            {
                const string WINDOW_TITLE_POSTFIX = " - Notepad";

                return $"{_title ?? _docInfoService.UsedFileNameWithoutExtension}{WINDOW_TITLE_POSTFIX}";
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private bool _activated;
        public bool Activated
        {
            get => _activated;
            set
            {
                _activated = value;
                OnPropertyChanged();
            }
        }
    }
}
