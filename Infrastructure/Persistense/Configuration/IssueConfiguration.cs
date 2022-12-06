using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistense.Configurations
{
    public class IssueConfiguration:IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> modelBuilder)
        {
            modelBuilder
               .HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder
                .Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder
                .HasOne(x => x.Team)
                .WithMany(x => x.Issues);
        }
    }
}
