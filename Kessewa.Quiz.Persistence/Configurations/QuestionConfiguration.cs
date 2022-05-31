using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.ValueObjects;
using Kessewa.Quiz.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kessewa.Quiz.Persistence.Configurations
{
    public class QuestionConfiguration : DatabaseConfigurationBase<Questions>
    {
        public override void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.Property(x => x.QuizId).IsRequired();
            builder.Property(x => x.MarksAllocated).IsRequired();
            builder.OwnsOne(x => x.Question, x =>
            {
                x.Property(x => x.QuestionText).IsRequired();
                x.Property(x => x.Answer).IsRequired();
            });
            builder.OwnsMany(x => x.Options, x =>
            {
                x.Property(x => x.Text).IsRequired();
                x.Property(x => x.IsCorrectt).IsRequired();
            });
            base.Configure(builder);
        }
    }
}
