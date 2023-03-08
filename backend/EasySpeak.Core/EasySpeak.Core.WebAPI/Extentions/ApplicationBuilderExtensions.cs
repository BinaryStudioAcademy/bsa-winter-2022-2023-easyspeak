using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.WebAPI.Extentions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCodiCoreContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            using var context = scope?.ServiceProvider.GetRequiredService<EasySpeakCoreContext>();
            context?.Database.Migrate();
        }
    }
}
