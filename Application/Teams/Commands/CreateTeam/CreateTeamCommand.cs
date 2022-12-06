using Apllication.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Teams.Commands.CreateTeam
{
    public class CreateTeamCommand : IRequest<Team>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}