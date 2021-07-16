using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Application.Client.Infrastructure.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Client.Dialogs.FindDialog.Windows.ViewModels
{
    public class FindWindowViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IValidator<FindWindowViewModel> _validator;

        public FindWindowViewModel(IValidator<FindWindowViewModel> validator)
        {
            _validator = validator;
        }

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
