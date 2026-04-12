namespace TechArtPortfolio.Layout.Models;

public class Project
{
    public string Id { get; set; } 
    public string Title { get; set; } 
    public string Tagline { get; set; } 
    public string CoverImageUrl { get; set; } 
    public List<Content> Contents { get; set; } 

    public Project(string id, 
        string title, 
        string tagline, 
        string coverImageUrl,
        List<Content> contents)
    {
        Id = id;
        Title = title;
        Tagline = tagline;
        CoverImageUrl = coverImageUrl;
        Contents = contents;
    }
}