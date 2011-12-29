using Nancy.Helpers;

namespace StringConvert.WebClient.Converting.Converters
{
    public class HtmlDecoder : IConvertStrings
    {
        public string Name
        {
            get { return "Html Decoder"; }
        }

        public string Convert(string input)
        {
            return HttpUtility.HtmlDecode(input);
        }
    }
}