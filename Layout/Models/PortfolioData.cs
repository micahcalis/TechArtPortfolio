namespace TechArtPortfolio.Layout.Models;

public static class PortfolioData
{
    public static Dictionary<string, Project> Projects { get; } = new()
    {
        ["watercolor-stylization"] = new Project(
            "watercolor-stylization",
            "Watercolor Stylization",
            "Translating Watercolor Techniques to a Stylized Pipeline",
            "images/wcstylization/Cover.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.WcStylizationP0),
                new VideoContent("videos/wcstylization/StylizationShowcase.mp4", "My Watercolor Galaxy Gameplay"),
                new TextContent(ParagraphData.WcStylizationP1),
                new LinkButtonContent("https://micahcalis.com/blog/watercolor-rendering", "Blog"),
                new TextContent(ParagraphData.WcStylizationP2),
                new ImageContent("images/wcstylization/Cangiante.png", "Cangiante Shading on Galaxy Objects"),
                new TextContent(ParagraphData.WcStylizationP3),
                new TextContent(ParagraphData.WcStylizationP4),
                new ImageContent("images/wcstylization/HandTremor.png", "Hand Tremor U-Offset Buffer"),
                new TextContent(ParagraphData.WcStylizationP5),
                new ImageContent("images/wcstylization/WatercolorControl.png", "Watercolor Control Buffer (RGBA Channels)"),
                new TextContent(ParagraphData.WcStylizationP6),
                new ImageContent("images/wcstylization/Wetonwet.png", "Wet-on-wet effect on distant Galaxy Objects")
            }),
        
