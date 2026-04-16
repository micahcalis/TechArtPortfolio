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

    public static string PainterlyP0 =
        "For a project called ‘Midas’, I worked on a render-pipeline with two layers: a painterly stylized background, and a cel-shaded cartoon foreground. The concept was to bring an 2D animation film aesthetic into 3D, with a nostalgic Dutch environment. Looking at existing solutions for painterly rendering, such as the Anisotropic Kuwahara filter or Compute-Based Stroke Rendering, I wasn’t quite satisfied with either. I’ve come up with a solution that I dubbed Surface-Stable Voronoi Flooding.";

    public static string PainterlyP1 =
        "The idea started when I implemented a Kuwahara filter, I noticed the pattern it creates was quite similar to Voronoi noise. After experimentation with Screen-Space Voronoi, 3D Voronoi and more, I was not able to create a satisfying noise pattern that remained stable. I took inspiration from a Runevision video, where he introduces a topic called Surface-Stable Fractal Dithering. While the dithering is not relevant, the fractal UV derivative technique is. Using the frequency to scale the noise, I gained the following effect.";

    public static string PainterlyP2 =
        "Runevision solves the tiling issues by implementing an intricate dithering system, which isn’t applicable for this effect, since we are generating noise. Instead, we use two levels (and a smoothed interpolation) to blend noise values. ";

    public static string PainterlyP3 =
        "For the ‘Flooding’ part, this is where the effect becomes painterly. Essentially, like shown before, we render the two Surface-Stable Voronoi buffers, without combining them. The RGB channels store the ID of the Voronoi cell, and the Alpha stores the distance to the center. Note that I’m not using regular Voronoi noise with a Euclidean distance, rather a Line SDF for stretchier cells.";

    public static string PainterlyP4 =
        "For each buffer we do a set of Ping-Pong Blitting, N amount of times (N varies per buffer, I use 4 and 8). In these Blits, every pixel looks in a 3x3 at its neighbours, and finds the Screen-Space UV coordinates with the shortest SDF distance in its own cell. It then outputs these UV coordinates and the SDF distance. Note that these passes are rendered at half-resolution to make this effect scaleable.";

    public static string PainterlyP5 =
        "After a few passes, most of the pixels will have found a better UV candidate, and the cells naturally converge towards the center of the SDF. This UV is then used to sample the opaque buffer, creating the following effect.";

    public static string PainterlyP6 =
        "Finally, the two buffers are blended using the fractal method, to get rid of the seams. ";

    public static string PainterlyP7 =
        "While this technique works especially well on a static camera, it does have flickering issues, noticeably around the edges of objects. One hypothesis I haven’t tested is using edge detection in the flooding algorithm, this could help prevent cell overflow.";

    public static string OceanP0 =
        "For the open-world of a project called ‘Midas’, we needed an ocean as the environment is set on a Dutch Wadden island. In my previous attempts of making water shaders, I have used a ‘Sum of Sines’ approach and a ripple simulation, but both of these effects are quite limited in scalability. Oceans have complex waves that can’t be computed at runtime by naively stacking sine waves. With the use of the inverse Fast Fourier Transform, we essentially reverse engineer the output of a wave into a displacement map, by sampling a spectrum of frequencies.";
    
    public static string Ocean
}