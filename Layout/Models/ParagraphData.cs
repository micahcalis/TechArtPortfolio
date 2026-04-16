namespace TechArtPortfolio.Layout.Models;

public static class ParagraphData
{
    // vulkan
    public static readonly string VulkanP0 =
        "For my graduation, I want to make a stylized watercolor render pipeline. Working with Unity’s Scriptable Render-Pipeline has been great, but its high-level nature and invisible backend make it hard to optimize. For full control and to learn C++, I decided to try out Vulkan.";

    public static readonly string VulkanP1 =
        "After more than 10,000 lines of code and half as many headaches, I have a fully functioning render-pipeline (stylization excluded). Here is a showcase of 1000 unique entities with unique materials, rendered comfortably at ~1.0 ms (1000 fps) on an RTX 3080.";

    public static readonly string VulkanP2 =
        "The objects that are rendered are sphere-traced primitives. The only reason we can render this many, is because they are rendered with a proxy mesh: a cube that also serves as the bounding box of the ray. ";

    public static readonly string VulkanP3 =
        "Because sphere-tracing is expensive, it is important to minimize the amount of fragments that use this algorithm. This can be difficult when pipelines get complicated, as prepasses are required for many effects. Instead of rendering my proxy meshes multiple times, I have decided to use multiple render targets, as you would in a deferred shading pipeline. This way I can add targets for new effects, while having to sphere trace in only one pass. ";

    public static readonly string VulkanP4 =
        "Crucial for any render-pipeline is a decent Frame Graph. My approach is pretty standard, Topologically sorting a Directed Acyclic Graph that I build every frame. It automatically inserts barriers based on listed dependencies in the render passes, and has support for compute passes.";

    public static readonly string VulkanP5 = "Particle Tornado with Compute Shaders:";

    public static readonly string VulkanP6 =
        "Equally as important is Shader development tools. Things I’ve taken for granted, like Properties in ShaderLab and Shader Globals, I’ve had to develop systems for. Luckily, SPIR-V Reflect makes reflection pretty doable. ";

    public static readonly string PainterlyP0 =
        "For a project called ‘Midas’, I worked on a render-pipeline with two layers: a painterly stylized background, and a cel-shaded cartoon foreground. The concept was to bring an 2D animation film aesthetic into 3D, with a nostalgic Dutch environment. Looking at existing solutions for painterly rendering, such as the Anisotropic Kuwahara filter or Compute-Based Stroke Rendering, I wasn’t quite satisfied with either. I’ve come up with a solution that I dubbed Surface-Stable Voronoi Flooding.";

    public static readonly string PainterlyP1 =
        "The idea started when I implemented a Kuwahara filter, I noticed the pattern it creates was quite similar to Voronoi noise. After experimentation with Screen-Space Voronoi, 3D Voronoi and more, I was not able to create a satisfying noise pattern that remained stable. I took inspiration from a Runevision video, where he introduces a topic called Surface-Stable Fractal Dithering. While the dithering is not relevant, the fractal UV derivative technique is. Using the frequency to scale the noise, I gained the following effect.";

    public static readonly string PainterlyP2 =
        "Runevision solves the tiling issues by implementing an intricate dithering system, which isn’t applicable for this effect, since we are generating noise. Instead, we use two levels (and a smoothed interpolation) to blend noise values. ";

    public static readonly string PainterlyP3 =
        "For the ‘Flooding’ part, this is where the effect becomes painterly. Essentially, like shown before, we render the two Surface-Stable Voronoi buffers, without combining them. The RGB channels store the ID of the Voronoi cell, and the Alpha stores the distance to the center. Note that I’m not using regular Voronoi noise with a Euclidean distance, rather a Line SDF for stretchier cells.";

