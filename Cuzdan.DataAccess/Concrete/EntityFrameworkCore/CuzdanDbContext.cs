using Cuzdan.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using Cuzdan.Entity.ComplexTypes;
using Cuzdan.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore
{
    public class CuzdanDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=Borsa;Trusted_Connection=Yes;Connection Timeout=1800;MultipleActiveResultSets=True");
        }

        public DbSet<Kurum> Kurum { get; set; }
        public DbSet<Hisse> Hisse { get; set; }
        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Islem> Islem { get; set; }
        public DbSet<Portfoy> Portfoy { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Kurum>(new KurumMap());
            /*modelBuilder.Entity<Kurum>()
                        .Property(f => f.AddedDate)
                        .HasColumnType("datetime2");*/
            modelBuilder.ApplyConfiguration<Hisse>(new HisseMap());
            modelBuilder.ApplyConfiguration<Kisi>(new KisiMap());
            modelBuilder.ApplyConfiguration<Islem>(new IslemMap());
            modelBuilder.Entity<Islem>().Property(f => f.Maliyet).HasColumnType("float");
            modelBuilder.Entity<Islem>().Property(f => f.Alis).HasColumnType("float");
            modelBuilder.Entity<Islem>().Property(f => f.Satis).HasColumnType("float");
            modelBuilder.Entity<Islem>().Property(f => f.Hedef).HasColumnType("float");
            modelBuilder.Entity<Islem>().Property(f => f.Kar).HasColumnType("float");
            modelBuilder.Entity<Islem>().Property(f => f.AnlikDeger).HasColumnType("float");
            modelBuilder.Entity<Portfoy>().Property(f => f.Maliyet).HasColumnType("float");
            modelBuilder.Entity<Portfoy>().Property(f => f.Kar).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<IslemComplexData>().HasNoKey();
            modelBuilder.Entity<IslemComplexData>().Property(f => f.Alis).HasColumnType("float");
            modelBuilder.Entity<IslemComplexData>().Property(f => f.Satis).HasColumnType("float");
            modelBuilder.Entity<IslemComplexData>().Property(f => f.KarZarar).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<IslemComplexData>().Property(f => f.Maliyet).HasColumnType("float");
            modelBuilder.Entity<IslemComplexData>().Property(f => f.Hedef).HasColumnType("float");
            modelBuilder.Entity<IslemComplexData>().Property(f => f.AnlikDeger).HasColumnType("float");
        }
    }
}
