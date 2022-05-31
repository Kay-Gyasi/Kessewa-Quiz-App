using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.Enums;
using Kessewa.Quiz.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kessewa.Quiz.Persistence.Configurations
{
    public class StudentConfiguration : DatabaseConfigurationBase<Students>
    {
        public override void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Level).IsRequired();
            builder.Property(x => x.Level).HasConversion(new EnumToStringConverter<LevelType>());


            //builder.HasData(
            //    Students.Create(1, 1)
            //        .AtLevel(LevelType.Third)
            //        .SetId(1));
            base.Configure(builder);
        }
    }
}
