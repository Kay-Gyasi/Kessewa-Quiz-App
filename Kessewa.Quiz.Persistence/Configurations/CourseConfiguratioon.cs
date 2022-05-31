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
    public class CourseConfiguratioon : DatabaseConfigurationBase<Courses>
    {
        public override void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LecturerId).IsRequired();
            builder.Property(x => x.CreditHours).HasConversion(new EnumToStringConverter<CreditHours>());
            builder.Property(x => x.Level).HasConversion(new EnumToStringConverter<LevelType>());


            //builder.HasData(
            //    Courses.Create("Data Structures")
            //        .WithLecturerId(1)
            //        .HasCreditHours(CreditHours.Three)
            //        .ForLevel(LevelType.Third)
            //        .SetId(1),
            //    Courses.Create("Operating Systems")
            //        .WithLecturerId(1)
            //        .HasCreditHours(CreditHours.Three)
            //        .ForLevel(LevelType.Third)
            //        .SetId(2));
            base.Configure(builder);
        }
    }
}
