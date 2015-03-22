using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Security.Notifications;
using Microsoft.AspNet.Security.OAuthBearer;

namespace Herolab.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// For all methods if if you call SkipToNextMiddleware, the framework will immediately return null
    /// </remarks>
    public class AuthenticationNotificationHandler
    {
        private static readonly Task CompletedTask = Task.FromResult(false);

        /// <summary>
        /// OnMessageReceived is received first, if HandleResponse is called, the framework will return notification.AuthenticationTicket 
        /// immediately, avoiding calls to SecurityTokenReceived or SecurityTokenValidators notification can set the token
        /// </summary>
        public static Task OnMessageReceived(MessageReceivedNotification<HttpContext, OAuthBearerAuthenticationOptions> notification)
        {
            
            notification.Token = null;
            return CompletedTask;
        }

        /// <summary>
        /// SecurityTokenReceived is called using the Token provided by MessageReceived. SecurityTokenReceived must convert that token and
        /// set Notification.AuthenticationTicket.  If HandleResponse is called, the AuthenticationTicket is returned immediately, avoiding
        /// calls to SecurityTokenValidated.
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public static Task OnSecurityTokenReceived(SecurityTokenReceivedNotification<HttpContext, OAuthBearerAuthenticationOptions> notification)
        {
            return CompletedTask;
        }

        /// <summary>
        /// CanReadToken is called for each registered SecurityTokenValidator registered on Options.SecurityTokenValidators.  For the first validator
        /// that returns true, it will validate the token and return a ClaimsPrincipal.  The framework then calls SecurityTokenValidated with the 
        /// creates an AuthenticationTicket in the notification..
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public static Task OnSecurityTokenValidated(SecurityTokenValidatedNotification<HttpContext, OAuthBearerAuthenticationOptions> notification)
        {
            return CompletedTask;
        }

        /// <summary>
        /// if you call HandleResponse, the framework will return notification.AuthenticationTicket as if the error hadn't occured.
        //  if you do nothing in this method, the exception gets rethrown
        /// </summary>
        public static Task OnAuthenticationFailed(AuthenticationFailedNotification<HttpContext, OAuthBearerAuthenticationOptions> notification)
        {
            
            return CompletedTask;
        }

        /// <summary>
        /// I am not sure how this is relevant for a bearer token handler, but this will be called when a challenge has been raised and the result is not already set to a 401.
        /// </summary>
        public static Task OnApplyChallenge(AuthenticationChallengeNotification<OAuthBearerAuthenticationOptions> notification)
        {
            return CompletedTask;
        }


    }
}