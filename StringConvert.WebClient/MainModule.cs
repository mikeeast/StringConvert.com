using Nancy;
using StringConvert.WebClient.Common;
using StringConvert.WebClient.Converting;

namespace StringConvert.WebClient
{
    public class MainModule : NancyModule
    {
        public MainModule(IConverterRepository converterRepository)
        {
            Get["/"] = x => {
                var viewModel = new
                {
                    converters = converterRepository.GetAll()
                };
                return View["index.cshtml", viewModel.AsJson()];
            };
        }
    }
}