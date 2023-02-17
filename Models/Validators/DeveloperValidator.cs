namespace Models.Validators
{
    using FluentValidation;
    using global::Models.Models;

    public class DeveloperValidator : AbstractValidator<Developer>
    {
        public DeveloperValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .Length(0, 255);
            RuleFor(x => x.LastName).NotEmpty()
                .Length(0, 255);
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Please specify a phone number.");
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(0, 255)
                .EmailAddress();
            RuleFor(x => x.DateOfBirth).InclusiveBetween(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(-18)).WithMessage("Please enter a valid Date of Birth.");

            // Complex Properties
            RuleFor(x => x.Address).SetValidator(new AddressValidator());

            // Collections of Complex Types
            ////RuleForEach(x => x.Address).SetValidator(new AddressValidator());
        }
    }
}