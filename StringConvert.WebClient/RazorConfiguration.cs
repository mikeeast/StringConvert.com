using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace StringConvert.WebClient
{
    public class RazorConfiguration : IRazorConfiguration
    {
        public bool AutoIncludeModelNamespace
        {
            get
            {
                return false;
            }
        }

        public IEnumerable<string> GetAssemblyNames()
        {
            return new string[] { };
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            return new string[] { };
        }
    }
}