﻿using System.Collections.Generic;
using System.Linq;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Dialogs.StaticValues;
using Application.Client.Dialogs.StaticValues.Enums;
using Application.Client.Dialogs.StaticValues.Models;
using Application.Client.Infrastructure.ViewModels;
using Application.Client.Windows.Main.Services.Enums;
using Application.Client.Windows.Main.Services.Interfaces;
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

        private readonly INotepadStorageService _notepadStorageService;

        public MainWindowViewModel(IMessageDialog messageDialog, IOpenFileDialog openFileDialog, ISaveFileDialog saveFileDialog,
            ITextFileWriter textFileWriter, ITextFileReader textFileReader, INotepadStorageService notepadStorageService)
        {
            _messageDialog = messageDialog;
            _openFileDialog = openFileDialog;
            _saveFileDialog = saveFileDialog;
            _textFileWriter = textFileWriter;
            _textFileReader = textFileReader;

            _notepadStorageService = notepadStorageService;
        }

        #region PROPERTIES GETTERS/ SETTERS

        private string _windowTitle;
        public string WindowTitle
        {
            get => $"{_windowTitle ?? _notepadStorageService.UsedFileNameWithoutExtension} - Notepad";
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

                if (!_notepadStorageService.HasDocumentModified)
                {
                    _notepadStorageService.SetDocumentState(DocumentState.Modified);
                }

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
    }
}
