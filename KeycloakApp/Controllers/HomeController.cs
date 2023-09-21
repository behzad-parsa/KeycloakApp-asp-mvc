using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace KeycloakApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Callback()
        {
            //in web api: HttpContext.Current.Request.Headers
            var accessToken = HttpContext.Request.Headers["Authorization"];
            var refreshToken = HttpContext.Request.Headers["RefreshToken"];
            var decodedToken = Helper.DecodeToken(accessToken);
            var username = decodedToken.Claims.FirstOrDefault(x => x.Type == "preferred_username").Value;
            var fullname = decodedToken.Claims.FirstOrDefault(x => x.Type == "name").Value;
            var claims = new[]
            {
                new Claim("UserName",username),
                new Claim("FullName",fullname),
                new Claim("AccessToken",accessToken.ToString()),
                new Claim("RefreshToken",refreshToken.ToString()),
            };

            var identity = new ClaimsIdentity(claims, "keycloak_sso_auth");

            Request.GetOwinContext().Authentication.SignIn(identity);
            return RedirectToAction("About");
        }


    }
}