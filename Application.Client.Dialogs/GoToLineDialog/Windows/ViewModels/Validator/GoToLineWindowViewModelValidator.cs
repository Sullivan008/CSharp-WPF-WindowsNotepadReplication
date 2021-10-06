using FluentValidation;

namespace Application.Client.Dialogs.GoToLineDialog.Windows.ViewModels.Validator
{
    internal class GoToLineWindowViewModelValidator : AbstractValidator<GoToLineWindowViewModel>
    {
        public GoToLineWindowViewModelValidator()
        {
            RuleFor(model => model.LineNumber)
                .NotNull()
                .WithMessage("This field is required!")
                .GreaterThan(0)
                .WithMessage("The value must be greater than 0");
        }
    }
}
