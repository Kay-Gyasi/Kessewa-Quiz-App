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
    public class LecturerConfiguration : DatabaseConfigurationBase<Lecturers>
    {
        public override void Configure(EntityTypeBuilder<Lecturers> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Type).HasConversion(new EnumToStringConverter<LecturerType>());


            builder.HasData(
                Lecturers.Create(2, LecturerType.SeniorLecturer)
                    .SetId(1));
            base.Configure(builder);
        }
    }
}
