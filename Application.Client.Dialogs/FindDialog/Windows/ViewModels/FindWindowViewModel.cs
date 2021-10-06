using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Application.Client.Dialogs.FindDialog.Delegates;
using Application.Client.Dialogs.FindDialog.Services.Interfaces;
using Application.Client.Dialogs.FindDialog.Windows.Commands;
using Application.Client.Dialogs.FindDialog.Windows.ViewModels.Enums;
using Application.Client.Infrastructure.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Client.Dialogs.FindDialog.Windows.ViewModels
{
    internal class FindWindowViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IValidator<FindWindowViewModel> _validator;

        private readonly IFindDialogSettingsService _findDialogSettingsService;

        public OnFindNextEventHandler OnFindNextEvent;

        public FindWindowViewModel(IValidator<FindWindowViewModel> validator, IFindDialogSettingsService findDialogSettingsService)
        {
            _validator = validator;
            _findDialogSettingsService = findDialogSettingsService;

            RefreshInputFieldsFromCache();
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this);

        private ICommand _findNextCommand;
        public ICommand FindNextCommand => _findNextCommand ??= new FindNextCommand(this, _validator, _findDialogSettingsService);


        private string _findWhat;
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

        private void RefreshInputFieldsFromCache()
        {
            FindWhat = _findDialogSettingsService.FindWhat;
            IsMatchCase = _findDialogSettingsService.IsMatchCase;
            DirectionType = (DirectionType)_findDialogSettingsService.DirectionType;
        }
    }
}
