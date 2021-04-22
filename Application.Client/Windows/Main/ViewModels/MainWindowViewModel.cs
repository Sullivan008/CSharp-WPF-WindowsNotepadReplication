using System.Collections.Generic;
using System.Linq;
using Application.Client.Core.Dialogs.MessageDialog.Interfaces;
using Application.Client.Core.Dialogs.OpenFileDialog.Interfaces;
using Application.Client.Core.Dialogs.SaveFileDialog.Interfaces;
using Application.Client.Core.Dialogs.StaticValues;
using Application.Client.Core.Dialogs.StaticValues.Enums;
using Application.Client.Core.Dialogs.StaticValues.Models;
using Application.Client.Core.Services.FileReader.Interfaces;
using Application.Client.Core.Services.FileWriter.Interfaces;
using Application.Client.Core.ViewModels;
using Application.Client.Windows.Main.Services.Enums;
using Application.Client.Windows.Main.Services.Interfaces;
using Application.Client.Windows.Main.ViewModels.Interfaces;

namespace Application.Client.Windows.Main.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMessageDialogService _messageDialogService;

        private readonly IOpenFileDialogService _openFileDialogService;

        private readonly ISaveFileDialogService _saveFileDialogService;

        private readonly ITextFileWriterService _textFileWriterService;

        private readonly ITextFileReaderService _textFileReaderService;

        private readonly INotepadStorageService _notepadStorageService;

        public MainWindowViewModel(IMessageDialogService messageDialogService, IOpenFileDialogService openFileDialogService, ISaveFileDialogService saveFileDialogService,
            ITextFileWriterService textFileWriterService, ITextFileReaderService textFileReaderService, INotepadStorageService notepadStorageService)
        {
            _messageDialogService = messageDialogService;
            _openFileDialogService = openFileDialogService;
            _saveFileDialogService = saveFileDialogService;
            _textFileWriterService = textFileWriterService;
            _textFileReaderService = textFileReaderService;

            _notepadStorageService = notepadStorageService;
        }

        #region PROPERTIES GETTERS/ SETTERS

        private string _windowTitle = "Unnamed";
        public string WindowTitle
        {
            get => $"{_windowTitle} - Notepad";
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

        private static IReadOnlyDictionary<string, IReadOnlyList<string>> GetSaveFileDialogFilters()
        {
            IReadOnlyList<FileFilterType> fileFilterTypes = new[] { FileFilterType.Text };

            IReadOnlyList<FileFilterModel> fileFilters = FileFilters.GetFileFiltersByFilterTypes(fileFilterTypes);

            return fileFilters.ToDictionary(x => x.FilterName, y => y.Filters);
        }
    }
}
