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
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder
               .HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.OwnsOne(x => x.Post,
                p => {
                    p.Property(x => x.PostName).HasColumnName("PostName");
                    p.Property(x => x.PostName).HasMaxLength(50);
                    p.Property(x => x.PostName).IsRequired();

                    p.Property(x => x.Entry).HasColumnName("EntryDate");
                    p.Property(x => x.Entry).IsRequired();
                });


            modelBuilder
                .HasOne(x => x.Team)
                .WithMany(x => x.Members);
        }
    }
}
