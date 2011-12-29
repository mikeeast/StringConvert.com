using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using SignalR.Hubs;
using StringConvert.WebClient.Common;
using StringConvert.WebClient.Converting;

namespace StringConvert.WebClient.Hubs
{
    [HubName("converterHub")]
    public class ConverterHub : Hub
    {
        readonly IConverterRepository converterRepository;
        static readonly IList<string> latestConversions = new List<string>();

        public ConverterHub()
        {
            this.converterRepository = ServiceLocator.Current.GetInstance<IConverterRepository>();
        }

        public string Execute(string converterName, string input)
        {
            var converter = converterRepository.Get(converterName);
            return converter.Convert(input);
        }

        public Task<string> ExecuteAsync(string converterName, string input)
        {
            return Task.Factory.StartNew(() => {
                var converter = converterRepository.Get(converterName);

                try
                {
                    return converter.Convert(input);
                }
                catch (System.Exception ex)
                {
                    return ex.Message;
                }

            });
        }

        public string GetPreviousConversions()
        {
            return latestConversions.ToArray().AsJson();
        }

        public void ReportConversion(string input)
        {
            Task.Factory.StartNew(() =>
            {
                latestConversions.Add(input);
                Clients.addLatestConversion(input);
                while (latestConversions.Count > 30)
                {
                    latestConversions.RemoveAt(0);
                }

            });
        }
    }
}