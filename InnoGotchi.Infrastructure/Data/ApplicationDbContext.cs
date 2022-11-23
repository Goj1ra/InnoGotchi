using InnoGotchi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoGotchi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(ConfigurePet);
            modelBuilder.Entity<Farm>(ConfigureFarm);
            modelBuilder.Entity<User>(ConfigureUser);
        }

        private void ConfigurePet(EntityTypeBuilder<Pet> builder)
        {
            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(u => u.Pets)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Farm)
                .WithMany(u => u.Pets)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigureFarm(EntityTypeBuilder<Farm> builder)
        {
            builder.HasMany(x => x.Pets)
                .WithOne(u => u.Farm)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User)
                .WithOne(x => x.MyOwnFarm)
                .HasForeignKey<User>(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Pets)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.MyOwnFarm)
                .WithOne(x => x.User)
                .HasForeignKey<Farm>(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }


    }
}
