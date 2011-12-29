using Nancy.Helpers;

namespace StringConvert.WebClient.Converting.Converters
{
    public class UrlDecoder : IConvertStrings
    {
        public string Name
        {
            get { return "Url Decoder"; }
        }

        public string Convert(string input)
        {
            return HttpUtility.UrlDecode(input);
        }
    }
}