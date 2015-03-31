namespace DcComics
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dcContext : DbContext
    {
        public dcContext()
            : base("name=dcContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Comics> Comics { get; set; }
        public virtual DbSet<Superheroes> Superheroes { get; set; }
        public virtual DbSet<Villains> Villains { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Superheroes>()
                .HasMany(e => e.Comics)
                .WithOptional(e => e.Superheroes)
                .HasForeignKey(e => e.Superheroes_ID);

            modelBuilder.Entity<Superheroes>()
                .HasMany(e => e.Villains)
                .WithOptional(e => e.Superheroes)
                .HasForeignKey(e => e.Nemesis_ID);

            modelBuilder.Entity<Villains>()
                .HasMany(e => e.Comics)
                .WithOptional(e => e.Villains)
                .HasForeignKey(e => e.Villains_ID);
        }
    }
}