    public static readonly string PainterlyP4 =
        "For each buffer we do a set of Ping-Pong Blitting, N amount of times (N varies per buffer, I use 4 and 8). In these Blits, every pixel looks in a 3x3 at its neighbours, and finds the Screen-Space UV coordinates with the shortest SDF distance in its own cell. It then outputs these UV coordinates and the SDF distance. Note that these passes are rendered at half-resolution to make this effect scaleable.";

    public static readonly string PainterlyP5 =
        "After a few passes, most of the pixels will have found a better UV candidate, and the cells naturally converge towards the center of the SDF. This UV is then used to sample the opaque buffer, creating the following effect.";

    public static readonly string PainterlyP6 =
        "Finally, the two buffers are blended using the fractal method, to get rid of the seams. ";

    public static readonly string PainterlyP7 =
        "While this technique works especially well on a static camera, it does have flickering issues, noticeably around the edges of objects. One hypothesis I haven’t tested is using edge detection in the flooding algorithm, this could help prevent cell overflow.";

    public static readonly string OceanP0 =
        "For the open-world of a project called ‘Midas’, we needed an ocean as the environment is set on a Dutch Wadden island. In my previous attempts of making water shaders, I have used a ‘Sum of Sines’ approach and a ripple simulation, but both of these effects are quite limited in scalability. Oceans have complex waves that can’t be computed at runtime by naively stacking sine waves. With the use of the inverse Fast Fourier Transform, we essentially reverse engineer the output of a wave into a displacement map, by sampling a spectrum of frequencies.";

    public static readonly string OceanP1 =
        "The frequency spectrum can be seen as the base of the ocean. Generating a frequency spectrum is done using a spectrum model. One of the most common is the JONSWAP model, which fits extra well for this simulation, since it is based on data of the North Sea. I got the mathematical model from Garrett Gunnell’s ocean repository. The spectrums need to be generated once and are stored in a texture array (for multiple cascades).";

    public static readonly string OceanP2 =
        "One more resource required for an efficient inverse Fast Fourier Transform, is the so-called ‘Butterfly Texture’. This texture precomputes trigonometric weights and complex number multiplications that will help translating from the frequency to the spatial domain.";

    public static readonly string OceanP3 =
        "The actual runtime pipeline starts by calculating a continuous spectrum from the initial spectrum. This shifts the simulation over time. Because the FFT calculations act as a portal to the spatial domain, which is indifferent about its input, we calculate two continuous spectrums. One for the displacement of the waves, and one for the slopes, which will be used to get correct normals later. ";

    public static readonly string OceanP4 =
        "Now all that is left to do is convert the continuous spectrums to spatial domains with the inverse fast fourier transform. With a horizontal and a vertical pass, we can compute the spatial maps with realtime speeds. Additionally, we can use the slope map to compute the Jacobian of our waves, which computes where waves are ‘folding’ and accumulates foam on a separate target.\n";

    public static readonly string OceanP5 =
        "Now we can render the ocean in a vertex shader. For an efficient ocean mesh, I have a separate compute pass that does frustum culling and handles LOD’s, which then renders instanced planes. This pipeline is GPU-driven, taking advantage of rapid AABB frustum culling. ";

    public static readonly string OceanP6 =
        "Note that I have combined my water with a painterly pipeline, which requires additional techniques. From what I have tested, 4 cascades with non-uniformly scaling areas works best for a pattern that is practically unrepeatable.\n";

    public static readonly string VCTP0 =
        "Voxel Cone Tracing is a technique for rendering Global Illumination. In short, it uses a voxelized representation of a 3D scene to bounce lighting information, simulating light in a cone shape that gradually blurs scene data. I implemented this system in Unity.";

    public static readonly string VCTP1 =
        "As a heads up, my pipeline is heavily based on the techniques described by James McLaren in the GDC Talk: The Technology of The Tomorrow Children (2015). I believe it is the most notable implementation, because its visuals rely heavily on the global illumination (and it is somehow rendered on a PS4). The process starts with voxelization. This is done by projecting geometry orthographically on all three axes. The fragments to a dummy target can be discarded, but the shader writes to UAV-bound 3D Textures.";

