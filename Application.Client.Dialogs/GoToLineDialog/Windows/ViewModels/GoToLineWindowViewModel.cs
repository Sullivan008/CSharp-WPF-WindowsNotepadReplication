using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Application.Client.Dialogs.GoToLineDialog.Windows.Commands;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Infrastructure.ViewModels;
using Application.Client.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels
{
    public class GoToLineWindowViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IMessageDialog _messageDialog;

        private readonly IDocInfoService _docInfoService;

        private readonly IValidator<GoToLineWindowViewModel> _validator;

        public GoToLineWindowViewModel(IValidator<GoToLineWindowViewModel> validator, IMessageDialog messageDialog, IDocInfoService docInfoService)
        {
            _validator = validator;
            _messageDialog = messageDialog;
            _docInfoService = docInfoService;
        }

        private ICommand _goToCommand;
        public ICommand GoToCommand => _goToCommand ??= new GoToCommand(this, _validator, _messageDialog, _docInfoService);

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this);

        private int? _lineNumber = default(int) + 1;
        public int? LineNumber
        {
            get => _lineNumber;
            set
            {
                _lineNumber = value;
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
