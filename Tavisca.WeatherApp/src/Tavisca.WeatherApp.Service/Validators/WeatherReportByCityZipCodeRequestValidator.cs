using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.Platform.Common.Models;

namespace Tavisca.WeatherApp.Service.Validators
{
   
    public class WeatherReportByCityZipCodeRequestValidator : AbstractValidator<WeatherReportByCityZipCodeRequest>
    {
        public WeatherReportByCityZipCodeRequestValidator()
        {
            RuleFor(x => x.CityZipCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MandatoryFieldMissing)
                .WithMessage(ErrorMessages.MandatoryFieldMissing("CityZipCode"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidValueForInputType)
                .WithMessage(ErrorMessages.InvalidValueForInputType("CityZipCode", "cityzipcode", "int"));
        }
    }
}
