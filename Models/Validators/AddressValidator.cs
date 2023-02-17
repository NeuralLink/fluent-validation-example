namespace Models.Validators
{
    using FluentValidation;
    using global::Models.Models;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class AddressValidator : AbstractValidator<Address>
    {
        private const string CaZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";
        private const string UsZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

        public AddressValidator()
        {
            RuleFor(x => x.Line1).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.Country).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(3)
                .Must(IsCountryCodeValid).WithMessage("Please specify a valid {PropertyName}");
            RuleFor(x => x.PostalCode).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(IsPostalCodeValid).WithMessage("Please specify a valid {PropertyName}");
        }

        private bool IsCountryCodeValid(string countryCode)
        {
            var validCountryCodes = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID)).Select(x => x.ThreeLetterISORegionName);
            return validCountryCodes.Contains(countryCode);
        }

        private bool IsPostalCodeValid(string postalCode)
        {
            return Regex.Match(postalCode, UsZipRegEx).Success || Regex.Match(postalCode, CaZipRegEx).Success;
        }
    }
}