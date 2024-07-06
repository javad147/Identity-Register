﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
    
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(255).IsRequired();
        }
    }
}

