using Cuzdan.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class PortfoyMap : IEntityTypeConfiguration<Portfoy>
    {
        public void Configure(EntityTypeBuilder<Portfoy> builder)
        {
            builder.ToTable(@"Portfoy", @"dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.KisiId).HasColumnName("KisiId");
            builder.Property(p => p.HisseId).HasColumnName("HisseId");
            builder.Property(p => p.KurumId).HasColumnName("KurumId");
            builder.Property(p => p.Adet).HasColumnName("Adet");
            builder.Property(p => p.Maliyet).HasColumnName("Maliyet");
            builder.Property(p => p.Kar).HasColumnName("Kar");
            builder.Property(p => p.Tutar).HasColumnName("Tutar");
            builder.Property(p => p.Durum).HasColumnName("Durum");
        }
    }
}
