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
    public bool EnableOverflow;

    public ImageContent(string imageUrl, string caption, bool enableOverflow = true)
    {
        ImageUrl = imageUrl;
        Caption = caption;
        EnableOverflow = enableOverflow;
    }
}

public class VideoContent : Content
{
    public string VideoUrl;
    public string Caption;

    public VideoContent(string videoUrl, string caption)
    {
        VideoUrl = videoUrl;
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

public class LinkButtonContent : Content
{
    public string Url;
    public string Caption;

    public LinkButtonContent(string url, string caption)
    {
        Url = url;
        Caption = caption;
    }
}

public class EmbeddedVideoContent : Content
{
    public string VideoUrl;

    public EmbeddedVideoContent(string videoUrl)
    {
        VideoUrl = videoUrl;
    }
}