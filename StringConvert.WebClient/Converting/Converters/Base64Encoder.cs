using System.Text;

namespace StringConvert.WebClient.Converting.Converters
{
    public class Base64Encoder : IConvertStrings
    {
        public string Name { get { return "Base64 Encoder"; } }
        public string Convert(string input)
        {
            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(input.ToCharArray()));
        }
    }
}