using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Domain.Enums;
using Kessewa.Quiz.Domain.ValueObjects;
using Kessewa.Quiz.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kessewa.Quiz.Persistence.Configurations
{
    public class UserConfiguration : DatabaseConfigurationBase<Users>
    {
        public override void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired();
            builder.Property(u => u.LastName)
                .IsRequired();
            builder.Property(u => u.Type)
                .IsRequired();
            builder.Property(x => x.Type).HasConversion(new EnumToStringConverter<UserType>());
            builder.OwnsOne(x => x.Email, sb =>
            {
                sb.Property(x => x.EmailAddress).IsRequired();
            });
            builder.OwnsOne(x => x.Phone, sb =>
            {
                sb.Property(x => x.PhoneNumber).IsRequired();
            });
            builder.OwnsOne(x => x.Address, sb =>
            {
                sb.Property(x => x.City).IsRequired();
                sb.Property(x => x.Street).IsRequired();
            });

            //builder.HasData(
            //        Users.Create("Kofi", "Gyasi")
            //            .OfType(UserType.Student)
            //            .WithPhone(Phone.Create("0781234567"))
            //            .WithEmail(Email.Create("kaygyasi715@gmail.com"))
            //            .WithDisplayName("Kay Gyasi")
            //            .SetId(1),
            //        Users.Create("Nana", "Asomdwee")
            //            .OfType(UserType.Lecturer)
            //            .WithPhone(Phone.Create("0557833216"))
            //            .WithEmail(Email.Create("nanaasomdwee@gmail.com"))
            //            .WithDisplayName("Nana Ama")
            //            .SetId(2)
            //    );
            base.Configure(builder);
        }

        //public static void UserConfig(this ModelBuilder builder)
        //{
            
        //}
    }
}
