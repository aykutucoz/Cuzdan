using Cuzdan.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class KisiMap : IEntityTypeConfiguration<Kisi>
    {
        public void Configure(EntityTypeBuilder<Kisi> builder)
        {
            builder.ToTable(@"Kisi", @"dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.AddedBy).HasColumnName("AddedBy");
            builder.Property(p => p.AddedDate).HasColumnName("AddedDate");
            builder.Property(p => p.User_Code).HasColumnName("User_Code");
            builder.Property(p => p.User_Name).HasColumnName("User_Name");
            builder.Property(p => p.Email).HasColumnName("Email");
        }
    }
}
