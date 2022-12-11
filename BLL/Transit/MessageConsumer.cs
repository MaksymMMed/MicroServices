using Application.EventBus.Events;
using MassTransit;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Rabbit;
using DAL.Entities;
using DAL.Repositories.UnitOfWork;
using MassTransit.Mediator;
using AutoMapper;

namespace BLL.Transit
{
    public class MessageConsumer : IConsumer<IssueEvent>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MessageConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IssueEvent> context)
        {
            var issue = mapper.Map<Issue>(context.Message);
            await unitOfWork.issueRepository.InsertAsync(issue);
        }
    }
}
