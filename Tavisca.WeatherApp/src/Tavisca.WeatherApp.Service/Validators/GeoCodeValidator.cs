using FluentValidation;
using FluentValidation.Validators;
using Tavisca.Platform.Common.Models;


namespace Tavisca.WeatherApp.Service.Validators
{
    internal class GeoCodeValidator : AbstractValidator<CityGeoCode>
    {
        public GeoCodeValidator()
        {
            RuleFor(x => x.Latitude)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("Latitude"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("CityGeoCode", "latitude", "int"));
            ;

            RuleFor(x => x.Longitude)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.MandatoryFieldMissing)
               .WithMessage(ErrorMessages.MandatoryFieldMissing("Longitude"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("CityGeoCode", "longitude", "int")); ;
        }
    }
}