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
    public class TeamConfiguration: IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> modelBuilder)
        {
            modelBuilder
               .HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
                .Property(x => x.Description)
                .HasMaxLength(500); 

            modelBuilder
                .HasMany(x => x.Members)
                .WithOne(x => x.Team);

            modelBuilder
                .HasMany(x => x.Issues)
                .WithOne(x => x.Team);
        }
    }
}
