using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace oFurnu.Models
{
    public partial class Pizzeria : DbContext
    {
        public Pizzeria()
            : base("name=Pizzeria")
        {
        }

        public virtual DbSet<Amministrazione> Amministrazione { get; set; }
        public virtual DbSet<Bibite> Bibite { get; set; }
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Pizze> Pizze { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bibite>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Bibite>()
                .Property(e => e.Prezzo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bibite>()
                .HasMany(e => e.Ordini)
                .WithOptional(e => e.Bibite)
                .HasForeignKey(e => e.FK_ID_Bibita);

            modelBuilder.Entity<Clienti>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Clienti>()
                .Property(e => e.Indirizzo)
                .IsUnicode(false);

            modelBuilder.Entity<Clienti>()
                .Property(e => e.Cognome)
                .IsFixedLength();

            modelBuilder.Entity<Clienti>()
                .Property(e => e.Ruolo)
                .IsFixedLength();

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Clienti)
                .HasForeignKey(e => e.FK_ID_Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordini>()
                .Property(e => e.Totale)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Pizze>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pizze>()
                .Property(e => e.Prezzo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Pizze>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Pizze)
                .HasForeignKey(e => e.FK_ID_Pizza)
                .WillCascadeOnDelete(false);
        }
    }
}
