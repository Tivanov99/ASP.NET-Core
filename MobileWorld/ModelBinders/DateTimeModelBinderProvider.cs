using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MobileWorld.ModelBinders
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string _dateTimeFormat;
        public DateTimeModelBinderProvider(string dateTimeFormat)
        {
            _dateTimeFormat = dateTimeFormat;
        }

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(_dateTimeFormat);
            }
            return null;
        }
    }
}
