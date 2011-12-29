using Nancy.Helpers;

namespace StringConvert.WebClient.Converting.Converters
{
    public class HtmlEncoder : IConvertStrings
    {
        public string Name
        {
            get { return "Html Encoder"; }
        }

        public string Convert(string input)
        {
            return HttpUtility.HtmlEncode(input);
        }
    }
}