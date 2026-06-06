namespace TechArtPortfolio.Layout.Models;

public class BlogPage
{
    public string Header { get; set; }
    public List<Content> Contents { get; set; }

    public BlogPage(string header,
        List<Content> contents)
    {
        Header = header;
        Contents = contents;
    }
}

public class Blog
{
    public string Id { get; set; } 
    public string Title { get; set; } 
    public string Tagline { get; set; } 
    public string CoverImageUrl { get; set; }
    public List<BlogPage> Pages { get; set; }

    public Blog(string id,
        string title,
        string tagline,
        string coverImageUrl,
        List<BlogPage> pages)
    {
        Id = id;
        Title = title;
        Tagline = tagline;
        CoverImageUrl = coverImageUrl;
        Pages = pages;
    }
}