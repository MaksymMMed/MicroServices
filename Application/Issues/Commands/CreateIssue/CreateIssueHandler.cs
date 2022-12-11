using Apllication.Common.Interfaces;
using Apllication.Teams.Commands.CreateTeam;
using Domain.Entities;
using MediatR;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EventBus.Events;
using Rabbit.Producer;
using MassTransit;

namespace Apllication.Issues.Commands.CreateIssue
{
    public class CreateIssueHandler:IRequestHandler<CreateIssueCommand,Issue>
    {

        private readonly IEmployeeContext Context;
        //private readonly IMessageProducer Producer;
        private readonly IPublishEndpoint Endpoint;

        public CreateIssueHandler(IEmployeeContext context, IPublishEndpoint endpoint)
        {
            Context = context;
            Endpoint = endpoint;
        }

        public async Task<Issue> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {

            Issue issue = new()
            {
                Title = request.Title.Trim(),
                Description = request.Description.Trim(),
                CreatiоnDate = DateTime.Now,
                Deadline = request.Deadline,
                TeamId = request.TeamId,
                Status = false
            };

            //RabbitMQ
            IssueEvent issueEvent = new()
            {
                Title = request.Title.Trim(),
                Status = false,
                UnitId = request.TeamId
            };
            //Producer.sendMessage(_issue);
            //
            
            await Endpoint.Publish(issueEvent);
                        
            await Context.Issue.AddAsync(issue);
            await Context.SaveChangesAsync(cancellationToken);
            return issue;
        }
    }
}
