using Aggregator.Extensions;
using Aggregator.Models;
using Aggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Services.Realizations
{
    public class ConsumerService:IConsumerService
    {
        public HttpClient client;

        public ConsumerService(HttpClient httpClient)
        {
            this.client = httpClient;
        }

        public async Task<ConsumerModel> GetConsumerById(string id)
        {
            var response = await client.GetAsync("/apiconsumer/Consumer/{"+id+"}");
            return await response.ReadContentAs<ConsumerModel>();
    
        }

    }
}
