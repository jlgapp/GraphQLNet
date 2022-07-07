using GraphQLDirector.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDirector.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { }

        public virtual DbSet<Video>? Videos { get; set; }
        public virtual DbSet<Director>? Directores { get; set; }
        public virtual DbSet<Streamer>? Streamers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(n => n.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m=>m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Director>()
                .HasMany(n => n.Videos)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
