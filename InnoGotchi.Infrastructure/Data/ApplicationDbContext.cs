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
        public DbSet<UserStatistics> UserStatistics { get; set; }
        public DbSet<PetsBody> PetsBodies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(ConfigurePet);
            modelBuilder.Entity<Farm>(ConfigureFarm);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<PetsBody>(ConfigurePetsBody);
            modelBuilder.Entity<UserStatistics>(ConfigureUserStatistics);
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
                .WithOne(u => u.MyOwnFarm)
                .HasForeignKey<User>(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.UserId)
                .HasDefaultValue(0);

        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Pets)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.FarmId)
                .HasDefaultValue(0);


            builder.HasOne(x => x.MyOwnFarm)
                .WithOne(u => u.User)
                .HasForeignKey<Farm>(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigurePetsBody(EntityTypeBuilder<PetsBody> builder)
        {
            builder.HasOne(x => x.Pet)
                .WithOne(u => u.PetsBody)
                .HasForeignKey<Pet>(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

        }

        private void ConfigureUserStatistics(EntityTypeBuilder<UserStatistics> builder)
        {
            builder.HasOne(x => x.User)
                 .WithOne(u => u.Statistics)
                 .HasForeignKey<UserStatistics>(p => p.Id)
                 .OnDelete(DeleteBehavior.NoAction);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }


    }
}
