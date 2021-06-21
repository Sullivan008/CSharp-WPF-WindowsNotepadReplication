﻿using System.Collections.Generic;
using System.Linq;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Dialogs.StaticValues;
using Application.Client.Dialogs.StaticValues.Enums;
using Application.Client.Dialogs.StaticValues.Models;
using Application.Client.Infrastructure.ViewModels;
using Application.Client.Services.Interfaces;
using Application.Client.Windows.Main.ViewModels.Interfaces;
using Application.Utilities.FileReader.Interfaces;
using Application.Utilities.FileWriter.Interfaces;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMessageDialog _messageDialog;

        private readonly IOpenFileDialog _openFileDialog;

        private readonly ISaveFileDialog _saveFileDialog;

        private readonly ITextFileWriter _textFileWriter;

        private readonly ITextFileReader _textFileReader;

        private readonly IDocInfoService _docInfoService;

        public MainWindowViewModel(IMessageDialog messageDialog, IOpenFileDialog openFileDialog, ISaveFileDialog saveFileDialog,
            ITextFileWriter textFileWriter, ITextFileReader textFileReader, IDocInfoService docInfoService)
        {
            _messageDialog = messageDialog;
            _openFileDialog = openFileDialog;
            _saveFileDialog = saveFileDialog;
            _textFileWriter = textFileWriter;
            _textFileReader = textFileReader;

            _docInfoService = docInfoService;
        }

        #region PROPERTIES GETTERS/ SETTERS

        private string _windowTitle;
        public string WindowTitle
        {
            get
            {
                const string WINDOW_TITLE_POSTFIX = " - Notepad";

                return $"{_windowTitle ?? _docInfoService.UsedFileNameWithoutExtension}{WINDOW_TITLE_POSTFIX}";
            }
            set
            {
                _windowTitle = value;
                OnPropertyChanged();
            }
        }

        private string _content = string.Empty;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();

                if (!_docInfoService.IsModifiedDocument)
                {
                    _docInfoService.SetModifiedDocumentState();
                }
            }
        }

        private string _selectedText = string.Empty;
        public string SelectedText
        {
            get => _selectedText;
            set
            {
                _selectedText = value;
                OnPropertyChanged();

                RefreshStatusBar();
            }
        }

        private int _caretIndex;
        public int CaretIndex
        {
            get => _caretIndex;
            set
            {
                _caretIndex = value;
                OnPropertyChanged();
            }
        }

        private StatusBarViewModel _statusBar = new();
        public StatusBarViewModel StatusBar
        {
            get => _statusBar;
            set
            {
                _statusBar = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private static IReadOnlyDictionary<string, IReadOnlyList<string>> GetOpenFileDialogFilters()
        {
            IReadOnlyList<FileFilterModel> fileFilters = FileFilters.GetFileFiltersByFilterTypes(new[] { FileFilterType.Text });

            return fileFilters.ToDictionary(x => x.FilterName, y => y.Filters);
        }

        private static IReadOnlyDictionary<string, IReadOnlyList<string>> GetSaveFileDialogFilters()
        {
            IReadOnlyList<FileFilterModel> fileFilters = FileFilters.GetFileFiltersByFilterTypes(new[] { FileFilterType.Text });

            return fileFilters.ToDictionary(x => x.FilterName, y => y.Filters);
        }

        private void RefreshStatusBar()
        {
            const string ROW_SEPARATOR = "\n";

            StatusBar = new StatusBarViewModel
            {
                Length = Content.Length,
                Visibility = StatusBar.Visibility,
                Lines = Content.Split(ROW_SEPARATOR).Length
            };
        }
    }
}
