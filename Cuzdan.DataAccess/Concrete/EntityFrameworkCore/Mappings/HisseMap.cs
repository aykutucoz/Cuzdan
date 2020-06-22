using Cuzdan.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class HisseMap : IEntityTypeConfiguration<Hisse>
    {
        public void Configure(EntityTypeBuilder<Hisse> builder)
        {
            builder.ToTable(@"Hisse", @"dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.AddedBy).HasColumnName("AddedBy");
            builder.Property(p => p.AddedDate).HasColumnName("AddedDate");
            builder.Property(p => p.Hisse_Adi).HasColumnName("Hisse_Adi");
            builder.Property(p => p.Hisse_Kodu).HasColumnName("Hisse_Kodu");
        }
    }
}
