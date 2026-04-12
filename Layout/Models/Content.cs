namespace TechArtPortfolio.Layout.Models;

public abstract class Content
{
}

public class TextContent : Content
{
    public string Text;

    public TextContent(string text)
    {
        Text = text;
    }
}

public class ImageContent : Content
{
    public string ImageUrl;
    public string Caption;

    public ImageContent(string imageUrl, string caption)
    {
        ImageUrl = imageUrl;
        Caption = caption;
    }
}

public class CodeSnippetContent : Content
{
    public string Code;
    public string Language;

    public CodeSnippetContent(string code, string language)
    {
        Code = code;
        Language = language;
    }
}