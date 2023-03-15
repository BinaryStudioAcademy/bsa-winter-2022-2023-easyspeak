using EasySpeak.Core.BLL.Interfaces;
using FirebaseAdmin.Auth;

namespace EasySpeak.Core.WebAPI.Middlewares
{
    public class FirebaseAuthMiddleware
    {
        private readonly RequestDelegate next;

        public FirebaseAuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IFirebaseAuthService firebaseAuthService)
        {
            var authToken = context.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authToken) && authToken.StartsWith("Bearer "))
            {
                var idToken = authToken.Substring("Bearer ".Length);

                try
                {
                    var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);

                     firebaseAuthService.SetUserId(decodedToken.Claims["email"].ToString());
                }
                catch (Exception)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
            }
            await next(context);
        }
    }
}
