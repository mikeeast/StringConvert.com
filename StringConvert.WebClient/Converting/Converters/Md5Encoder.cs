using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StringConvert.WebClient.Converting.Converters
{
    public class Md5Encoder : IConvertStrings
    {
        public string Name { get { return "MD5 Encoder"; } }
        public string Convert(string input)
        {
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input.ToCharArray()));
            return string.Join(string.Empty, hash.Select(b => b.ToString("x2")));
        }
    }
}