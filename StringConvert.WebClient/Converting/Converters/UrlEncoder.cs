using Nancy.Helpers;

namespace StringConvert.WebClient.Converting.Converters
{
    public class UrlEncoder : IConvertStrings
    {
        public string Name
        {
            get { return "Url Encoder"; }
        }

        public string Convert(string input)
        {
            return HttpUtility.UrlEncode(input);
        }
    }
}