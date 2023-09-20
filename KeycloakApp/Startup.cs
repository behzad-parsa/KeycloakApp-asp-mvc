using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(KeycloakApp.Startup))]

namespace KeycloakApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "keycloak_sso_auth",
                CookieHttpOnly = true,
                CookieName = "keycloak_cookie",
                CookieSameSite = SameSiteMode.None,
                CookieSecure = CookieSecureOption.Always,
                CookieDomain = "localhost",
                CookiePath = "/"
            });


        }
    }
}








//app.SetDefaultSignInAsAuthenticationType(persistentAuthType);
//app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
//{
//    AuthenticationType = "KeycloakSSO",
//    Authority = "https://sso.karafariniomid.ir/auth/realms/master/",
//    ClientId = "kms-client-id",
//    ClientSecret = "wctgLSoVLvi2x8cXGTSxZlHBohYSJCIu",
//    SignInAsAuthenticationType = persistentAuthType,
//    ResponseType = "code",
//    SaveTokens = true,
//    Scope = "openid",
//    RedirectUri = WebConfigValues.SecurityRoot + "/api/sso/KeycloakSignIn",
//    RedeemCode = true,
//    Notifications = new OpenIdConnectAuthenticationNotifications()
//    {

//        RedirectToIdentityProvider = async (context) =>
//        {
//            context.ProtocolMessage.Parameters["code_challenge"] = "0KpkdgYxlnrYb9pJWCHhXQqirurQTPfX7McwyZ7drQQ";
//            context.ProtocolMessage.Parameters["code_challenge_method"] = "plain";
//        },
//        AuthorizationCodeReceived = async (context) =>
//        {
//            context.TokenEndpointRequest.Parameters["code_verifier"] = "0KpkdgYxlnrYb9pJWCHhXQqirurQTPfX7McwyZ7drQQ";
//        },
//        TokenResponseReceived = async (responseToken) =>
//        {
//            responseToken.Request.Headers.Add("Authorization", new[] { responseToken.TokenEndpointResponse.AccessToken });
//            responseToken.Request.Headers.Add("RefreshToken", new[] { responseToken.TokenEndpointResponse.RefreshToken });

//            responseToken.SkipToNextMiddleware();
//        },
//        SecurityTokenReceived = async (param) =>
//        {
//        },
//        MessageReceived = async (request) =>
//        {
//        },
//    },
//});