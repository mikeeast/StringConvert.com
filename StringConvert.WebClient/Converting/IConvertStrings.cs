namespace StringConvert.WebClient.Converting
{
    public interface IConvertStrings
    {
        string Name { get; }
        string Convert(string input);
    }
}