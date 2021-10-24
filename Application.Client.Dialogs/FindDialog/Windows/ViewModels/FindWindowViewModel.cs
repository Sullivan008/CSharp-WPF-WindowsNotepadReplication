using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Application.Client.Common.ViewModels;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows.Commands;
using Application.Client.Dialogs.FindDialog.Windows.Commands.Shared;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels.Enums;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Client.Dialogs.FindDialog.Windows.ViewModels
{
    internal class FindWindowViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IValidator<FindWindowViewModel> _validator;

        private readonly IFindDialogSettingsService _findDialogSettingsService;

        public FindWindowViewModel(IValidator<FindWindowViewModel> validator, IFindDialogSettingsService findDialogSettingsService)
        {
            _validator = validator;
            _findDialogSettingsService = findDialogSettingsService;
        }

        private ICommand? _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this);

        private ICommand? _findNextCommand;
        public ICommand FindNextCommand => _findNextCommand ??= new FindNextCommand(this, _validator);

        private ICommand? _loadDialogSettingsFromCache;
        public ICommand LoadDialogSettingsFromCache => _loadDialogSettingsFromCache ??= new LoadDialogSettingsFromCache(this, _findDialogSettingsService);

        private ICommand? _updateDialogSettingsInCache;
        public ICommand UpdateDialogSettingsInCache => _updateDialogSettingsInCache ??= new UpdateDialogSettingsInCache(this, _findDialogSettingsService);


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

        private DirectionType _directionType = DirectionType.Up;
        public DirectionType DirectionType
        {
            get => _directionType;
            set
            {
                _directionType = value;
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
