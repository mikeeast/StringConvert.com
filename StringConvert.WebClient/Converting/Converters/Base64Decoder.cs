using System.Text;

namespace StringConvert.WebClient.Converting.Converters
{
    public class Base64Decoder : IConvertStrings
    {
        public string Name { get { return "Base64 Decoder"; } }
        public string Convert(string input)
        {
            return Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
        }
    }
}