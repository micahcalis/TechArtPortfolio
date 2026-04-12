namespace TechArtPortfolio.Layout.Models;

public static class PortfolioData
{
    public static Dictionary<string, Project> Projects { get; } = new()
    {
        ["painterly-rendering"] = new Project(
            "painterly-rendering",
            "Painterly Rendering",
            "Using Surface-Stable Voronoi Flooding",
            "TODO",
            new List<Content>()
            {
                new TextContent(ParagraphData.PainterlyIntro)
            }),
    };

    public static Project GetProjectById(string id)
    {
        return Projects[id];
    }
}