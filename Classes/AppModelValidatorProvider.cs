using CourseManager.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManager.Classes
{
    public class AppModelValidatorProvider : IModelValidatorProvider
    {
        public void CreateValidators(ModelValidatorProviderContext context)
        {
            if (context.Results.Any(v => v.Validator.GetType() == typeof(AppModelValidatorProvider)) == true)
            {
                return;
            }

            if (context.ModelMetadata.ContainerType == typeof(Payment))
            {
                context.Results.Add(new ValidatorItem
                {
                    Validator = new AppModelValidator(),
                    IsReusable = true
                });
            }
        }
    }

    public class AppModelValidator : IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var model = context.Container as Payment;


            if (context.ModelMetadata.ModelType == typeof(DateTime)
                && context.ModelMetadata.Name == nameof(model.PaymentDate))
            {

                if (model.PaymentDate > model.EndSubscription)
                {
                    return new List<ModelValidationResult>
                {
                   new ModelValidationResult("","Start Date should be less than End of subscription date")
                };
                }
            }
            return Enumerable.Empty<ModelValidationResult>();
        }
    }
}
