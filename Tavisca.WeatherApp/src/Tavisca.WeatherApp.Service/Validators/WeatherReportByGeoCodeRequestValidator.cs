using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Models;

namespace Tavisca.WeatherApp.Service.Validators
{
   public class WeatherReportByGeoCodeRequestValidator: AbstractValidator<WeatherReportByCityGeoCodeRequest>
    {
        public WeatherReportByGeoCodeRequestValidator()
        {
            RuleFor(x => x.CityGeoCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("CityGeoCode"))
                .SetValidator(new GeoCodeValidator());
        }
    }
}
