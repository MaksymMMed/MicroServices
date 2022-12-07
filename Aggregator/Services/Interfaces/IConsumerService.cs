using Aggregator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Services.Interfaces
{
    public interface IConsumerService
    {
        Task<ConsumerModel> GetConsumerById(string id);
    }
}
