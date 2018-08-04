using Microsoft.EntityFrameworkCore;
using CashmoreApp.Models;

namespace CashmoreApp.Data
{
    public class CashmoreAppContext : DbContext
    {
        public CashmoreAppContext(DbContextOptions<CashmoreAppContext> options)
        : base(options)
        {

        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Signatures> Signatures { get; set; }
        public DbSet<EntityToContract> EntityContracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=App.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Entity>().ToTable("Entity");
            modelBuilder.Entity<EntityToContract>().ToTable("EntityToContract");
            modelBuilder.Entity<Signatures>().ToTable("Signatures");
            modelBuilder.Entity<User>().ToTable("User");
            
            // Mapping One to Many Relationship of User to Entity            
            // Also sets the relationship to required, meaning it must be there
            // This in turn sets the delete behavior to Cascade, meaning that if an Entity is deleted all subsequent Users are deleted as well
            modelBuilder.Entity<Entity>()
                .HasMany(e => e.EntityUsers)
                .WithOne(u => u.UserEntity);

            modelBuilder.Entity<Contract>()
                .HasMany(c => c.ContractSignatures)
                .WithOne(s => s.BaseContract);

            // Configure EntityToContract Many to Many Relationship
            modelBuilder.Entity<EntityToContract>()
                .HasKey( etc => new { etc.EntityID, etc.ContractID });

            modelBuilder.Entity<EntityToContract>()
                .HasOne( etc => etc.Contract)
                .WithMany( c => c.ContractEntities)
                .HasForeignKey(etc => etc.ContractID);

            modelBuilder.Entity<EntityToContract>()
                .HasOne( etc => etc.Entity)
                .WithMany( e => e.EntityContracts)
                .HasForeignKey( etc => etc.EntityID);            
        }
    }
}