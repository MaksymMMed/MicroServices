﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Teams.Queries.GetAllTeams
{
    public class GetAllTeamsQuery:IRequest<List<Team>>
    {

    }
}
