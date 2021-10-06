using System;
using System.Windows;
using Application.Client.Common.ViewModels;
using Application.Client.Services.DocInfo.Interfaces;

namespace Application.Client.Windows.Main.ViewModels.StatusBar
{
    public class StatusBarViewModel : ViewModelBase
    {
        private readonly IDocInfoService _docInfoService;

        public StatusBarViewModel(IDocInfoService docInfoService)
        {
            _docInfoService = docInfoService;
        }

        private Visibility _visibility = Visibility.Visible;
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        private int _length;
        public int Length
        {
            get => _length;
            private set
            {
                _length = value;
                OnPropertyChanged();
            }
        }

        private int _lines = default(int) + 1;
        public int Lines
        {
            get => _lines;
            private set
            {
                _lines = value;
                OnPropertyChanged();
            }
        }

        public void RefreshOutputData(string content)
        {
            Lines = GetContentLines(content);
            Length = GetContentLength(content);

            _docInfoService.SetContentLines(Lines);
            _docInfoService.SetContentLength(Length);
        }

        private static int GetContentLength(string content) => content.Length;

        private static int GetContentLines(string content)
        {
            return content.Split(Environment.NewLine).Length;
        }
    }
}
