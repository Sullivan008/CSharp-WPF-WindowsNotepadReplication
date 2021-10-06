using FluentValidation;

namespace Application.Client.Dialogs.FindDialog.Windows.ViewModels.Validator
{
    internal class FindWindowViewModelValidator : AbstractValidator<FindWindowViewModel>
    {
        public FindWindowViewModelValidator()
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
