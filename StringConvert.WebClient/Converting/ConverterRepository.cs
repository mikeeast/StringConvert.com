using System;
using System.Collections.Generic;
using System.Linq;

namespace StringConvert.WebClient.Converting
{
    public class ConverterRepository : IConverterRepository
    {
        readonly IEnumerable<IConvertStrings> stringConverters;

        public ConverterRepository(IEnumerable<IConvertStrings> stringConverters)
        {
            this.stringConverters = stringConverters;
        }

        public IEnumerable<IConvertStrings> GetAll()
        {
            return stringConverters;
        }

        public IConvertStrings Get(string converterName)
        {
            return stringConverters.Single(c => c.Name.Equals(converterName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}