using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VCardMVC.Models
{
    public partial class vcardContext : DbContext
    {
        public vcardContext()
        {
        }

        public vcardContext(DbContextOptions<vcardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VCard> VCards { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("server=localhost,1433;database=vcard;uid=sa;pwd=your_password123;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VCard>(entity =>
            {
                entity.ToTable("vCards");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
