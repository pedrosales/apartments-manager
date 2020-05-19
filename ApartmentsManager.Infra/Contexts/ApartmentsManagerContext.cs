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
            modelBuilder.Entity<Resident>().HasIndex(x => x.User);
            // TODO: Criar indexes
            // modelBuilder.Entity<Resident>().HasIndex(x => x.Cpf);
            // modelBuilder.Entity<Resident>().HasIndex(x => x.Email);
        }
    }
}