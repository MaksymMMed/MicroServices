using Apllication.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistense.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistense
{
    public class EmployeeContext : DbContext,IEmployeeContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Team> Team { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new IssueConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
