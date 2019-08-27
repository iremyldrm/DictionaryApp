using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DictionaryApp.Models
{
    public partial class stkContext : DbContext
    {
        public stkContext()
        {
        }

        public stkContext(DbContextOptions<stkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Keywords> Keywords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = dictionaryapp1.database.windows.net; Initial Catalog = DictionaryAppDatabase; User ID = Iremyldrm; Password = Melekirem1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Keywords>(entity =>
            {
                entity.Property(e => e.WordEn)
                    .IsRequired()
                    .HasColumnName("Word_En")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WordTr)
                    .IsRequired()
                    .HasColumnName("Word_Tr")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
