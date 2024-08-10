using AutoMapper;
using Newtonsoft.Json.Converters;
using System;

namespace OpenMusic.API.Helpers
{
    public class DateOnlyToStringConverter : ITypeConverter<string, DateOnly>
    {

        public DateOnly Convert(string source, DateOnly destination, ResolutionContext context)
        {
            if (source == null)
            {
                return default(DateOnly);
            }

            if (DateOnly.TryParse(source.ToString(), out destination))
            {
                return destination;
            }

            return default(DateOnly);
        }
    }
}
