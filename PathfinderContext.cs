using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pathfinder.Models;

namespace pathfinder_rough
{
    public partial class PathfinderContext : DbContext
    {
        public PathfinderContext()
        {
        }

        public PathfinderContext(DbContextOptions<PathfinderContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("server=localhost;database=pathfinder");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}


        public DbSet<Character> Characters { get; set; }
    }
}
