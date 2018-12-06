using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Models;

namespace Tavisca.WeatherApp.Service.Validators
{
   
    public class WeatherReportByCityIdRequestValidator : AbstractValidator<WeatherReportByCityIdRequest>
    {
        public WeatherReportByCityIdRequestValidator()
        {
            RuleFor(x => x.CityId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("CityId"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("CityId", "cityId", "int"));
        }
    }
}
