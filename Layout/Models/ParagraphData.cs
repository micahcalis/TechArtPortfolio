namespace TechArtPortfolio.Layout.Models;

public static class ParagraphData
{
    public static string PainterlyIntro = "This is an introduction to painterly rendering";
    
    // vulkan
    public static string VulkanP0 =
        "For my graduation, I want to make a stylized watercolor render pipeline. Working with Unity’s Scriptable Render-Pipeline has been great, but its high-level nature and invisible backend make it hard to optimize. For full control and to learn C++, I decided to try out Vulkan.";

    public static string VulkanP1 =
        "After more than 10,000 lines of code and half as many headaches, I have a fully functioning render-pipeline (stylization excluded). Here is a showcase of 1000 unique entities with unique materials, rendered comfortably at ~1.0 ms (1000 fps) on an RTX 3080.";

    public static string VulkanP2 =
        "The objects that are rendered are sphere-traced primitives. The only reason we can render this many, is because they are rendered with a proxy mesh: a cube that also serves as the bounding box of the ray. ";

    public static string VulkanP3 =
        "Because sphere-tracing is expensive, it is important to minimize the amount of fragments that use this algorithm. This can be difficult when pipelines get complicated, as prepasses are required for many effects. Instead of rendering my proxy meshes multiple times, I have decided to use multiple render targets, as you would in a deferred shading pipeline. This way I can add targets for new effects, while having to sphere trace in only one pass. ";

    public static string VulkanP4 =
        "Crucial for any render-pipeline is a decent Frame Graph. My approach is pretty standard, Topologically sorting a Directed Acyclic Graph that I build every frame. It automatically inserts barriers based on listed dependencies in the render passes, and has support for compute passes.";

    public static string VulkanP5 = "Particle Tornado with Compute Shaders:";

    public static string VulkanP6 =
        "Equally as important is Shader development tools. Things I’ve taken for granted, like Properties in ShaderLab and Shader Globals, I’ve had to develop systems for. Luckily, SPIR-V Reflect makes reflection pretty doable. ";
}