        ["galaxy-sdfs"] = new Project(
            "galaxy-sdfs",
            "Galaxy Signed Distance Fields",
            "Rendering SDF's for a stylized Watercolor Galaxy",
            "images/galaxysdf/Cover.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.GalaxySDFP0),
                new TextContent(ParagraphData.GalaxySDFP1),
                new VideoContent("videos/galaxysdf/SpaceGoo.mp4", "Stylized Space Goo in 'My Watercolor Galaxy'"),
                new CodeSnippetContent(CodeData.SpaceGooSDF, "slang"),
                new TextContent(ParagraphData.GalaxySDFP2),
                new LinkButtonContent("https://micahcalis.com/blog/sphere-tracing-pipeline", "Blog"),
                new TextContent(ParagraphData.GalaxySDFP3),
                new ImageContent("images/galaxysdf/PlanetAsteroids.png", "Stylized Planet & Asteroids in 'My Watercolor Galaxy"),
                new TextContent(ParagraphData.GalaxySDFP4),
                new ImageContent("images/galaxysdf/Sun.png", "Stylized Sun in 'My Watercolor Galaxy"),
                new ImageContent("images/galaxysdf/Blackhole.png", "Stylized Blackhole in 'My Watercolor Galaxy"),
                new TextContent(ParagraphData.GalaxySDFP5),
                new LinkButtonContent("https://www.shadertoy.com/view/3sSBDV", "ShaderToy"),
                new TextContent(ParagraphData.GalaxySDFP6),
                new ImageContent("images/galaxysdf/Player.png", "Stylized UFO & Alien in 'My Watercolor Galaxy"),
            }),
        
        ["stylized-nebulae"] = new Project(
            "stylized-nebulae",
            "Stylized Nebulae",
            "With Screen-Space Tile Partitioning",
            "images/nebula/Cover.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.NebulaP0),
                new VideoContent("videos/nebula/NebulaShowcase.mp4", "Stylized Nebulae in 'My Watercolor Galaxy'"),
                new TextContent(ParagraphData.NebulaP1),
                new TextContent(ParagraphData.NebulaP2),
                new CodeSnippetContent(CodeData.NebulaTiles, "slang"),
                new TextContent(ParagraphData.NebulaP3),
                new ImageContent("images/nebula/HalfResBuffer.png", "Raw Half Resolution Render"),
                new TextContent(ParagraphData.NebulaP4),
                new ImageContent("images/nebula/Upsample.png", "Upsampled Main Color Result"),
                new TextContent(ParagraphData.NebulaP5),
                new ImageContent("images/nebula/NebulaColors.png", "Nebulae with varying color combinations"),
            }),
        
        ["watercolor-simulation"] = new Project(
            "watercolor-simulation",
            "Watercolor Simulation",
            "With Kubelka-Munk Pigment rendering",
            "images/watercolsim/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.WaterColSimP1),
                new VideoContent("videos/watercolsim/SimulationShowcase.mp4", "Showcase of Watercolor Simulation in game prototype"),
                new TextContent(ParagraphData.WaterColorSim2),
                new TextContent(ParagraphData.WaterColorSim3),
                new ImageContent("images/watercolsim/WaterLayer.png", "Single Channel Water Layer", false),
                new TextContent(ParagraphData.WaterColorSim4),
                new TextContent(ParagraphData.WaterColorSim5),
                new ImageContent("images/watercolsim/PigmentLayers.png", "Slice of Pigment Layers Array", false),
                new ImageContent("images/watercolsim/FluxBuffer.png", "Fluid Flux Buffer", false),
                new TextContent(ParagraphData.WaterColorSim6),
                new ImageContent("images/watercolsim/DepositedLayer.png", "Slice of Deposited Buffer Array", false),
                new TextContent(ParagraphData.WaterColorSim7),
                new CodeSnippetContent(CodeData.KubelkaMunk, "slang")
            }),
        
        ["vulkan-engine"] = new Project(
            "vulkan-engine",
            "Vulkan Engine",
            "Making a Custom Renderer with Vulkan",
            "images/vulkan/Thumbnail.png",
            new List<Content>()
            {
                new TextContent(ParagraphData.VulkanEngineP0),
                new TextContent(ParagraphData.VulkanEngineP1),
                new VideoContent("videos/vulkan/Rendershowcase.mp4", "Quick look of the renderer"),
                new TextContent(ParagraphData.VulkanEngineP2),
                new CodeSnippetContent(CodeData.VulkanRenderPass, "cpp"),
                new TextContent(ParagraphData.VulkanEngineP3),
                new ImageContent("images/vulkan/HierarchyUML.png", "UML Scene Draw Command", false),
                new TextContent(ParagraphData.VulkanEngineP4),
                new TextContent(ParagraphData.VulkanEngineP5),
                new CodeSnippetContent(CodeData.VulkanShader, "slang"),
                new TextContent(ParagraphData.VulkanEngineP6),
                new CodeSnippetContent(CodeData.VulkanRenderObjects, "cpp"),
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

    public static Dictionary<string, Blog> Blogs { get; } = new()
    {
        ["watercolor-rendering"] = new Blog(
                "watercolor-rendering",
                "Watercolor Rendering",
                "With Cangiante Shading, Surface & Screen Stable Noise & Post-Processing",
                "images/wcrendering/WatercolorCover.png",
                new List<BlogPage>()
                {
                    new BlogPage(
                        "Introduction",
                        new List<Content>()
                        {
                            new HeaderContent("Watercolor Stylization"),
                            new TextContent(ParagraphData.WatercolorBlogP1_0),
                            new ImageContent("images/wcrendering/WatercolorCover.png", "In-Game Screenshot of 'My Watercolor Galaxy'"),
                            new TextContent(ParagraphData.WatercolorBlogP1_1),
                            new LinkButtonContent("https://dr.ntu.edu.sg/server/api/core/bitstreams/39c56447-f3b8-43cd-892e-e18313d78fdb/content", "Montesdeoca Paper"),
                            new TextContent(ParagraphData.WatercolorBlogP1_2),
                            new HeaderContent("Multiple Render Targets"),
                            new TextContent(ParagraphData.WatercolorBlogP1_3),
                            new HeaderContent("Expected Knowledge"),
                            new TextContent(ParagraphData.WatercolorBlogP1_4),
                            new TextContent(ParagraphData.WatercolorBlogP1_5),
                        }),
                    new BlogPage(
                        "Render Pipeline",
                        new List<Content>()
                        {
                            new HeaderContent("Overview"),
                            new ImageContent("images/wcrendering/Pipeline.png", "Render Pipeline Overview", false, 0.5f),
                            new TextContent(ParagraphData.WatercolorBlogP2_0),
                            new HeaderContent("Watercolor Geometry Buffers"),
                            new TextContent(ParagraphData.WatercolorBlogP2_1),
                            new ImageContent("images/wcrendering/ControlRed.png", "Watercolor Control Red Channel"),
                            new TextContent(ParagraphData.WatercolorBlogP2_2),
                            new CodeSnippetContent(CodeData.DistortionChannel, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP2_3),
                            new ImageContent("images/wcrendering/ControlGreen.png", "Watercolor Control Green Channel"),
                            new TextContent(ParagraphData.WatercolorBlogP2_4),
                            new CodeSnippetContent(CodeData.GranulationChannel, "slang"),
                            new ImageContent("images/wcrendering/ControlBlue.png", "Watercolor Control Blue Channel"),
                            new TextContent(ParagraphData.WatercolorBlogP2_5),
                            new CodeSnippetContent(CodeData.ColorBleedChannel, "slang"),
                            new ImageContent("images/wcrendering/ControlAlpha.png", "Watercolor Control Alpha Channel"),
                            new TextContent(ParagraphData.WatercolorBlogP2_6),
                            new CodeSnippetContent(CodeData.TurbulenceChannel, "slang"),
                            new ImageContent("images/wcrendering/OffsetBuffer.png", "Offset Buffer Red Channel"),
                            new TextContent(ParagraphData.WatercolorBlogP2_7),
                            new CodeSnippetContent(CodeData.HandTremorOffsetChannel, "slang"),
                        }),
                    new BlogPage(
                        "Surface & Screen Stable Noise",
                        new List<Content>()
                        {
                            new HeaderContent("Fractal Levels"),
                            new TextContent(ParagraphData.WatercolorBlogP3_0),
                            new TextContent(ParagraphData.WatercolorBlogP3_1),
                            new LinkButtonContent("https://www.youtube.com/watch?v=HPqGaIMVuLs", "Runevision Video"),
                            new CodeSnippetContent(CodeData.SSSNFrequency, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP3_2),
                            new ImageContent("images/wcrendering/EllipseVisualizer.png", "Projected Ellipse Visualization", false),
                            new TextContent(ParagraphData.WatercolorBlogP3_3),
                            new TextContent(ParagraphData.WatercolorBlogP3_4),
                            new CodeSnippetContent(CodeData.SSSNFractalData, "slang"),
                            new HeaderContent("Fractal Sampling & Blending"),
                            new TextContent(ParagraphData.WatercolorBlogP3_5),
                            new ImageContent("images/wcrendering/SingleLevelSSSN.png", "Seams from sampling noise with Low Level Scale"),
                            new TextContent(ParagraphData.WatercolorBlogP3_6),
                            new ImageContent("images/wcrendering/MultiLevelSSSN.png", "Noise pattern using Multi Level Interpolation"),
                            new CodeSnippetContent(CodeData.FractalSampler, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP3_7),
                            new TextContent(ParagraphData.WatercolorBlogP3_8),
                            new CodeSnippetContent(CodeData.FractalScale, "slang")
                        }),
                    new BlogPage(
                        "Cangiante Shading",
                        new List<Content>()
                        {
                            new TextContent(ParagraphData.WatercolorBlogP4_0),
                            new HeaderContent("Technique & Concept"),
                            new TextContent(ParagraphData.WatercolorBlogP4_1),
                            new TextContent(ParagraphData.WatercolorBlogP4_2),
                            new HeaderContent("Shading Model"),
                            new ImageContent("images/wcrendering/CangianteResult.png", "Cangiante Shading Model"),
                            new TextContent(ParagraphData.WatercolorBlogP4_3),
                            new TextContent(ParagraphData.WatercolorBlogP4_4),
                            new CodeSnippetContent(CodeData.WCRDFData, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP4_5),
                            new CodeSnippetContent(CodeData.CangianteArea, "slang"),
                            new ImageContent("images/wcrendering/CangianteArea.png", "Left: Dilute Area = 0.5, Right: Dilute Area = 1.0"),
                            new TextContent(ParagraphData.WatercolorBlogP4_6),
                            new CodeSnippetContent(CodeData.CangianteColor, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP4_7),
                            new ImageContent("images/wcrendering/CangianteDilution.png", "Left: Cangiante = 0.28, Dilution = 0.65, Dilution Area = 0.65. Right:  Cangiante = 0.47, Dilution = 0.76, Dilution Area = 0.74"),
                            new TextContent(ParagraphData.WatercolorBlogP4_8),
                            new ImageContent("images/wcrendering/CangianteLightDark.png", "Left: LightColorIntensity = 0.25, DarkIntensity = 0.25. Right: LightColorIntensity = 1.00, DarkIntensity = 1.00"),
                            new TextContent(ParagraphData.WatercolorBlogP4_9),
                            new ImageContent("images/wcrendering/SpecularResult.png", "Specular Highlights with Post-Processing"),
                            new CodeSnippetContent(CodeData.CangianteSpecular, "slang"),
                            new HeaderContent("Scrape Noise"),
                            new TextContent(ParagraphData.WatercolorBlogP4_10),
                            new ImageContent("images/wcrendering/Nassau.png", "A Wall Naussau, Winslow Homer (1898)"),
                            new TextContent(ParagraphData.WatercolorBlogP4_11),
                            new LinkButtonContent("https://iquilezles.org/articles/voronoilines/ ", "I.Q. Article"),
                            new CodeSnippetContent(CodeData.PolygonalVoronoi, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP4_12),
                            new CodeSnippetContent(CodeData.ScrapeNoise, "slang"),
                            new ImageContent("images/wcrendering/ScrapeNoiseResult.png", "Scrape Noise on Asteroids & Planet Ring"),
                            new CodeSnippetContent(CodeData.CangianteFull, "slang"),
                        }),
                    new BlogPage(
                        "Post-Processing",
                        new List<Content>()
                        {
                            new TextContent(ParagraphData.WatercolorBlogP5_0),
                            new HeaderContent("Canvas Texture"),
                            new TextContent(ParagraphData.WatercolorBlogP5_1),
                            new TextContent(ParagraphData.WatercolorBlogP5_2),
                            new CodeSnippetContent(CodeData.DynamicCanvasUpdater, "cpp"),
                            new TextContent(ParagraphData.WatercolorBlogP5_3),
                            new CodeSnippetContent(CodeData.CanvasPaperSampler, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP5_4),
                            new CodeSnippetContent(CodeData.PaperDistortion, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP5_5),
                            new CodeSnippetContent(CodeData.PaperGranulation, "slang"),
                            new HeaderContent("Hand Tremor Offset"),
                            new TextContent(ParagraphData.WatercolorBlogP5_6),
                            new ImageContent("images/wcrendering/NoiseDiscontinuity.png", "Discontinuous Noise Offset Buffer"),
                            new TextContent(ParagraphData.WatercolorBlogP5_7),
                            new TextContent(ParagraphData.WatercolorBlogP5_8),
                            new CodeSnippetContent(CodeData.EdgeBlurrer, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP5_9),
                            new ImageContent("images/wcrendering/NoiseContinuous.png", "Continuous Noise Offset Buffer"),
                            new TextContent(ParagraphData.WatercolorBlogP5_10),
                            new CodeSnippetContent(CodeData.TremorOffsetter, "slang"),
                            new HeaderContent("Wet-on-wet"),
                            new TextContent(ParagraphData.WatercolorBlogP5_11),
                            new CodeSnippetContent(CodeData.ColorBleeder, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP5_12),
                            new CodeSnippetContent(CodeData.GaussianBlur, "slang"),
                            new ImageContent("images/wcrendering/ColorBleedBefore.png", "Color Main Buffer before blurring"),
                            new ImageContent("images/wcrendering/ColorBleedAfter.png", "Blur Color Buffer after blurring"),
                            new HeaderContent("Edge Darkening"),
                            new TextContent(ParagraphData.WatercolorBlogP5_13),
                            new TextContent(ParagraphData.WatercolorBlogP5_14),
                            new CodeSnippetContent(CodeData.EdgeDarkening, "slang"),
                            new HeaderContent("Enhancement Filters"),
                            new TextContent(ParagraphData.WatercolorBlogP5_15),
                            new TextContent(ParagraphData.WatercolorBlogP5_16),
                            new CodeSnippetContent(CodeData.EnhancementCangiante, "slang"),
                            new TextContent(ParagraphData.WatercolorBlogP5_17),
                            new CodeSnippetContent(CodeData.EnhancementVibrancy, "slang"),
                            new ImageContent("images/wcrendering/VibrancyBefore.png", "Post-Processing without Vibrancy Enhancement"),
                            new ImageContent("images/wcrendering/VibrancyAfter.png", "Post-Processing after Vibrancy Enhancement")
                        }),
                    new BlogPage(
                        "Results & Refinements",
                        new List<Content>()
                        {
                            new HeaderContent("Implementation Results"),
                            new TextContent(ParagraphData.WatercolorBlogP6_0),
                            new ImageContent("images/wcrendering/Results1.png", "In-Game Screenshot of 'My Watercolor Galaxy'"),
                            new ImageContent("images/wcrendering/Results2.png", "In-Game Screenshot of 'My Watercolor Galaxy'"),
                            new ImageContent("images/wcrendering/Results3.png", "In-Game Screenshot of 'My Watercolor Galaxy'"),
                            new ImageContent("images/wcrendering/Results4.png", "In-Game Screenshot of 'My Watercolor Galaxy'"),
                            new HeaderContent("Future Refinements & Improvements"),
                            new TextContent(ParagraphData.WatercolorBlogP6_1),
                            new TextContent(ParagraphData.WatercolorBlogP6_2),
                            new TextContent(ParagraphData.WatercolorBlogP6_3)
                        })
                }),   
        
        ["sphere-tracing-pipeline"] = new Blog(
            "sphere-tracing-pipeline",
            "Sphere Tracing Render Pipeline",
            "For rendering Complex SDF Scenes with Proxy Meshes",
            "images/spheretracing/PlanetDrawCalls.png",
            new List<BlogPage>()
            {
                new BlogPage(
                    "Introduction",
                    new List<Content>()
                    {
                        new HeaderContent("What is a Sphere-Traced SDF?"),
                        new TextContent(ParagraphData.SphereTraceBlogP1_0),
                        new VideoContent("videos/spheretracing/SphereTraceShowcase.mp4", "Stylized Smooth-Min SDF Spheres"),
                        new TextContent(ParagraphData.SphereTraceBlogP1_1),
                        new HeaderContent("Why would you Sphere-Trace SDF’s?"),
                        new TextContent(ParagraphData.SphereTraceBlogP1_2),
                        new TextContent(ParagraphData.SphereTraceBlogP1_3),
                        new HeaderContent("Expected Knowledge"),
                        new TextContent(ParagraphData.SphereTraceBlogP1_4),
                        new TextContent(ParagraphData.SphereTraceBlogP1_5)
                    }),
                new BlogPage(
                "The SDF Problem",
                new List<Content>()
                {
                    new HeaderContent("Complex Scenes & Raymarching"),
                    new TextContent(ParagraphData.SphereTraceBlogP2_0),
                    new TextContent(ParagraphData.SphereTraceBlogP2_1),
                    new HeaderContent("Fullscreen Sphere-Tracing & Rasterization"),
                    new TextContent(ParagraphData.SphereTraceBlogP2_2),
                    new TextContent(ParagraphData.SphereTraceBlogP2_3),
                    new HeaderContent("Pre-Passes & Complex Render Pipelines"),
                    new TextContent(ParagraphData.SphereTraceBlogP2_4),
                    new TextContent(ParagraphData.SphereTraceBlogP2_5)
                }),
                new BlogPage(
                    "Deferred Pipeline",
                    new List<Content>()
                    {
                        new HeaderContent("Render Pipeline Overview"),
                        new TextContent(ParagraphData.SphereTraceBlogP3_0),
                        new TextContent(ParagraphData.SphereTraceBlogP3_1),
                        new ImageContent("images/spheretracing/DeferredPipeline.png", "Deferred Pipeline Flowchart", false, 0.5f),
                        new TextContent(ParagraphData.SphereTraceBlogP3_2),
                        new TextContent(ParagraphData.SphereTraceBlogP3_3),
                        new TextContent(ParagraphData.SphereTraceBlogP3_4),
                        new CodeSnippetContent(CodeData.MaterialIndex, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP3_5),
                        new CodeSnippetContent(CodeData.NormalEncoding, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP3_6),
                        new HeaderContent("Deferred Shading"),
                        new TextContent(ParagraphData.SphereTraceBlogP3_7),
                        new CodeSnippetContent(CodeData.DeferredModule, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP3_8),
                        new CodeSnippetContent(CodeData.DeferredFragment, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP3_9),
                        new CodeSnippetContent(CodeData.DeferredBlit, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP3_10),
                        new TextContent(ParagraphData.SphereTraceBlogP3_11),
                        new ImageContent("images/spheretracing/DeferredAlbedo.png", "Deferred Albedo"),
                        new ImageContent("images/spheretracing/DeferredNormal.png", "Deferred Normal"),
                        new ImageContent("images/spheretracing/DeferredShaded.png", "Deferred Shaded"),
                    }),
                new BlogPage(
                    "Proxy Mesh Shader",
                    new List<Content>()
                    {
                        new HeaderContent("Proxy Mesh Advantages"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_0),
                        new TextContent(ParagraphData.SphereTraceBlogP4_1),
                        new ImageContent("images/spheretracing/ProxyMesh.png", "Proxy Mesh Visualization", false),
                        new TextContent(ParagraphData.SphereTraceBlogP4_2),
                        new TextContent(ParagraphData.SphereTraceBlogP4_3),
                        new ImageContent("images/spheretracing/Intersection1.png", "Ray & Bounding Volume", false, 0.5f),
                        new TextContent(ParagraphData.SphereTraceBlogP4_4),
                        new ImageContent("images/spheretracing/Intersection2.png", "Ray - Box Intersection (tNear: entry point, tFar: exit point)", false, 0.5f),
                        new TextContent(ParagraphData.SphereTraceBlogP4_5),
                        new HeaderContent("Volume Intersection Methods"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_6),
                        new TextContent(ParagraphData.SphereTraceBlogP4_7),
                        new CodeSnippetContent(CodeData.SphereVolume, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_8),
                        new CodeSnippetContent(CodeData.EllipsoidVolume, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_9),
                        new CodeSnippetContent(CodeData.AABBVolume, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_10),
                        new CodeSnippetContent(CodeData.OBBVolume, "slang"),
                        new HeaderContent("Processing Sphere Tracing Results"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_11),
                        new TextContent(ParagraphData.SphereTraceBlogP4_12),
                        new TextContent(ParagraphData.SphereTraceBlogP4_13),
                        new CodeSnippetContent(CodeData.WorldToDepth, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_14),
                        new CodeSnippetContent(CodeData.SDFNormal, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_15),
                        new HeaderContent("Dynamic Face Culling"),
                        new TextContent(ParagraphData.SphereTraceBlogP4_16),
                        new TextContent(ParagraphData.SphereTraceBlogP4_17),
                        new TextContent(ParagraphData.SphereTraceBlogP4_18),
                        new TextContent(ParagraphData.SphereTraceBlogP4_19),
                        new ImageContent("images/spheretracing/VolumeFace1.png", "Camera facing Front Faces", false, 0.5f),
                        new TextContent(ParagraphData.SphereTraceBlogP4_20),
                        new ImageContent("images/spheretracing/VolumeFace2.png", "Camera facing Back Faces", false, 0.5f),
                    }),
                
                new BlogPage(
                    "Modular Sphere Tracing",
                    new List<Content>()
                    {
                        new HeaderContent("Sphere Tracing Abstractions"),
                        new TextContent(ParagraphData.SphereTraceBlogP5_0),
                        new CodeSnippetContent(CodeData.HLSLLayout, "hlsl"),
                        new TextContent(ParagraphData.SphereTraceBlogP5_1),
                        new CodeSnippetContent(CodeData.SDFLayout, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP5_2),
                        new CodeSnippetContent(CodeData.SphereTracingLoop, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP5_3),
                        new CodeSnippetContent(CodeData.BoundingVolumeLayout, "slang"),
                        new TextContent(ParagraphData.SphereTraceBlogP5_4),
                        new CodeSnippetContent(CodeData.RayAligner, "slang"),
                        new HeaderContent("Sphere Tracing Implementation"),
                        new TextContent(ParagraphData.SphereTraceBlogP5_5),
                        new CodeSnippetContent(CodeData.PlanetSDF, "slang"),
                        new ImageContent("images/spheretracing/PlanetDrawCalls.png", "Planet SDF Result with Proxy Mesh Outline"),
                        new TextContent(ParagraphData.SphereTraceBlogP5_6),
                        new TextContent(ParagraphData.SphereTraceBlogP5_7),
                        new CodeSnippetContent(CodeData.SphereTracingFragment, "slang")
                    }),
                
                new BlogPage(
                    "Results & Refinements",
                    new List<Content>()
                    {
                        new HeaderContent("Implementation Result"),
                        new TextContent(ParagraphData.SphereTraceBlogP6_0),
                        new ImageContent("images/spheretracing/ImplementationResult.png", "Watercolor Stylized Galaxy with Proxy Mesh SDF's"),
                        new TextContent(ParagraphData.SphereTraceBlogP6_1),
                        new HeaderContent("Future Refinements & Improvements"),
                        new TextContent(ParagraphData.SphereTraceBlogP6_2),
                        new TextContent(ParagraphData.SphereTraceBlogP6_3),
                        new TextContent(ParagraphData.SphereTraceBlogP6_4),
                    })
                })
    };

    public static Project GetProjectById(string id)
    {
        return Projects[id];
    }

    public static Blog GetBlogById(string id)
    {
        return Blogs[id];
    }
}