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

namespace Apllication.Issues.Commands.CreateIssue
{
    public class CreateIssueHandler:IRequestHandler<CreateIssueCommand,Issue>
    {

        private readonly IEmployeeContext Context;
        private readonly IMessageProducer Producer;

        public CreateIssueHandler(IEmployeeContext _context,IMessageProducer _producer)
        {
            Context = _context;
            Producer = _producer;
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
            var _issue = issueEvent;
            Producer.sendMessage(_issue);
            //        
                        
            await Context.Issue.AddAsync(issue);
            await Context.SaveChangesAsync(cancellationToken);
            return issue;
        }
    }
}
