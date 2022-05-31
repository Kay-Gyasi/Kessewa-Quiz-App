using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kessewa.Quiz.Persistence.Configurations
{
    public class FacultyConfiguration : DatabaseConfigurationBase<Faculties>
    {
        public override void Configure(EntityTypeBuilder<Faculties> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(
                Faculties.Create("Faculty of Engineering").SetId(1),
                Faculties.Create("Faculty of Mineralogy").SetId(2));
            base.Configure(builder);
        }
    }
}
