namespace TechArtPortfolio.Layout.Models;

public static class PortfolioData
{
    public static Dictionary<string, Project> Projects { get; } = new()
    {
        ["vulkan-adventures"] = new Project(
            "vulkan-adventures",
            "Vulkan Adventures",
            "WIP of a custom Vulkan Renderer",
            "images/vulkan/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.VulkanP0),
                new TextContent(ParagraphData.VulkanP1),
                new VideoContent("videos/vulkan/Rendershowcase.mp4", "Quick look of the renderer"),
                new TextContent(ParagraphData.VulkanP2),
                new TextContent(ParagraphData.VulkanP3),
                new ImageContent("images/vulkan/DeferredAlbedo.png", "Deferred Albedo Buffer"),
                new ImageContent("images/vulkan/DeferredNormal.png", "Deferred Normal Buffer"),
                new ImageContent("images/vulkan/DeferredMaterial.png", "Deferred Material Parameters Buffer"),
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
            "images/painterly/Thumbnail.png",
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
            "images/ocean/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.OceanP0),
                new VideoContent("videos/ocean/Oceanshowcase.mp4", "Ocean Render (with Painterly filter)"),
                new TextContent(ParagraphData.OceanP1),
                new ImageContent("images/ocean/SpectrumBase.png", "Initial Spectrum Buffer", false),
                new TextContent(ParagraphData.OceanP2),
                new TextContent(ParagraphData.OceanP3),
                new ImageContent("images/ocean/SpectrumContinuous.png", "Continuous Spectrum Buffer", false),
                new TextContent(ParagraphData.OceanP4),
                new ImageContent("images/ocean/ShapeMap.png", "Wave Displacement Map", false),
                new ImageContent("images/ocean/SlopeMap.png", "Wave Normal Map", false),
                new TextContent(ParagraphData.OceanP5),
                new VideoContent("videos/ocean/Clipmapshowcase.mp4", "Ocean Clipmap system"),
                new TextContent(ParagraphData.OceanP6),
            }),
        
        ["voxel-cone-tracing"] = new Project(
            "voxel-cone-tracing",
            "Voxel Cone Tracing GI",
            "Global Illumination with Voxel Cone Tracing and Anisotropic Voxels",
            "images/vct/Thumbnail.png",
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
            "images/clouds/Thumbnail.png",
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
            "images/grass/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.GrassP0),
                new VideoContent("videos/grass/GrassShowcase.mp4", "Grass Render (with Painterly filter)"),
                new TextContent(ParagraphData.GrassP1),
                new ImageContent("images/grass/WindBuffer.png", "Wind Marble noise", false),
                new TextContent(ParagraphData.GrassP2),
                new CodeSnippetContent(CodeData.GrassBurstJob, "cs"),
                new TextContent(ParagraphData.GrassP3),
                new ImageContent("images/grass/GrassBuffer.png", "Grass Normal Buffer"),
                new TextContent(ParagraphData.GrassP4),
                new VideoContent("videos/grass/GrassPaint.mp4", "Grass Painting with Unity Terrain Tool"),
            }),
        
        ["msaa-outlines"] = new Project(
            "msaa-outlines",
            "MSAA Outlines",
            "Sub-Pixel Edge-Detection with unresolved MSAA Buffers",
            "images/outlines/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.OutlinesP0),
                new TextContent(ParagraphData.OutlinesP1),
                new ImageContent("images/outlines/Outlineshowcase.png", "MSAA Outlines with Cel-Shader"),
                new TextContent(ParagraphData.OutlinesP2),
                new ImageContent("images/outlines/ColorBuffer.png", "Outline Color Buffer Pre-pass"),
                new TextContent(ParagraphData.OutlinesP3),
                new ImageContent("images/outlines/OutlineMask.png", "Outline Mask (Quarter-res)"),
                new TextContent(ParagraphData.OutlinesP4),
                new ImageContent("images/outlines/OutlineCloseup.png", "Anti-Aliasing Close-up")
            }),
        
        ["karst-simulation"] = new Project(
            "karst-simulation",
            "Karst Simulation",
            "Real-Time Karst Simulation with Voxel Particles",
            "images/karst/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.KarstP0),
                new LinkButtonContent("https://docs.google.com/document/d/1NGr5QUwLfd7V4fgpwyVmKGn9VzXa_Qp5GAmxDcIB1xE/edit?tab=t.0#heading=h.n4me9648w7i8",
                        "Documentation"),
                new EmbeddedVideoContent("https://www.youtube.com/embed/WCDGYfeXD60"),
                new TextContent(ParagraphData.KarstP1),
                new TextContent(ParagraphData.KarstP2),
                new ImageContent("images/karst/KarstLayers.png", "Simulation Layers"),
                new TextContent(ParagraphData.KarstP3),
                new ImageContent("images/karst/FractureTexture.png", "Fracture Visualization", false),
                new TextContent(ParagraphData.KarstP4),
                new VideoContent("videos/karst/SandFalling.mp4", "Sand Falling in Sinkhole"),
                new TextContent(ParagraphData.KarstP5),
                new CodeSnippetContent(CodeData.FluxPass, "hlsl"),
                new TextContent(ParagraphData.KarstP6),
                new VideoContent("videos/karst/ErosionHolo.mp4", "Eroding Sinkholes")
            }),
        
        ["tile-based-terrain"] = new Project(
            "tile-based-terrain",
            "Tile Based Terrain",
            "Terrain Generator for a Tile-Based Sandbox Game",
            "images/terrain/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.TerrainP0),
                new ImageContent("images/terrain/TerrainBare.png", "Generated Tile-Based Terrain"),
                new TextContent(ParagraphData.TerrainP1),
                new ImageContent("images/terrain/HeightWaterMap.png", "Red Channel: Height Map, Blue Channel: Water Mask", false),
                new TextContent(ParagraphData.TerrainP2),
                new ImageContent("images/terrain/MapDerivatives.png", "Left: Raw Derivative Map, Right: Processed Slope Map"),
                new TextContent(ParagraphData.TerrainP3),
                new ImageContent("images/terrain/ResourceMap.png", "Resource Map. Red Channel: Crystal Mask, Green Channel: Crystal Type", false),
                new TextContent(ParagraphData.TerrainP4),
                new ImageContent("images/terrain/VegetationMap.png", "Vegetation Map. Red Channel: Vegetation Mask, Green & Blue Channel: Vegetation Type", false),
                new TextContent(ParagraphData.TerrainP5),
                new ImageContent("images/terrain/FlorumShot.png", "Florum Gameplay Shot. Environment Assets: Dominique van de Fliert, Plant Creature & Props: Christian Jähndel, Mouse Player & UI Assets: Elain Dittrich Veenker\n")
            }),
    };

    public static Project GetProjectById(string id)
    {
        return Projects[id];
    }
}