﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace MobileWorld.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext
                .ValueProvider
                .GetValue(bindingContext.ModelName);

            if(valueResult != ValueProviderResult.None && !String.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal actualValue = 0;
                bool success=false;

                try
                {
                    string decimalValue = valueResult.FirstValue;
                    decimalValue = decimalValue
                        .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decimalValue = decimalValue
                        .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    actualValue = Convert.ToDecimal(decimalValue, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (success)
                {

                }
            }
            return Task.CompletedTask;
        }
    }
}