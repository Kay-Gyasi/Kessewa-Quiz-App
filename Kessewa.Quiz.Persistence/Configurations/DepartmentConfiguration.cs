using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;
using Kessewa.Quiz.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kessewa.Quiz.Persistence.Configurations
{
    public class DepartmentConfiguration : DatabaseConfigurationBase<Departments>
    {
        public override void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.Property(x => x.FacultyId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.OwnsOne(x => x.Email, sb =>
            {
                sb.Property(x => x.EmailAddress).IsRequired();
            });
            builder.OwnsOne(x => x.Phone, sb =>
            {
                sb.Property(x => x.PhoneNumber).IsRequired();
            });


            builder.HasData(
                Departments.Create("Computer Science and Engineering", 1)
                    .SetId(1)
                    .WithDescription(null),
            Departments.Create("Mineral Resources", 2)
                    .SetId(2)
                    .WithDescription(null));
            base.Configure(builder);
        }
    }
}
