using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace MobileWorld.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {
        private readonly string _dateTimeFormat;
        public DateTimeModelBinder(string dateTimeFormat)
        {
            _dateTimeFormat = dateTimeFormat;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext
                .ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !String.IsNullOrEmpty(valueResult.FirstValue))
            {
                DateTime actualValue = DateTime.MinValue;
                bool success = false;
                string dateValue = valueResult.FirstValue;

                try
                {
                    actualValue = DateTime.ParseExact(dateValue, _dateTimeFormat, CultureInfo.InvariantCulture);
                    success = true;
                }
                catch (FormatException fe)
                {
                    try
                    {
                        actualValue = DateTime.Parse(dateValue, new CultureInfo("bg-bg"));
                    }
                    catch (Exception e)
                    {
                        bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                    }
                }

                if (success)
                {

                }
            }
            return Task.CompletedTask;
        }
    }
}