    public static readonly string VCTP2 =
        "When writing to a texture like this, race conditions are pretty much unavoidable. So, we make use of GPU atomics, additively accumulating information which will be normalized in a pass afterwards. My implementation uses anisotropic voxels, meaning, directional data is preserved in the voxels. Additionally I also have cascades set up, so that the Global Illumination covers more area.";

    public static readonly string VCTP3 =
        "The next step is bouncing the light inside the voxel volumes. This is done by cone tracing in compute passes.";

    public static readonly string VCTP4 =
        "Afterwards, then we cone trace once more, this time in screen space. This is one of the heaviest steps of the lighting pipeline, therefore it is important to render this at half, or quarter resolution. For ambient occlusion and global illumination, we sample broad cones around the surface normal. For specular reflections, sampling a few narrow cones in the reflected direction of the view vector against the surface normal gave me the best results";

    public static readonly string VCTP5 =
        "The raw output of the cone tracing commonly suffers from artifacts, caused by the cube shape of a voxel. Because we rendered our buffer to a lower resolution, we can upscale it for a blurred result. On top of that, we apply depth-aware and temporal blur filters.";

    public static readonly string VCTP6 =
        "While this is a fully functioning implementation of voxel cone tracing, it remains unstable with a moving camera. Temporal blurring and upscaling are not enough to smooth the artifacts from moving cascades. My next step would be to add a stochastic jitter to the cones, in an attempt to improve the temporal blurring. I would also revise the cone tracing algorithm, blending between cascades to make them less visible. ";

    public static readonly string CloudsP0 =
        "Essential to an immersive open-world environment are realtime clouds. For a project ‘Midas’ I had a new chance to work on a cloud system, which uses volumetric raymarching, procedural noise and light approximations.";

    public static readonly string CloudsP1 =
        "My implementation is largely based on the talk given by Andrew Schneider: The Real-time Volumetric Cloudscapes of Horizon Zero Dawn (2017). It starts off by generating some 3D noise textures. We generate two sets: a shape set and a detail set. As the word ‘shape’ suggests, this noise set will determine the general shape of the cloud volume. ";

    public static readonly string CloudsP2 =
        "4 channels of the shape noise 3D texture are used to store different noise frequencies. The primary channel contains a combination of Perlin and Worley noise, made more detailed with Fractional Brownian Motion. The other 3 channels contain FBM Worley noise, at exponentially increasing sizes. The detail noise will be used to carve out smaller shapes, giving the cloud its texture. It uses 3 channels, in the same way the last 3 channels of the shape texture are determined. The shape noise has a resolution of 128x128x128, with 16 bit channels. The smaller detail noise (32x32x32), has the same FBM Worley noise pattern, just with a different seed and resolution. ";

    public static readonly string CloudsP3 =
        "To render the clouds we use volumetric raymarching, sampling the shape and detail noise along the ray’s path.";

    public static readonly string CloudsP4 =
        "To start, we traverse along the ray and sample the shape noise. We then apply a height gradient, which determines at what height the clouds form, as well as their thickness. The most expensive part of this loop is sampling the 3D textures, so we only sample the detail texture if our sampled density is above a threshold. ";

    public static readonly string CloudsP5 =
        "Additionally, I do a shorter raymarch towards the light source, this will build the volumetric color.";

    public static readonly string CloudsP6 =
        "The lighting uses a Henyey-Greenstein Phase function to approximate the scattering of the light in the clouds by water particles. This is important to the volumetric look. For remapping the density values, we use the Beer-Lambert Law, a simple exponential equation that approximates the physical opacity. ";

    public static readonly string CloudsP7 =
        "Additionally it is important to note that volumetric raymarching is expensive, it should not be done at full resolution and should have occlusion culling. My clouds are rendered at a quarter resolution, and are rendered by drawing a proxy mesh in the sky.";

