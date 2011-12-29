using System.Collections.Generic;

namespace StringConvert.WebClient.Converting
{
    public interface IConverterRepository
    {
        IEnumerable<IConvertStrings> GetAll();
        IConvertStrings Get(string converterName);
    }
}