using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kessewa.Quiz.Persistence.Configurations
{
    public class SubmissionConfiguration : DatabaseConfigurationBase<Submissions>
    {
        public override void Configure(EntityTypeBuilder<Submissions> builder)
        {
            builder.Property(x => x.QuizId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
            builder.OwnsMany(x => x.Choices, sb =>
            {
                sb.Property(x => x.QuestionId).IsRequired();
                sb.Property(x => x.Answer).IsRequired();
            });
            base.Configure(builder);
        }
    }
}
