using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTD.Web.Engine.EF;
using RTD.Web.Models;

namespace RTD.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private RssDbContext _rssDbContext;

    public HomeController(ILogger<HomeController> logger, RssDbContext rssDbContext)
    {
        _logger = logger;
        _rssDbContext = rssDbContext;
    }

    public async Task<IActionResult> Index()
    {
        var adminUser = _rssDbContext.AdminUsers.FirstOrDefault() ?? null;
        if (adminUser == null)
        {
            return RedirectToAction("Bootstrap", "Auth");
        }

        var id = await HttpContext.AuthenticateAsync();
        if (id.Failure != null)
        {
            return RedirectToAction("Login", "Auth");
        }

        return View();
    }

    [Route("feed/{id}")]
    [Authorize(CookieAuthenticationDefaults.AuthenticationScheme)]
    public IActionResult ViewFeed(Guid id)
    {
        var feed = _rssDbContext.RssSources.FirstOrDefault(x => x.RssSourceId == id);
        if (feed == null)
        {
            return NotFound();
        }
        
        return View(feed);
    }
    
    [Route("feed/add")]
    public IActionResult AddFeed()
    {
        return View(new FeedModel());
    }

    public IActionResult PartialSidebar()
    {
        var rss = _rssDbContext.RssSources.ToList();
        var discordHooks = _rssDbContext.DiscordHooks.ToList();
        return PartialView("_Sidebar", new SidebarModel() { DiscordHooks = discordHooks, RssSources = rss });
    }
     
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}