using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Application.Client.Common.ViewModels;
using Application.Client.Dialogs.ReplaceDialog.Services.Interfaces;
using Application.Client.Dialogs.ReplaceDialog.Windows.Commands;
using Application.Client.Dialogs.ReplaceDialog.Windows.Commands.Shared;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels
{
    internal class ReplaceWindowViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IValidator<ReplaceWindowViewModel> _validator;

        private readonly IReplaceDialogSettingsService _replaceDialogSettingsService;

        public ReplaceWindowViewModel(IValidator<ReplaceWindowViewModel> validator, IReplaceDialogSettingsService replaceDialogSettingsService)
        {
            _validator = validator;
            _replaceDialogSettingsService = replaceDialogSettingsService;
        }

        private ICommand? _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this);

        private ICommand? _replaceCommand;
        public ICommand ReplaceCommand => _replaceCommand ??= new ReplaceCommand(this);

        private ICommand? _replaceAllCommand;
        public ICommand ReplaceAllCommand => _replaceAllCommand ??= new ReplaceAllCommand(this);

        private ICommand? _findNextCommand;
        public ICommand FindNextCommand => _findNextCommand ??= new FindNextCommand(this, _validator);

        private ICommand? _loadDialogSettingsFromCache;
        public ICommand LoadDialogSettingsFromCache => _loadDialogSettingsFromCache ??= new LoadDialogSettingsFromCache(this, _replaceDialogSettingsService);

        private ICommand? _updateDialogSettingsInCache;
        public ICommand UpdateDialogSettingsInCache => _updateDialogSettingsInCache ??= new UpdateDialogSettingsInCache(this, _replaceDialogSettingsService);


        private string _findWhat = string.Empty;
        public string FindWhat
        {
            get => _findWhat;
            set
            {
                _findWhat = value;
                OnPropertyChanged();
            }
        }

        private string _replaceWith = string.Empty;
        public string ReplaceWith
        {
            get => _replaceWith;
            set
            {
                _replaceWith = value;
                OnPropertyChanged();
            }
        }

        private bool _isMatchCase;
        public bool IsMatchCase
        {
            get => _isMatchCase;
            set
            {
                _isMatchCase = value;
                OnPropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get
            {
                ValidationResult validationResult = _validator.Validate(this);

                if (!validationResult.IsValid)
                {
                    IReadOnlyList<ValidationFailure> validationFailures = validationResult.Errors;

                    if (validationFailures.Any(x => x.PropertyName == columnName))
                    {
                        return validationFailures.First(x => x.PropertyName == columnName).ErrorMessage;
                    }
                }

                return string.Empty;
            }
        }
        public string Error
        {
            get
            {
                ValidationResult validationResult = _validator.Validate(this);

                if (validationResult != null && validationResult.Errors.Any())
                {
                    return string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
                }

                return string.Empty;
            }
        }
    }
}
