using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kessewa.Quiz.Persistence.Configurations
{
    public class QuizConfiguration : DatabaseConfigurationBase<Quizzes>
    {
        public override void Configure(EntityTypeBuilder<Quizzes> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CourseId).IsRequired();
            builder.Property(x => x.DateToBeTaken).IsRequired();
            builder.Property(x => x.TimeToBeTaken).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            base.Configure(builder);
        }
    }
}
