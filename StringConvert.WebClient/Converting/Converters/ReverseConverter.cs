using System.Linq;

namespace StringConvert.WebClient.Converting.Converters
{
    public class ReverseConverter : IConvertStrings
    {
        public string Name { get { return "Reverse"; } }
        public string Convert(string input)
        {
            return string.Join(string.Empty, input.Reverse());
        }
    }
}