    public static readonly string GrassP0 =
        "Moving grass is crucial for green environments to feel alive. Yet, grass is a common enemy of real-time rendering due to its varying levels of detail and complexity. Up close, grass needs to be highly detailed, yet far away it should be a coherent gradient. For my grass instancing implementation, I based it loosely on the techniques described by Eric Wohllaib: Procedural Grass in ‘Ghost of Tsushima’ (2021) . ";

    public static readonly string GrassP1 =
        "The first step is actually not specific to the grass, but quite important to making grass feel alive. I generate a wind texture that offsets the grass blades. The noise technique I am using is marble noise, where the marble shape creates natural ripples through the grass. The noise is inspired by Lode Vandevenne’s article: Texture Generation using Random Noise (2004). ";

    public static readonly string GrassP2 =
        "Before we can render the instanced grass, we need to create an instancing clipmap. I use a combination of multithreading and compute shaders to achieve this effect. To cull the grass planes in the clipmap, I’m Unity’s Burst Job system to multithread an AABB Frustum culling algorithm. Because I have the data of the planes on the CPU, I can calculate the exact amount of compute threads required to dispatch the grass instance generation pass.";

    public static readonly string GrassP3 =
        "For each LOD of my grass, I have a separate Append SSBO. I can use the count buffer to indirectly instance the grass blades, keeping draw calls at a minimum.";

    public static readonly string GrassP4 =
        "The missing piece with the grass system is how it knows where grass should be placed. We were working with Unity’s Terrain System, so we needed a tool that seamlessly blends with the terrain. Since we weren’t using the detail tool for anything else, I implemented a pipeline that converts Unity’s detail array to a texture, which is then sampled by instance generation pass. The heightmap of the terrain is used to determine the height of the grass blades. Using the detail layer came with the advantage of being able to use the painting tools already in Unity’s Terrain System to paint the grass. ";

    public static readonly string OutlinesP0 =
        "For a project called ‘Midas’, we separated the game into two styles. Inspired by 2D animation films, the background would be painterly and the foreground cel-shaded with outlines. Trying many techniques for outline rendering, they always presented their own issues. Using a hull-mesh is the easiest, but has extremely limited use cases due to its many clipping flaws and inconsistent line thickness. ";

    public static readonly string OutlinesP1 =
        "A screen-space solution is usually the next step. A Sobel operator creates easy outlines, but it creates badly aliased outlines. A Laplacian creates a better result, but is quite sensitive and often requires a large amount of samples for a nice result. The solution I’ve come to like the most was presented in a talk by Arthur Brussee: That's a wrap: a Manifold Garden Rendering Retrospective (2020). ";

    public static readonly string OutlinesP2 =
        "This technique doesn’t require a complex algorithm, rather it takes advantage of an already existing technique to solve anti-aliasing: Multisample Anti-Aliasing. It works by performing edge detection in sub-pixel space, therefore creating perfectly anti-aliased outlines at a pixel level. My implementation starts with a simple pre-pass writing to a custom buffer for the outline color. There are also pre-passes for the depth and normal buffers, which are importantly unresolved MSAA textures. 4 sub-samples is sufficient.";

    public static readonly string OutlinesP3 =
        "Before the actual edge-detection algorithm, we execute a fullscreen pass that creates a mask for the outlines, minimizing the amount of pixels that actually perform the MSAA edge-detection. Sampling an unresolved texture is not fast, especially if we’re performing 32 sub-samples per pixel (4 sub-samples times 8 neighbouring pixels). So, this is an important optimization.";

    public static readonly string OutlinesP4 =
        "The edge-detection pass accumulates all the calculations from the sub-samples and simply normalizes the result.";

    public static readonly string KarstP0 =
        "This was an interesting challenge where I had a short week to try my hand at simulating Karst, underground erosion. If you’re interested in more detail, I have a more thorough documentation:";

