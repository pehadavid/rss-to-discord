using RTD.Web.Engine.EF;

namespace RTD.Web.Models;

public class SidebarModel
{
    public List<DiscordHook> DiscordHooks { get; set; }
    public List<RssSource> RssSources { get; set; }
}