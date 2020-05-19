using ApartmentsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentsManager.Infra.Contexts
{
    public class ApartmentsManagerContext : DbContext
    {
        public ApartmentsManagerContext(DbContextOptions<ApartmentsManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Resident> Residents { get; set; }
        public DbSet<Condominium> Condominiums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resident>().ToTable("Resident");
            modelBuilder.Entity<Resident>().Property(x => x.Id);
            modelBuilder.Entity<Resident>().Ignore(x => x.Notifications);
            modelBuilder.Entity<Resident>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Resident>().Property(x => x.Name).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<Resident>().Property(x => x.BirthDate);
            modelBuilder.Entity<Resident>().Property(x => x.Phone).HasMaxLength(11).HasColumnType("varchar(11)");
            modelBuilder.Entity<Resident>().Property(x => x.Cpf).HasMaxLength(11).HasColumnType("varchar(11)");
            modelBuilder.Entity<Resident>().Property(x => x.Active);
            modelBuilder.Entity<Resident>().Property(x => x.Created);
            modelBuilder.Entity<Resident>().Property(x => x.Updated);
            modelBuilder.Entity<Resident>().HasIndex(x => x.User);
            // TODO: Criar indexes
            // modelBuilder.Entity<Resident>().HasIndex(x => x.Cpf);
            // modelBuilder.Entity<Resident>().HasIndex(x => x.Email);

            modelBuilder.Entity<Condominium>().ToTable("Condominium");
            modelBuilder.Entity<Condominium>().Property(x => x.Id);
            modelBuilder.Entity<Condominium>().Ignore(x => x.Notifications);
            modelBuilder.Entity<Condominium>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Condominium>().Property(x => x.Name).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<Condominium>().Property(x => x.Street).HasMaxLength(500).HasColumnType("varchar(500)");
            modelBuilder.Entity<Condominium>().Property(x => x.Neighborhood).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<Condominium>().Property(x => x.City).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<Condominium>().Property(x => x.State).HasMaxLength(2).HasColumnType("varchar(2)");
            modelBuilder.Entity<Condominium>().Property(x => x.Country).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<Condominium>().Property(x => x.ZipCode).HasMaxLength(8).HasColumnType("varchar(8)");
            modelBuilder.Entity<Condominium>().Property(x => x.Active);
            modelBuilder.Entity<Condominium>().Property(x => x.Created);
            modelBuilder.Entity<Condominium>().Property(x => x.Updated);
            modelBuilder.Entity<Condominium>().HasIndex(x => x.User);

        }
    }
}