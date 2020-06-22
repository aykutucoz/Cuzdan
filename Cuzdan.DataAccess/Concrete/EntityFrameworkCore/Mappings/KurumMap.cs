using Cuzdan.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class KurumMap : IEntityTypeConfiguration<Kurum>
    {
        public void Configure(EntityTypeBuilder<Kurum> builder)
        {
            builder.ToTable(@"Kurum",@"dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.AddedBy).HasColumnName("AddedBy");
            builder.Property(p => p.AddedDate).HasColumnName("AddedDate");
            builder.Property(p => p.Kurum_Adi).HasColumnName("Kurum_Adi");
            builder.Property(p => p.Kurum_Kodu).HasColumnName("Kurum_Kodu");
        }
    }

}
