using Cuzdan.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class IslemMap : IEntityTypeConfiguration<Islem>
    {
        public void Configure(EntityTypeBuilder<Islem> builder)
        {
            builder.ToTable(@"Islem", @"dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.HisseId).HasColumnName("HisseId");
            builder.Property(p => p.AddedBy).HasColumnName("AddedBy");
            builder.Property(p => p.IslemAdet).HasColumnName("IslemAdet");
            builder.Property(p => p.IslemDate).HasColumnName("IslemDate");
            builder.Property(p => p.IslemKodu).HasColumnName("IslemKodu");
            builder.Property(p => p.KurumId).HasColumnName("KurumId");
            builder.Property(p => p.Maliyet).HasColumnName("Maliyet");
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.Alis).HasColumnName("Alis");
            builder.Property(p => p.Satis).HasColumnName("Satis");
            builder.Property(p => p.Kar).HasColumnName("Kar");
            builder.Property(p => p.Hedef).HasColumnName("Hedef");
            builder.Property(p => p.AnlikDeger).HasColumnName("AnlikDeger");
        }
    }
}
