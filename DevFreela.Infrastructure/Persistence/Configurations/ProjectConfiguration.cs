﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
              .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelancerProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(p => p.Client)
              .WithMany(f => f.OwnerProjects)
              .HasForeignKey(p => p.IdClient)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}