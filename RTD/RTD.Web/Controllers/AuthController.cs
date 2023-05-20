using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RTD.Web.Engine.EF;
using RTD.Web.Models;

namespace RTD.Web.Controllers;

public class AuthController : Controller
{
    private RssDbContext _rssDbContext;

    public AuthController(RssDbContext rssDbContext)
    {
        _rssDbContext = rssDbContext;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Bootstrap()
    {
        return View(new AccountModel());
    }

    [HttpPost("auth/bootstrap")]
    public async Task<IActionResult> Bootstrap_POST(AccountModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AdminUser() { UserName = model.Username, Active = true, DateCreated = DateTime.UtcNow};
            user.SetPassword(model.Password);
            _rssDbContext.AdminUsers.Add(user);
            await _rssDbContext.SaveChangesAsync();
            await CreateCredsAsync(user);
            return Redirect("/");
        }

        model.Error = string.Join(", ", ModelState.Select(x => x.Value.Errors)
            .Where(y => y.Count > 0)
            .ToList()
            .SelectMany(z => z)
            .Select(x => x.ErrorMessage));
        return View("Bootstrap", model);
    }

    private async Task CreateCredsAsync(AdminUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            IsPersistent = true,
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }
}