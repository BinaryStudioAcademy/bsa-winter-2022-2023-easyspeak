using EasySpeak.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.DAL.Context
{
    public class EasySpeakCoreContext : DbContext
    {
        public DbSet<Sample> Samples => Set<Sample>();

        public EasySpeakCoreContext(DbContextOptions<EasySpeakCoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            modelBuilder.Seed();
        }
    }
}
