using EasySpeak.Core.DAL.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FriendConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            Seeder.Seed(modelBuilder);
        }
    }
}