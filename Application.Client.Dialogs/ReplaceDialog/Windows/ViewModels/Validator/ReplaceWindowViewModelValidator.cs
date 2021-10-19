using FluentValidation;

namespace Application.Client.Dialogs.ReplaceDialog.Windows.ViewModels.Validator
{
    internal class ReplaceWindowViewModelValidator : AbstractValidator<ReplaceWindowViewModel>
    {
        public ReplaceWindowViewModelValidator()
        {
            RuleFor(model => model.FindWhat)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("This field is required!")
                .NotEmpty()
                .WithMessage("This field is required!");
        }
    }
}
