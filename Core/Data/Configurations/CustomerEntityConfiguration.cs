using System;
using ITS_Technical_Test.Core.Data.Entity.Implementations;
using ITS_Technical_Test.Core.Misc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITS_Technical_Test.Core.Data.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);




            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(t => t.Email)
                .IsRequired()
                .HasColumnType("nvarchar(320)");

            builder.Property(t => t.Comment)
                 .HasColumnType("nvarchar(250)");


            builder.Property(e => e.Class)
                .HasColumnType("nvarchar(50)")
                .HasConversion(v => v.ToString(),
                    v => (CustomerClass)Enum.Parse(typeof(CustomerClass), v));


        }
    }
}
