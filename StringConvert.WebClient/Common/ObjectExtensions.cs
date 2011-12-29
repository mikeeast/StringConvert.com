using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StringConvert.WebClient.Common
{
    public static class ObjectExtensions
    {
        public static string AsJson(this object o)
        {
            var dateConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd"
            };
            return JsonConvert.SerializeObject(o, dateConverter);
        }
    }
}