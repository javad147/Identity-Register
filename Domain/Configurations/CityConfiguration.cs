using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        void IEntityTypeConfiguration<City>.Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(t => t.Name).IsRequired().HasMaxLength(200);
        }
    }
}
