using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication.Common.Interfaces
{
    public interface IEmployeeContext
    {
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Team> Team { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
