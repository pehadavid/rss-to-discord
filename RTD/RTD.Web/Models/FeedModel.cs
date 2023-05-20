using RTD.Web.Engine.EF;

namespace RTD.Web.Models;

public class FeedModel : RssSource
{

    public string? Error { get; set; }

    public bool HasError()
    {
        return !string.IsNullOrWhiteSpace(Error);
    }
}