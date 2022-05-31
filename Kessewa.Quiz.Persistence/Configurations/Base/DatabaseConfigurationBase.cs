using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kessewa.Quiz.Persistence.Configurations.Base
{
    public abstract class DatabaseConfigurationBase<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name);
            builder.Property("DateCreated").HasDefaultValueSql("GETDATE()");
            builder.Property("DateModified").HasDefaultValueSql("GETDATE()");

            //builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            //builder.Property(x => x.UpdatedAt).HasDefaultValueSql("GETDATE()");

            //builder.HasQueryFilter(a => a.Audit.EntityStatus == EntityStatus.Normal);
            //builder.Property(a => a.RowVersion).IsRowVersion();

        }
    }
}
