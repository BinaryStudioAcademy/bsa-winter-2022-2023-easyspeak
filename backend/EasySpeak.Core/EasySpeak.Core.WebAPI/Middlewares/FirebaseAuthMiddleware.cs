using EasySpeak.Core.BLL.Interfaces;

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

            //if (!string.IsNullOrEmpty(authToken) && authToken.StartsWith("Bearer "))
            //{
            //    var idToken = authToken.Split(' ')[1];

            //    var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);

            //    var userEmail = decodedToken.Claims["email"].ToString();

            //    if (userEmail != null)
            //    {
            //        await firebaseAuthService.SetUserId(userEmail);
            //    }
            //}

            await next(context);
        }
    }
}
