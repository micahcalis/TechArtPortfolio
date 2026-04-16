namespace TechArtPortfolio.Layout.Models;

public static class PortfolioData
{
    public static Dictionary<string, Project> Projects { get; } = new()
    {
        ["vulkan-adventures"] = new Project(
            "vulkan-adventures",
            "Vulkan Adventures",
            "WIP of a custom Vulkan Renderer",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.VulkanP0),
                new TextContent(ParagraphData.VulkanP1),
                new VideoContent("videos/vulkan/Rendershowcase.mp4", "Quick look of the renderer"),
                new TextContent(ParagraphData.VulkanP2),
                new TextContent(ParagraphData.VulkanP3),
                new ImageContent("images/vulkan/DeferredAlbedo.png", "Deferred Albedo"),
                new ImageContent("images/vulkan/DeferredNormal.png", "Deferred Normal"),
                new ImageContent("images/vulkan/DeferredMaterial.png", "Deferred Material Parameters"),
                new TextContent(ParagraphData.VulkanP4),
                new CodeSnippetContent(CodeData.VulkanRenderPass, "cpp"),
                new TextContent(ParagraphData.VulkanP5),
                new VideoContent("videos/vulkan/Tornadoshowcase.mp4", "Particle System with SSBO's"),
                new TextContent(ParagraphData.VulkanP6),
                new CodeSnippetContent(CodeData.VulkanShader, "slang")
            }),
        
        ["painterly-rendering"] = new Project(
            "painterly-rendering",
            "Painterly Rendering",
            "Using Surface-Stable Voronoi Flooding",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.PainterlyP0),
                new VideoContent("videos/painterly/FirstPainterlyshowcase.mp4", "Painterly effect. Environment models and textures: Quixel"),
                new TextContent(ParagraphData.PainterlyP1),
                new VideoContent("videos/painterly/PainterlyNoise.mp4", "Surface-Stable Voronoi Noise"),
                new TextContent(ParagraphData.PainterlyP2),
                new ImageContent("images/painterly/BlendPainterlyNoise.png", "Blended Levels of Surface-Stable Noise"),
                new TextContent(ParagraphData.PainterlyP3),
                new ImageContent("images/painterly/FloodInitialization.png", "Initialization Buffer. RG: Screen UV, B: Cell Distance"),               
                new TextContent(ParagraphData.PainterlyP4),
                new CodeSnippetContent(CodeData.FloodAlgorithm, "hlsl"),
                new TextContent(ParagraphData.PainterlyP5),
                new ImageContent("images/painterly/FloodResolve.png", "Resolved Flood Buffer"),
                new TextContent(ParagraphData.PainterlyP6),
                new ImageContent("images/painterly/FloodResolveCombined.png", "Resolved Buffer with both levels combined"),
                new TextContent(ParagraphData.PainterlyP7),
            }),
        
        ["ocean-shader"] = new Project(
            "ocean-shader",
            "Ocean Shader",
            "With inverse Fast Fourier Transform",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.OceanP0),
                new VideoContent("videos/ocean/Oceanshowcase.mp4", "Ocean Render (with Painterly filter)"),
                new TextContent(ParagraphData.OceanP1),
                new ImageContent("images/ocean/SpectrumBase.png", "Initial Spectrum Buffer"),
                new TextContent(ParagraphData.OceanP2),
                new TextContent(ParagraphData.OceanP3),
                new ImageContent("images/ocean/SpectrumContinuous.png", "Continuous Spectrum Buffer"),
                new TextContent(ParagraphData.OceanP4),
                new ImageContent("images/ocean/ShapeMap.png", "Wave Displacement Map"),
                new ImageContent("images/ocean/SlopeMap.png", "Wave Normal Map"),
                new TextContent(ParagraphData.OceanP5),
                new VideoContent("videos/ocean/Clipmapshowcase.mp4", "Ocean Clipmap system"),
                new TextContent(ParagraphData.OceanP6),
            }),
        
        ["voxel-cone-tracing"] = new Project(
            "voxel-cone-tracing",
            "Voxel Cone Tracing GI",
            "Global Illumination with Voxel Cone Tracing and Anisotropic Voxels",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.VCTP0),
                new VideoContent("videos/vct/VCTshowcase.mp4", "VCT Render (with Painterly filter)"),
                new TextContent(ParagraphData.VCTP1),
                new ImageContent("images/vct/VoxelsDebug.png", "Voxels debug view"),
                new TextContent(ParagraphData.VCTP2),
                new TextContent(ParagraphData.VCTP3),
                new VideoContent("videos/vct/VoxelsDebug.mp4", "Voxels debug view in order: Albedo, First Bounce, Second Bounce, Normals"),
                new TextContent(ParagraphData.VCTP4),
                new ImageContent("images/vct/IndirectLighting.png", "Raw Screenspace Cone Tracing Buffer (Quarter-res)"),
                new TextContent(ParagraphData.VCTP5),
                new ImageContent("images/vct/BlurLighting.png", "Filtered Screenspace Cone Tracing Buffer"),
                new TextContent(ParagraphData.VCTP6),
            }),
        
        ["volumetric-clouds"] = new Project(
            "volumetric-clouds",
            "Volumetric Clouds",
            "Real-Time Clouds with Volumetric Raymarching",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.CloudsP0),
                new VideoContent("videos/clouds/Cloudsshowcase.mp4", "Clouds Render (with Painterly filter)"),
                new TextContent(ParagraphData.CloudsP1),
                new ImageContent("images/clouds/PerlinWorley.png", "Left: Shape Noise channels, Right: Detail Noise channels"),
                new TextContent(ParagraphData.CloudsP2),
                new TextContent(ParagraphData.CloudsP3),
                new CodeSnippetContent(CodeData.CloudMarchLoop, "hlsl"),
                new TextContent(ParagraphData.CloudsP4),
                new TextContent(ParagraphData.CloudsP5),
                new CodeSnippetContent(CodeData.LightMarchLoop, "hlsl"),
                new TextContent(ParagraphData.CloudsP6),
                new ImageContent("images/clouds/RawCloudRender.png", "Raw Cloud Render (Quarter Res)"),
                new TextContent(ParagraphData.CloudsP7)
            }),
        
        ["infinite-grass"] = new Project(
            "infinite-grass",
            "Infinite Grass",
            "Infinite Grass with GPU Instancing",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.PainterlyIntro),
                new CodeSnippetContent(CodeData.TestCode, "cpp"),
            }),
        
        ["msaa-outlines"] = new Project(
            "msaa-outlines",
            "MSAA Outlines",
            "Sub-Pixel Edge-Detection with unresolved MSAA Buffers",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.PainterlyIntro)
            }),
        
        ["karst-simulation"] = new Project(
            "karst-simulation",
            "Karst Simulation",
            "Real-Time Karst Simulation with Voxel Particles",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.PainterlyIntro)
            }),
        
        ["tile-based-terrain"] = new Project(
            "tile-based-terrain",
            "Tile Based Terrain",
            "Terrain Generator for a Tile-Based Sandbox Game",
            "images/CatAnguish.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.PainterlyIntro)
            }),
        
        ["extra-shaders"] = new Project(
            "extra-shaders",
            "Extra Shaders",
            "Gallery of Shaders & VFX",
            "images/CatAnguish.png",
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