    public static readonly string KarstP1 =
        "The simulation is voxel-based, meaning that I have a 3D bounding box for the particles, stored in the form of a 3D texture. Every simulation cycle, the volume gets updated using compute passes. The result is rendered out with instanced cubes. There is a default view for all solid particles, then a ‘hologram’ view that renders the empty / liquid particles.";

    public static readonly string KarstP2 =
        "The process starts with filling the voxel volume with particles. I use Fractional Brownian Motion with Perlin noise to create some natural randomness in the layers. I have four types of materials: sand, clay, permeable limestone and non-permeable limestone. \n";

    public static readonly string KarstP3 =
        "Afterwards fractures are inserted in the permeable limestone. These fractures naturally occur in perpendicular directions. To create a natural looking solution, I decided to create two sets of lines in the horizontal and vertical direction, by thresholding one-dimensional Perlin noise. The result is then offset slightly once again with Fractional Brownian Motion Perlin noise, to create flowing distortions.";

    public static readonly string KarstP4 =
        "Next up, it is important that the sand particles respond to gravity. Since we are trying to recreate the dramatic effect of a sinkhole, we need a way of making particles fall on the GPU. I decided to implement a two pass system that uses the Margolus neighbourhood. The odd-even approach isolates voxel updates and prevents race-condition issues.";

    public static readonly string KarstP5 =
        "The other moving component is the water. It needs to flow through the fractures to chemically erode the limestone and dissolve the clay and sand. I based my approach largely on the paper: Real-Time Virtual Pipes Simulation and Modeling for Small-Scale Shallow Water (2018). It works by implementing a Flux buffer that calculates outflowing water by doing a simple pressure calculation. Afterwards, a compute pass resolves the Flux by summing all inflowing and outflowing liquid. ";

    public static readonly string KarstP6 =
        "With all the moving components ready, we are ready to erode the limestone. For my implementation and chemical erosion math, I looked at a paper by Kai Franke and Heinrich Müller: Procedural generation of 3D karst caves with speleothems (2021). ";

    public static readonly string TerrainP0 =
        "For a game called ‘Florum’, we designed a top-down and tile-based game, with a tile-based environment. We needed a tool to generate the terrain for said environment, for project scalability and flexibility. The terrain itself has a simple pattern, it uses a few layered Perlin noise textures to create a couple of distinct height differences.";

    public static readonly string TerrainP1 =
        "The water has a base of Fractional Brownian Motion Perlin noise, which then gets its river shape from isolating a contour line. This creates an edge-like effect which serves our river purposes well enough.";

    public static readonly string TerrainP2 =
        "In our game the player could not jump, so the player would need to walk up slopes. To detect where slopes would need to be placed, we first compute the partial derivatives of both axes and store them in a texture. Then another pass goes over this texture to remove corners from the slopes (where slopes form an L shape). ";

    public static readonly string TerrainP3 =
        "There are a few additional maps which are responsible for placing the vegetation and resources. The main resource in the game are crystals, and we wanted to evenly distribute clusters. So, the resource map is a voronoi noise buffer that stores the type of crystal using the ID of the voronoi cell. For the crystal cluster, it just thresholds the center of that cell.";

    public static readonly string TerrainP4 =
        "The vegetation map uses a thresholded Voronoi noise buffer, using the interior distance so that the shape of the cell is preserved. The remaining channels are used for vegetation variation.";

    public static readonly string TerrainP5 =
        "Since the terrain didn’t have to be created on runtime, I was able to create a mesh using the CPU. The mesh itself uses predefined meshes for the cubes and slopes. The entire terrain is divided into chunks, the size is balanced for draw calls and frustum culling. For each chunk a separate collider mesh is created that is a simplified version of the mesh. Additionally, a collider for the river edge is created so the player can’t fall in the water. Vegetation gets baked as a data, which is instantiated on game initialization.";
}