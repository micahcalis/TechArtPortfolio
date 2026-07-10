using System.Diagnostics.Contracts;

namespace TechArtPortfolio.Layout.Models;

public static class ParagraphData
{
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
        "Finally, the two buffers are blended using the fractal method, to get rid of the seams.";

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
        "Afterwards, then we cone trace once more, this time in screen space. This is one of the heaviest steps of the lighting pipeline, therefore it is important to render this at half or quarter resolution. For ambient occlusion and global illumination, we sample broad cones around the surface normal. For specular reflections, sampling a few narrow cones in the reflected direction of the view vector against the surface normal gave me the best results.";

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
        "Moving grass is crucial for green environments to feel alive. Yet, grass is a common enemy of real-time rendering due to its varying levels of detail and complexity. Up close, grass needs to be highly detailed, yet far away it should be a coherent gradient. For my grass instancing implementation, I based it loosely on the techniques described by Eric Wohllaib: Procedural Grass in ‘Ghost of Tsushima’ (2021).";

    public static readonly string GrassP1 =
        "The first step is actually not specific to the grass, but quite important to making grass feel alive. I generate a wind texture that offsets the grass blades. The noise technique I am using is marble noise, where the marble shape creates natural ripples through the grass. The noise is inspired by Lode Vandevenne’s article: Texture Generation using Random Noise (2004). ";

    public static readonly string GrassP2 =
        "Before we can render the instanced grass, we need to create an instancing clipmap. I use a combination of multithreading and compute shaders to achieve this effect. To cull the grass planes in the clipmap, I’m using Unity’s Burst Job system to multithread an AABB Frustum culling algorithm. Because I have the data of the planes on the CPU, I can calculate the exact amount of compute threads required to dispatch the grass instance generation pass.";

    public static readonly string GrassP3 =
        "For each LOD of my grass, I have a separate Append SSBO. I can use the count buffer to indirectly instance the grass blades, keeping draw calls at a minimum.";

    public static readonly string GrassP4 =
        "The missing piece with the grass system is how it knows where grass should be placed. We were working with Unity’s Terrain System, so we needed a tool that seamlessly blends with the terrain. Since we weren’t using the detail tool for anything else, I implemented a pipeline that converts Unity’s detail array to a texture, which is then sampled by instance generation pass. The heightmap of the terrain is used to determine the height of the grass blades. Using the detail layer came with the advantage of being able to use the painting tools already in Unity’s Terrain System to paint the grass. ";

    public static readonly string OutlinesP0 =
        "For a project called ‘Midas’, we separated the game into two styles. Inspired by 2D animation films, the background is painterly and the foreground cel-shaded with outlines. Having tried many techniques for outline rendering, they always presented their own issues. Using a hull-mesh is the easiest, but has extremely limited use cases due to its many clipping flaws and inconsistent line thickness. ";

    public static readonly string OutlinesP1 =
        "A screen-space solution is usually the next step. A Sobel operator creates easy outlines, but it creates badly aliased outlines. A Laplacian creates a better result, but is quite sensitive and often requires a large amount of samples for a nice result. The solution I’ve come to like the most was presented in a talk by Arthur Brussee: That's a wrap: a Manifold Garden Rendering Retrospective (2020). ";

    public static readonly string OutlinesP2 =
        "This technique doesn’t require a complex algorithm, rather it takes advantage of an already existing technique to solve anti-aliasing: Multisample Anti-Aliasing. It works by performing edge detection in sub-pixel space, therefore creating perfectly anti-aliased outlines at a pixel level. My implementation starts with a simple pre-pass writing to a custom buffer for the outline color. There are also pre-passes for the depth and normal buffers, which importantly are unresolved MSAA textures. 4 sub-samples is sufficient.";

    public static readonly string OutlinesP3 =
        "Before the actual edge-detection algorithm, we execute a fullscreen pass that creates a mask for the outlines, minimizing the amount of pixels that actually perform the MSAA edge-detection. Sampling an unresolved texture is not fast, especially if we’re performing 32 sub-samples per pixel (4 sub-samples times 8 neighbouring pixels). So, this is an important optimization.";

    public static readonly string OutlinesP4 =
        "The edge-detection pass accumulates all the calculations from the sub-samples and simply normalizes the result.";

    public static readonly string KarstP0 =
        "This was an interesting challenge where I had a short week to try my hand at simulating Karst, underground erosion. If you’re interested in a more detailed explanation, I have a more thorough documentation:";

    public static readonly string KarstP1 =
        "The simulation is voxel-based, meaning that I have a 3D bounding box for the particles, stored in the form of a 3D texture. Every simulation cycle, the volume gets updated using compute passes. The result is rendered out with instanced cubes. There is a default view for all solid particles, then a ‘hologram’ view that renders the empty / liquid particles.";

    public static readonly string KarstP2 =
        "The process starts with filling the voxel volume with particles. I use Fractional Brownian Motion with Perlin noise to create some natural randomness in the layers. I have four types of materials: sand, clay, permeable limestone and non-permeable limestone. \n";

    public static readonly string KarstP3 =
        "Afterwards fractures are inserted in the permeable limestone. These fractures naturally occur in perpendicular directions. To create a natural looking solution, I decided to create two sets of lines in the horizontal and vertical direction by thresholding one-dimensional Perlin noise. The result is then offset slightly once again with Fractional Brownian Motion Perlin noise, to create flowing distortions.";

    public static readonly string KarstP4 =
        "Next up, it is important that the sand particles respond to gravity. Since we are trying to recreate the dramatic effect of a sinkhole, we need a way of making particles fall on the GPU. I decided to implement a two pass system that uses the Margolus neighbourhood. The odd-even approach isolates voxel updates and prevents race-condition issues.";

    public static readonly string KarstP5 =
        "The other moving component is the water. It needs to flow through the fractures to chemically erode the limestone and dissolve the clay and sand. I based my approach largely on the paper: Real-Time Virtual Pipes Simulation and Modeling for Small-Scale Shallow Water (2018). It works by implementing a Flux buffer that calculates outflowing water by doing a simple pressure calculation. Afterwards, a compute pass resolves the Flux by summing all inflowing and outflowing liquid. ";

    public static readonly string KarstP6 =
        "With all the moving components ready, we are ready to erode the limestone. For my implementation and chemical erosion math, I looked at a paper by Kai Franke and Heinrich Müller: Procedural generation of 3D karst caves with speleothems (2021). ";

    public static readonly string TerrainP0 =
        "For a game called ‘Florum’, we designed a top-down and tile-based game with a tile-based environment. We needed a tool to generate the terrain for said environment, for project scalability and flexibility. The terrain itself has a simple pattern: it uses a few layered Perlin noise textures to create a couple of distinct height differences.";

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

    public static readonly string WaterColSimP1 =
        "This simulation was made for my graduation project, which is a watercolor themed sandbox game. Instead of a standard color picker, I had the idea to make a color picker where the user mixes watercolor pigments, just like you would with real watercolor.";

    public static readonly string WaterColorSim2 =
        "It is simulated on 512 x 512 pixels, on textures with 32 bit precision for each channel. It takes a lot of inspiration from the paper by C. J. Curtis, S. E. Anderson,  J. E. Seims, K.W. Fleischer,  D. H. Salesin: Computer-Generated Watercolor (1997). I turned their pipeline into a GPU-driven simulation that is very feasible for real-time purposes.";

    public static readonly string WaterColorSim3 =
        "There are two main challenges when making a watercolor pipeline. Firstly, because the paint is water-based, it should move, spread and settle on canvas like water would. The other challenge is pigment rendering, which simply can’t be computed in a single color space. The transmittance, thickness and concentration of the pigment needs to be taken into account. The simulation starts with a single channel buffer that holds the water, on which water can be injected.";

    public static readonly string WaterColorSim4 =
        "The pigments also have their own texture array buffers. Each pigment has its own channel. For my simulation, I chose to use the 12 pigments that were recommended by the aforementioned paper. After the water and pigment is injected into the buffers, the fluid simulation is computed in three passes, using the Virtual Pipes method.";

    public static readonly string WaterColorSim5 =
        "The first pass computes the flux on each pixel. Then before the water is moved, the pigment is resolved in the second pass, as it is reliant on the current water volume to accurately flow. After that, the water can safely be resolved.";

    public static readonly string WaterColorSim6 =
        "While a water simulation is important for the paint to flow, watercolor doesn’t stay fluid forever. In fact, it quickly evaporates and settles pigment into the canvas. The simulation solves this by having two separate layers that are used for the pigment rendering: the suspended and deposited buffer. The suspended buffer runs the fluid simulation and gradually transfers pigment into the deposited buffer.";

    public static readonly string WaterColorSim7 =
        "With the deposited and suspended buffer ready, we can render the pigments using the Kubelka-Munk method. The paper proposes individually computing each pigment, but I found accumulating the pigment properties and then calculating the Kubelka-Munk once is more efficient and still has great results.";

    public static readonly string SphereTraceBlogP1_0 =
        "Sphere-Tracing is a mathematically based render-method for accurately visualizing Signed Distance Fields (SDF’s). Compared to normal rasterization, sphere-tracing creates more natural looking shapes that can take advantage of mathematical properties, such as smooth blending and boolean operations. SDF’s work best by combining primitives with these functions, creating this kind of effect:";

    public static readonly string SphereTraceBlogP1_1 =
        "It is important to note that Sphere-Tracing is not the only way to render a SDF. Other methods include polygonization, where the SDF is baked (before runtime) or processed (during runtime) into a list of triangles, which mimics its shape. Naturally, this comes at the disadvantage of losing detail on the SDF up close to the generated mesh. The perfect detail that a runtime mathematical evaluation gives is in my opinion the main visual advantage of a SDF. My proposed method prioritizes the visual integrity of the SDF in complex scenes. Therefore, you should decide for yourself if this is appropriate to your use case.";

    public static readonly string SphereTraceBlogP1_2 =
        "Besides its visual clarity, there are other advantages to Sphere-Tracing SDF’s. Polygonal rasterization is built entirely on the premise that a triangle, along with a few descriptor sets, provides all the information necessary for a pixel to reach the intended color. While this works especially well for a simple Blinn-Phong, the disadvantage of this isolated approach becomes apparent when trying to create effects that require external information. Effects such as Sub-Surface Scattering or Ambient Occlusion are notoriously difficult, because a single triangle simply doesn’t contain information of the other triangles that it needs. As far as Triangle A knows, Triangle B could be completely off screen or not even exist.";

    public static readonly string SphereTraceBlogP1_3 =
        "Since a Signed-Distance field is an abstract mathematical representation of a shape, every thread on the GPU has full access to the data of the shape, theoretically with unlimited resolution. The shape can be treated like a 3D volume, instead of a 2D projection. As you might imagine, this makes physically based lighting effects much easier and natural to implement, as light naturally treats objects like 3D volumes. Another major advantage of SDF’s is their memory footprint. A mathematical equation needs far less data than a mesh with thousands of vertices.";

    public static readonly string SphereTraceBlogP1_4 =
        "As a heads up, this is not a copy-paste SDF Shader tutorial. This implementation is also not engine specific, I developed this in a custom Vulkan renderer. It is expected that you understand Sphere-Tracing, raymarching and SDF’s. Additionally, it is expected that you are familiar with low-level graphics API terminology, since the approach is not engine specific. Prior knowledge of deferred shading techniques is also useful. Most of the shader code that I will share is written with Slang, although everything can be translated to HLSL or GLSL.";

    public static readonly string SphereTraceBlogP1_5 =
        "Project Requirements:\n- Custom Render Passes\n- Support for Multiple Render Targets\n- Shader Reflection & Pipeline Cache\n";
    
    public static readonly string SphereTraceBlogP2_0 =
        "As Sphere-Tracing is a variation on a standard Ray-Marching algorithm, its approach is step-based. In code, this translates to a dynamic for-loop, which is notorious for creating lots of dynamic branches. While less notable on modern GPU’s, dynamic branches are a definitive weakness of GPU’s that slow down groups of threads.";

    public static readonly string SphereTraceBlogP2_1 =
        "Additionally to creating dynamic for-loops, the algorithm also suffers from linear complexity. Meaning, the number of shapes you give to the algorithm proportionally scales the amount of distance calculations made in the raymarcher: which is usually the most expensive part. Rendering a single primitive is quite inexpensive, but rendering hundreds of primitives will make your graphics card cry. Unfortunately most real-time environments require more than a hundred primitives to be rendered, which a naive fullscreen approach makes highly unpractical.";

    public static readonly string SphereTraceBlogP2_2 =
        "In rasterization, the main performance concern is the number of triangles, which makes sense since the complexity of the shape is made up of triangles. With a raymarching algorithm, the main performance impact comes from the fragment shader, or the amount of pixels that the algorithm covers.";

    public static readonly string SphereTraceBlogP2_3 =
        "A fullscreen approach starts to make less sense when this is considered, as this covers the maximum amount of pixels possible. A common optimization with volumetric raymarching is rendering to a target that is at half or quarter resolution of the screen. This works well with volumetrics, as they have smoothly distributed color information. However, the loss in quality is highly visible on opaque shapes with sharp edges. Therefore, a solution that minimizes the amount of fragments per primitive is desirable.";

    public static readonly string SphereTraceBlogP2_4 =
        "For now, we have only taken in consideration the context of just rendering a SDF to the screen. The reality of real-time render pipelines is that they often have a lot more steps. For example, pre-passes are a common solution for post-processing effects that require scene information. Motion Blur needs a pre-pass that stores the motion vectors of a pixel. Perhaps you are developing a stylized render pipeline and want cartoon outlines. Quite commonly, you will need depth and normal pre-passes.";

    public static readonly string SphereTraceBlogP2_5 =
        "GPUs are built for these types of rasterization render-pipelines, heavily optimized to draw as many triangles as possible. As a result pre-passes are generally quite inexpensive. However, as previously discussed, the bottleneck of Sphere-Tracing SDF’s is the pixel shader. Meaning, pre-passes would be an incredibly expensive technique for a naive raymarching implementation.";

    public static readonly string SphereTraceBlogP3_0 =
        "A standard forward rendering approach could be sufficient for simple rendering applications, but in my experience render-pipelines tend to require more flexibility. As discussed previously in ‘The SDF Problem’, we want to avoid doing multiple sphere-tracing passes as much as we can. Therefore, we can make the most of one fragment shader by using Multiple Render Targets (MRT). The primary disadvantage of using MRT is that it has a heavy impact on the memory bandwidth. Luckily, this is well balanced by the lack of mesh buffers that sphere-tracing needs.";

    public static readonly string SphereTraceBlogP3_1 =
        "To take maximum advantage of MRT, we will also be using a deferred shading pipeline, which allows for efficient rendering of complex lighting (such as point lights). Below is an overview of a minimalistic deferred render pipeline:";

    public static readonly string SphereTraceBlogP3_2 =
        "Buffer definitions:\n- GBuffer Albedo: contains the albedo color used to shade the geometry (RGB). The alpha channel contains a material index.\n- GBuffer Normal: contains the packed normal in the RG channels (world-space).\n- GBuffer Material: contains material data, can be in any order that you like depending on use case. Standard options: smoothness, metallic, ambient occlusion etc.\n- Depth Buffer: standard depth buffer for depth writing and testing.\n- Main Color: main color target of your render pipeline.\n";

    public static readonly string SphereTraceBlogP3_3 =
        "Note that this is a minimal setup and additional targets can be added for custom effects. For example, a common addition would be an emission target, with a RGB buffer that has HDR range. In this tutorial, I will only be tackling the ones listed above.";

    public static readonly string SphereTraceBlogP3_4 =
        "The ‘GBuffer Albedo’ is pretty self-explanatory, the albedo is generally derived from a base color with or without a texture sample. The material index in the Alpha channel separates different types of shading calculations. This could optionally be skipped if you are certain you will only use one type of material, but I recommend having at least a Lit and Unlit material. Just make sure to use integers that are simply packed into a 0-1 float:";

    public static readonly string SphereTraceBlogP3_5 =
        "‘GBuffer Normal’ could be done with a 3 component texture, but we can use a clever technique called Octahedronal Normal Encoding to pack the normal vector into two channels, saving some memory bandwidth. The technique is made possible due to a normal vector always having a length of 1. Meaning: if you have two components of the vector, only two possibilities would remain for the final value (positive and negative). This approach encodes the sign of that component into the two channels.";
    
    public static readonly string SphereTraceBlogP3_6 = 
        "‘GBuffer Material’ is also straightforward. It just contains parameters that describe the materials. For a standard BRDF it could contain: smoothness, metallic and ambient occlusion. These can be acquired from scalar properties or texture samples.";

    public static readonly string SphereTraceBlogP3_7 =
        "When using deferred shading, make sure to create separate shader modules or includes that define the ‘truths’ for the pipeline. It can become a debugging hell if every shader has its own logic for writing to the GBuffers. Furthermore, it is especially time-consuming if you were to decide to change anything to the pipeline, as you would have to rewrite all the shaders. The example code below is written using Slang, if you don’t have that luxury: don’t worry, this can easily be converted to HLSL/GLSL. If you do have the option of Slang, I would definitely recommend using it. It is a newer shading language that has a lot of features, such as interfaces and modules that will come in handy later when ray marching.";

    public static readonly string SphereTraceBlogP3_8 =
        "An opaque shader can easily access this module to write to the GBuffers. Below is a minimal example of a simple fragment shader. Note that if you would want to include normal and/or ambient occlusion maps you would have to sample them here.";

    public static readonly string SphereTraceBlogP3_9 =
        "For the deferred shade pass we can simply read our material index, and do the shading calculations based on that index. To ignore any pixels that we didn’t write to in our opaque pass, we can use a trick that discards a pixel if our depth is at its maximum eye depth, or at the far plane. The pass itself is just a fullscreen Blit to the Main Color buffer.";

    public static readonly string SphereTraceBlogP3_10 =
        "Once you have the shading pipeline and the render passes setup, it is the perfect time to start on the proxy mesh sphere tracing. Note that you could do the proxy sphere tracing first in a forward pass, but it would require some wasted time refactoring when you decide to implement a more complicated render-pipeline.";

    public static readonly string SphereTraceBlogP3_11 =
        "For transparent geometry, there is no way to integrate them in a deferred shading pipeline as objects essentially share pixels. Therefore, transparents will be rendered in a standard forward pass where blending is enabled and objects are z-sorted beforehand. That being said, below is the result of the deferred shading pipeline on some asteroid SDF's:";

    public static readonly string SphereTraceBlogP4_0 =
        "Now for the proxy mesh shader, I will not be explaining how to write a sphere tracing algorithm, as there are plenty of resources on how to write such an algorithm and how it works. However, in the next section ‘Modular Sphere Tracing’ I will show an example of the algorithm.";

    public static readonly string SphereTraceBlogP4_1 =
        "There are a couple things that make sphere tracing with a proxy mesh more efficient. All of them are a result of defining the bounds for the object. Consider any SDF in world-space, if it has no bounds, there is no easy way to estimate all the pixels that it covers without sphere-tracing the object. So ironically, if we want to render SDF’s efficiently, we have to rasterize their bounds first. This way, we have a proper estimate of the amount of pixels the object covers. Below is a visualization of how this works.";

    public static readonly string SphereTraceBlogP4_2 =
        "The second advantage we can use is within the sphere tracing algorithm. Consider a ray, which is an object with an origin point, direction and length. If our goal is to minimize the amount of steps it takes during sphere-tracing, then that essentially means that on a ray hit, we want to reach the SDF as efficiently as possible and on miss we want to reach the length of the ray as quickly as possible. Compared to standard raymarching, sphere-tracing already does a great job at reducing the amount of steps, but with defined bounds we can take additional steps to optimize. Because we are not rendering within the entire camera frustum we can adjust the ray to only exist within the bounds.";

    public static readonly string SphereTraceBlogP4_3 =
        "Meaning, if there was a way to precompute the start position at the bounds and the max length of our ray, then we could considerably take down the steps taken, especially on ray misses. Naturally, there is a way: intersection methods. Consider this primitive box and a ray:";

    public static readonly string SphereTraceBlogP4_4 =
        "The only information we would need to move the ray within the bounds is the entry point and the exit point. Then our ray origin becomes the entry point, and the ray length becomes the distance between the exit and entry point.";

    public static readonly string SphereTraceBlogP4_5 =
        "In this blog, I will show you methods of calculating intersections with primitives: box, sphere and ellipsoid volumes. While there are more, I’ve found these are all you need for proxy meshes, as I recommend you render all proxy meshes with a cube mesh. It is the most efficient shape in terms of vertices, and our intersection algorithms make sure that most ray misses require a minimal amount of shader calculations.";

    public static readonly string SphereTraceBlogP4_6 =
        "First, the sphere. This is a versatile shape that is efficient, because it discards pixels inside the proxy volume that are not inside of the sphere. If your SDF is roughly spherical, I would recommend that you use this shape.";

    public static readonly string SphereTraceBlogP4_7 =
        "There are two different variations, the geometric and algebraic version. The geometric intersection is most efficient, but is limited because it can’t inherit a transform if the scale is non-uniform (which will turn it into an ellipsoid). So only use this if you are sure it stays that way.";

    public static readonly string SphereTraceBlogP4_8 =
        "If you’d rather have an ellipsoid, we can make use of the algebraic intersection method, which uses the quadratic formula instead of projecting vectors. Slower but more versatile.";

    public static readonly string SphereTraceBlogP4_9 =
        "For the cube primitive, the simplest version is using the slab intersection method with an Axis Aligned Bounding Box (AABB). Again this is the fast version for the primitive, and it is limited because it is axis aligned. Meaning, if you were to rotate the cube so that it does not align with your axes it breaks.";

    public static readonly string SphereTraceBlogP4_10 =
        "For an Oriented Bounding Box (OBB), we still use the slab method, but inversely apply the rotation to get our box and ray to the local orientation of the box, so that it is axis aligned again. Because we have scalar values that describe how far the ray must traverse along itself to reach an intersection (‘tNear’ & ‘tFar’), we can just apply this scalar to our world-space orientation.";

    public static readonly string SphereTraceBlogP4_11 =
        "With the math of the intersections out of the way, here is quick outline of the steps in the fragment shader:\n1. Define Bounding Volume\n2. Define Ray\n3. Align Ray with to Bounding Volume\n4. Define SDF\n5. Sphere-Trace SDF\n6. Process Sphere Trace result\n7. Fragment Output\n";

    public static readonly string SphereTraceBlogP4_12 =
        "What makes this technique so powerful, is that the steps are very modular: they apply to all proxy mesh opaques that you would need in the scene. With a proper setup, you only have to select a Bounding Volume and SDF, for which you can follow the same steps as every other sphere-tracing shader.";

    public static readonly string SphereTraceBlogP4_13 =
        "For writing to the GBuffer, there are a few peculiarities that are required in order for the proxy meshes to function properly. Firstly, we can’t use our rasterized mesh data for any of the outputs: we have to get the normals and the depth from our sphere-tracer. For the depth only a simple matrix multiplication is required. Note that if you use a non-linear depth, then you should pack it by hand here.";

    public static readonly string SphereTraceBlogP4_14 =
        "For normals there are various methods, some can be directly computed depending on the shape. I usually go for the standard brute-force method, that evaluates the signed distance at slightly offsetted points to approximate a normal (the ‘Evaluate’ function just evaluates the SDF).";

    public static readonly string SphereTraceBlogP4_15 =
        "It should speak for itself, but any pixels that did not reach your SDF in the sphere-tracing loop should be discarded.";

    public static readonly string SphereTraceBlogP4_16 =
        "Depending on your use case, implementing all of these steps with a sphere-tracing loop should get you a proper result. However, we can go one step further and think about camera intersections. What happens if the camera is inside the Bounding Volume, but outside the SDF?";

    public static readonly string SphereTraceBlogP4_17 =
        "Standard face culling would likely cull the back faces, making it obvious that SDF is rendered within a proxy mesh. Ideally, this would be completely unnoticeable. Therefore, we simply turn off culling of the faces, rendering both front & back. However, this creates another problem. If we are outside the proxy mesh, we sphere-trace twice per pixel due to overdraw, which is a significant performance hit.";

    public static readonly string SphereTraceBlogP4_18 =
        "Luckily we can get all the information we need to resolve this in our shader. We can define a bounding volume that exactly describes the shape of the mesh (not the SDF). And using shader semantics (for Slang and HLSL: SV_IsFrontFace) we can tell whether we are rendering the front face or the back face. Consider the two following scenarios:";

    public static readonly string SphereTraceBlogP4_19 =
        "If the camera is outside the bounding volume, then we only want to render the front faces. That means we can discard any back-face pixels.";

    public static readonly string SphereTraceBlogP4_20 =
        "If the camera is inside, then we apply the opposite logic. We only need the back faces, so we discard any front-facing fragments.";

    public static readonly string SphereTraceBlogP5_0 =
        "Almost equally as important as the correctness of the sphere tracing technique, is a modular implementation that allows for easy extensions and variations. If for every SDF you would have to redo the sphere-tracing loop, it becomes a very messy codebase. Imagine you decide to adjust one step in the loop, then for every implementation that you have that step needs to be changed. Ideally you want a system where you can just define your SDF, and have your pre-made shader functions handle the rest. While Slang makes this significantly easier and more readable than the options HLSL / GLSL have, it is possible to do a similar system with those languages. Here is an example of injecting macros in HLSL, by including a layout file that has abstract macros at the bottom of the implementation file:";

    public static readonly string SphereTraceBlogP5_1 =
        "With Slang, we can use modules, interfaces and generics, making our lives a lot easier and our code untangled. Let’s start off by defining our abstract objects for the sphere trace. Like the steps outlined earlier, we define a Bounding Volume through which we align a ray, so we can sphere trace on an SDF. The two useful abstractions we can make here are SDF and Bounding Volume. Let’s start with SDF, we just need a function to evaluate it and get the normal:";

    public static readonly string SphereTraceBlogP5_2 =
        "Slang provides support for overriding a defined function of an interface, kind of like a virtual function in C++ or C#. So, if there is a better implementation for the normal of your SDF, you can override it in the implementation. Note that I just return float here on SDF for simplicity, but it is common to add material values to the SDF output, so that a single SDF can have different colors. Using this interface we can make an incredibly readable sphere tracing loop.";

    public static readonly string SphereTraceBlogP5_3 =
        "Similarly for the Bounding Volume, we can create an interface that describes what the Bounding Volume should do. Like discussed in the ‘Proxy Mesh Shader’ section, we create a function that with the help of the face direction and camera position decides if the fragment should be drawn or not. We also need a function that aligns a ray to the volume and a function that checks if a position is inside the volume.";

    public static readonly string SphereTraceBlogP5_4 =
        "Now we just need an object that uses the bounding volume to align a ray to it. I decided to call mine ‘RayAligner’, but I am sure there are better names for it.";

    public static readonly string SphereTraceBlogP5_5 =
        "With all that setup, we only need to make two implementations of our interfaces. This is an SDF that I am using for my planets:";

    public static readonly string SphereTraceBlogP5_6 =
        "The bounding volume implementation of an OBB volume can be found in the ’Proxy Mesh Shader’ section.";

    public static readonly string SphereTraceBlogP5_7 =
        "After all these abstractions, our fragment shader becomes very condensed. Note that it is very important that the compiler knows at compile time what implementation of the interface it uses, otherwise it has to decide at runtime which is way slower. So use generics explicitly.";

    public static readonly string SphereTraceBlogP6_0 =
        "If you have implemented a deferred shading pipeline with your proxy mesh shaders, then the fun part begins! While you must keep in mind to use the multiple render targets as efficiently as possible (everything comes at a cost), it is up to you how to use those buffers for your render pipeline. I used this technique to stylize a watercolor galaxy, rendered entirely with raymarched objects:";

    public static readonly string SphereTraceBlogP6_1 =
        "For this technique to work, I use an additional buffer that contains the watercolor properties, which are used in the deferred shading pass for a lighting model based on the ‘Cangiante’ painting technique. The objects also write to a UV offset buffer, which distorts the edges to give it a painted look. The point is, be creative and experiment with what SDF’s and stylization techniques have to offer.";

    public static readonly string SphereTraceBlogP6_2 =
        "While this rendering setup is already quite versatile and efficient, this blog hasn’t explored implementation of lighting techniques. Generating traditional shadow maps would be undesirable, as the entire scene would have to be sphere-traced again from the light source perspective (and more times for multiple cascades).";

    public static readonly string SphereTraceBlogP6_3 =
        "While I haven’t looked into creating shadows myself, creating raymarched shadows seems like the most natural approach. Of course, since the objects are rendered as proxy meshes, you wouldn’t be able to raymarch directly with the current setup. A likely solution is SDF voxelization, packed in perhaps an octree, 3D textures with cascades or Sparse Volume textures.";

    public static readonly string SphereTraceBlogP6_4 =
        "Another improvement could be anti-aliasing, standard MSAA with Alpha to Coverage enabled could work, but might be inefficient for a MRT setup. Since we are sphere-tracing, using a temporal jitter to slightly offset rays seems like a more elegant solution.";

    public static readonly string WatercolorBlogP1_0 =
        "Watercolor is an artistic medium with a vast and ancient history. The fluidity of the water creates natural shapes and color blending, but also makes it difficult to control. In real-time rendering, watercolor has been researched but its practical applications are quite limited. Watercolor stylization is usually achieved through hand-painted sprites or textures, rather than being procedurally stylized. In this blog, I will explain how I achieved the following effect in my galaxy sandbox game: My Watercolor Galaxy:";

    public static readonly string WatercolorBlogP1_1 =
        "My method is heavily influenced by the paper S. E. Montesdeoca, H. S. Seah, H. M. Rall: Art-directed Watercolor Rendered Animation (2016).";

    public static readonly string WatercolorBlogP1_2 =
        "During my stylization research, I foresaw several challenges of real-time watercolor rendering for games. Most importantly, techniques like ‘Wet-on-wet’ which are characteristic to the watercolor medium, directly contradict a core principle of game design: readability. In a watercolor painting, using this technique makes the most of the water medium, and is often used to separate foreground and background. In games, losing such detail could be undesirable, as it might conceal information that the player needs. Therefore, if you want to implement this effect in your games, be mindful of whether it fits your game design.";

    public static readonly string WatercolorBlogP1_3 =
        "This effect is more complicated than a simple post-processing filter. It requires other render targets which ideally can be tuned per object material for artistic control. In my solution, I am using Multiple Render-Targets (MRT) to write to all of these buffers. Naturally, that also means I use Deferred Shading. However, if you prefer Forward Rendering it should be possible to use Pre-Passes instead, which neatly decouples the watercolor stylization from the base rendering and could lower the memory bandwidth. I am rendering with MRT because I have Sphere-Traced 3D objects, this makes fragment shaders quite expensive and Pre-Passes unsuitable.";

    public static readonly string WatercolorBlogP1_4 =
        "Since this effect is more complicated than a filter, it is expected that you understand how to use multiple buffers within a render pipeline and how to organize them. I made this effect in my own Vulkan Renderer, however this approach is not engine specific. That being said, this means that you should have sufficient knowledge on customizing the render pipeline in your engine of choice. All the shader code that I will be sharing is written in Slang, but everything can be translated to HLSL or GLSL quite easily.";

    public static readonly string WatercolorBlogP1_5 =
        "Project Requirements:\n- Custom Render Passes\n- Shader Reflection & Pipeline Cache\n";

    public static readonly string WatercolorBlogP2_0 =
        "Buffer definitions:\n- Main Color: main color target of your render pipeline.\n- Watercolor Control: contains material data for the watercolor processing pass.\n    - Red: Paper Distortion\n    - Green: Paper Granulation\n    - Blue: Color Bleed\n    - Alpha: Pigment Turbulence\n- Offset: contains 2D noise for Hand Tremor UV offset.\n- Depth Buffer: standard depth buffer for depth writing and testing.\n";
    
    public static readonly string WatercolorBlogP2_1 =
        "The watercolor control buffer will be the main container of our watercolor per-material properties. It is important to note that these properties have a lot of artistic control (hence the name). Since most of my objects are created procedurally, I opted to implement these properties with computational rules. However, like the paper ‘Art-directed Watercolor Rendered Animation’ suggests, you could implement this pipeline to be controlled by hand-painted vertex colors or textures.";

    public static readonly string WatercolorBlogP2_2 =
        "The red channel is reserved for Paper Distortion. This controls how much the paper texture affects the paint. In general, I found that this directly correlates to the wetness of the paint (0-1 range), since paint that is more viscous is more affected by the paper texture. This is the math I am using:";

    public static readonly string WatercolorBlogP2_3 =
        "The Paper Distortion will be directly used as a multiplier later, which is why I prefer to always have a base distortion of 0.5, as this is important to create a convincing canvas effect. The exponent simply creates an ease out curve.";

    public static readonly string WatercolorBlogP2_4 =
        "The green channel is used for Paper Granulation. Like the distortion multiplier, this value will have an effect on the paper texture that will be used in the processing pass. This corresponds to the pigment accumulation in the valleys of the paper texture. Generally, in lighter areas this becomes more visible. Because we don’t yet know the brightness of our pixel, I use a trick that approximates it by computing the dot product between the surface normal and the light direction. Additionally I offset the normal with FBM Perlin noise, using the Surface & Screen Stable Noise technique (SSSN). You can read more about this technique in the next section.";

    public static readonly string WatercolorBlogP2_5 =
        "The blue channel controls the Color Bleed. This is what determines the intensity of the Wet-on-wet stylization. For my purposes, I wanted the background to gain this effect. So, I created a threshold range for the Wet-on-wet to exist in. Using the ‘bleedMin’ and ‘bleedMax’, you can define the range yourself. Additionally, I use a light fresnel gradient, which works especially well on round objects, creating a natural bleed from the center of the object to its edge.";

    public static readonly string WatercolorBlogP2_6 =
        "The alpha channel is left for the Pigment Turbulence. If you are using forward rendering, you can leave this out and use it to directly compute the turbulence in the shading model. Either way, I am using FBM Perlin noise, sampled with the SSSN technique. This will help in creating texture on the flat colors, recreating the natural inconsistencies in pigment concentration on a watercolor painting.";

    public static readonly string WatercolorBlogP2_7 =
        "The Offset Buffer will be simulating the offset that a watercolor painting would have due to hand tremors and the fluidity of water. Because hand tremors are small, it is important that the noise has a moderately high frequency. Once again using the SSSN technique, I use FBM Perlin-Worley noise, where the Worley noise has a higher weight than the Perlin Noise.";

    public static readonly string WatercolorBlogP3_0 =
        "The main challenge of creating Surface & Screen Stable Noise (SSSN) is that the Surface and the Screen act like opposites in isolation. An example of surface stable noise would be an object using its UV coordinates to sample noise. As you can imagine, this results in the noise not being screen stable, as a far away object would have much higher frequency than an object that is close to the camera. Make the noise screen-space, and now the noise doesn’t stick to the object, breaking the illusion of depth.";

    public static readonly string WatercolorBlogP3_1 =
        "What we need is a method to estimate the scale of the UV’s relative to the screen. Or more analytically, we need to determine the rate of change (frequency). In his video ‘Surface-Stable Fractal Dithering Explained’ (2025), Rune Skovbo Johansen proposes a method to calculate the minimum and maximum rate of change. I highly recommend watching his video if you want a better understanding of the math used here.";

    public static readonly string WatercolorBlogP3_2 =
        "In short, by using the native functions ‘ddx’ and ‘ddy’, we can get the raw rate of change of our UV’s. To keep the math visual. You can imagine the pixel as a perfect circle that is orthogonal to the surface normal. By projecting that circle onto the screen, we end up with an ellipse that is stretched.";

    public static readonly string WatercolorBlogP3_3 =
        "We are interested in the minimum and maximum amount that our ellipse is stretched, this will translate to the minimum and the maximum frequency of our UV’s. Our screen space derivatives (‘dx’ and ‘dy’) tell us the vectors of the shape. Then using linear algebra, we can calculate the lengths of the major and minor axes of the ellipse. This calculation can be simplified to using the quadratic equation, where finding its ‘roots’ (where the output = 0) evaluates the minimum and maximum frequencies.";

    public static readonly string WatercolorBlogP3_4 =
        "After finding the frequencies, we can find the ‘spacing’ of the noise. My implementation uses the minimum frequency, which I found to be closer to a practical scale for noise patterns. To get our fractal scale levels, we have to take a step back and review why we are doing this. In simple terms, we want our noise pattern to have roughly the same scale on different projections. Simply using the frequency as a scale will result in discontinuity on our pattern. So, we want the next best thing, which is rounding the frequency to the nearest power of two. This will create banding, which I will get to later. But, it does give us a divisor for our noise pattern that will keep the pattern relatively the same scale across the screen.";

    public static readonly string WatercolorBlogP3_5 =
        "With our Fractal Data, we can construct our Surface & Screen stable noise. As I said, we still have one remaining problem, which is the seams that a single level creates:";

    public static readonly string WatercolorBlogP3_6 =
        "To fix this, we make the observation that a seam occurs when the frequency is transitioning to a new power of two. So if we blend with this new value before we reach the seam, then we create a seamless pattern. This is why we kept two levels (N & N + 1). The ‘SubLayer’ value will be the interpolator for our blend. My implementation here is tuned for 3D noise, but an implementation for standard 2D will follow the same logic.";

    public static readonly string WatercolorBlogP3_7 =
        "For artistic control, you could pass the interpolator through easing functions. For example, if you find the blend to be too visible, you could try a function that eases in and out, making the transition not visible on most of the curve.";

    public static readonly string WatercolorBlogP3_8 =
        "Below are the full fractal data functions I used, for 2D and 3D:";

    public static readonly string WatercolorBlogP4_0 =
        "As mentioned in the ‘Introduction’ section, a lot of these techniques are translated from the paper S. E. Montesdeoca, H. S. Seah, H. M. Rall: Art-directed Watercolor Rendered Animation (2016). I will be referring to it as the Montesdeoca paper.";

    public static readonly string WatercolorBlogP4_1 =
        "Cangiante is a painting technique popularized during the Renaissance era, which enabled painters to preserve bright colors by shading with highlights. Instead of mixing dark colors like brown and black for shadows, artists would mix in bright colors like red and orange. This technique was often used on church murals, where the light color of the stone would compliment this style.";

    public static readonly string WatercolorBlogP4_2 =
        "As you could imagine, the same rules apply to watercolor. The translucency of the paint along with the natural blending of color compliments the Cangiante style. All this means that for a watercolor stylized lit model, we have to use a different approach than a standard PBR solution.";

    public static readonly string WatercolorBlogP4_3 =
        "The example above of the shading model is without any post-processing. As you can see the light side is quite bright. It mixes the base color with the color of the canvas and the color of the light. This balances the need for the color to blend with the canvas, whilst also keeping artistic light control. The shadow side remains a vibrant color, where the pigment turbulence also becomes more noticeable. The turbulence also offsets the light gradient, creating a more natural shape.";

    public static readonly string WatercolorBlogP4_4 =
        "The lit model takes the following parameters:";

    public static readonly string WatercolorBlogP4_5 =
        "The model itself is simple but effective. The base of the direct light gradient is a standard dot product between the light direction and the surface normal. It is controlled mainly by the Dilute Area parameter.";

    public static readonly string WatercolorBlogP4_6 =
        "The shading uses a ‘pigment’ color, which is essentially the gradient coloured with the albedo. The other color ‘base’ is a mix between the canvas color and the light color. This code, as well as the ‘GetArea’ function are modified versions of the Cangiate shading model proposed in the Montesdeoca paper.";

    public static readonly string WatercolorBlogP4_7 =
        "The most important parameters in this calculation are the ‘Cangiante’ and ‘Dilution’. ‘Dilution’ controls the general strength of the gradient. A low value will keep the gradient subtle, while a high value will show a strong contrast between the light and dark areas. The ‘Cangiante’ value controls the strength of the ‘base’ color.";

    public static readonly string WatercolorBlogP4_8 =
        "The parameters that are left are Light Color Intensity and Dark Intensity. Light Color Intensity (value 0-1) directly interpolates between the canvas and the light color. You can change this value, I would recommend setting it higher on scenes with little ambient light. Dark Intensity is responsible for deciding the minimum value the object must have. Without this the shading model quite easily reaches negative values, which is obviously undesirable.\n";

    public static readonly string WatercolorBlogP4_9 =
        "\nFinally, I’ve also added a simple specular highlight that mimics a bright blob of concentrated paint, with the color of the light. Depending on your stylization needs, you could decide to make this highlight white always. While the highlight looks unnatural on its own in the model, the post-processing distorts the shape. The size can be controlled with the Smoothness parameter.\n";

    public static readonly string WatercolorBlogP4_10 =
        "Just like normal watercolor paintings, our lit model has the issue of not easily displaying a contrast between hard and soft materials. A solution that I encountered when researching watercolor is scraping painted canvas to create sharp flakes of unpainted canvas.";

    public static readonly string WatercolorBlogP4_11 =
        "To achieve a similar effect, I am using the SSSN technique on FBM Voronoi noise with an exact distance. The exact distance will create the sharp edges that we need. I am using a tileable 3D volume, below is a function for generating such noise (I would highly recommend not calculating this on runtime). My implementation is based on the following article from Inigo Quilez:";

    public static readonly string WatercolorBlogP4_12 =
        "I simply threshold this noise and add a slight fade using a fresnel, as the noise looks best when the surface is facing the camera. The threshold is based on the ‘hardness’ property.";

    public static readonly string WatercolorBlogP5_0 =
        "As mentioned in the ‘Introduction’ section, a lot of these techniques are translated from the paper S. E. Montesdeoca, H. S. Seah, H. M. Rall: Art-directed Watercolor Rendered Animation (2016). I will be referring to it as the Montesdeoca paper.";

    public static readonly string WatercolorBlogP5_1 =
        "Because watercolor is such a thin medium, the texture of the canvas is quite visible. Valleys are often darker, because paint is naturally collected in those areas. When you paint a shape on a rough canvas, edges are slightly offset due to the texture. I believe these details are vital to creating convincing stylization.";

    public static readonly string WatercolorBlogP5_2 =
        "The first step is sampling the canvas texture. My implementation uses a screen-space overlay that is moved slightly when the user rotates the camera. This helps in decreasing the static feel of a standard overlay. This is my ‘DynamicCanvasUpdater’ class:";

    public static readonly string WatercolorBlogP5_3 =
        "The ‘_DynamicOffset’ property is simply used to offset the repeating texture. We will need the partial derivatives of the canvas texture for the UV offset. I recommend pre-calculating this, but it is certainly feasible to calculate them on runtime.";

    public static readonly string WatercolorBlogP5_4 =
        "With the partial derivatives, offsetting the screen UV’s becomes very simple. The strength of the effect is scaled by a general intensity value. Since the distortion is in UV space, I recommend keeping the intensity at a low value, mine is 0.02. The other scalar we get from our Watercolor Control buffer Red Channel. Keep in mind that the partial derivatives must be in a -1 to 1 range, otherwise your UV’s will shift objects towards the sign of your range.";

    public static readonly string WatercolorBlogP5_5 =
        "For the Paper Granulation I am using the Split-Model proposed by the Montesdeoca Paper, which preserves the vibrancy of a color whilst darkening it. This creates the illusion that paint is more concentrated at valleys of the paper texture. Like the UV offset, this effect has a general intensity scalar (my value = 0.25), but uses the Watercolor Control buffer Green Channel.";

    public static readonly string WatercolorBlogP5_6 =
        "As discussed in the ‘Render Pipeline’ section, the hand tremor offset is stored in the Offset buffer. We will use its Red Channel for the X offset, and the Green Channel for the Y offset. The direct output from the geometry passes could be used for this effect, but it will create outline artifacts around the edges of objects. Reason being, the noise is discontinuous between different object surfaces.";

    public static readonly string WatercolorBlogP5_7 =
        "Since the noise is only disconcontinuous around the edges of objects, we have two options: use a different noise sampling technique or standardize the noise around the edges. Since the SSSN technique does create a very stable result, I decided to go with the latter.";

    public static readonly string WatercolorBlogP5_8 =
        "My solution is a two-pass Edge-Aware Gaussian Blur. Because I was content with the effect of the noise (apart from the artifacts), the blur needs to preserve the noise on areas that are not prone to have artifacts. As is pretty standard in Edge-Detection algorithms, I compute the depth difference between the center pixel and neighbouring pixels. Then I can use this difference as weights in the blur.";

    public static readonly string WatercolorBlogP5_9 =
        "In the result below you can see that the noise looks very similar, except for a blurred ring around the edges, which resolves the outline artifacts of discontinuous noise. Since this is a blur on fullscreen resolution, I recommend minimizing the blur depth, to keep the fragments as cheap as possible. My blur depth is set to 5. \n";

    public static readonly string WatercolorBlogP5_10 =
        "For the actual offset implementation, there is again a base scalar, which I have set to 0.005.";

    public static readonly string WatercolorBlogP5_11 =
        "Quite commonly with watercolor paintings, the Wet-on-wet technique is used to abstract away backgrounds. Consider what the technique implies physically: it dilutes the pigments and mixes surrounding pigments. To simulate this in real-time, the solution of the Montesdeoca paper is quite elegant and simple. We apply a very heavy Gaussian Blur to a separate buffer, which naturally dilutes the color information. Then we interpolate towards the blurred buffer using our Color Bleed value, located in the Blue Channel of the Watercolor Control buffer.";

    public static readonly string WatercolorBlogP5_12 =
        "Remember to blur on half resolution, this will greatly increase performance. Because the buffer is blurred, upscaling it with linear interpolation will not give noticeable aliasing. I am using a blur depth of 21 and a spread of 20.0. Below is an implementation of a Gaussian blur.";

    public static readonly string WatercolorBlogP5_13 =
        "The last technique from the Montesdeoca paper cleverly uses the Gaussian blur again for a subtle Edge Darkening effect. The ‘Difference of Gaussians’ technique is an image enhancement technique that is commonly used for denoising, or even edge-detection.";

    public static readonly string WatercolorBlogP5_14 =
        "By subtracting the blurred buffer from the color, we are able to highlight edges slightly, which gives an Edge Darkening effect purely based on color information, indifferent to geometry.";

    public static readonly string WatercolorBlogP5_15 =
        "When implementing this watercolor post-processing pipeline, I noticed that the pipeline worked really well when the objects used the Cangiante Shading Model, but objects that did not (transparents, skybox etc.) would not have a convincing watercolor palette. Since I was rendering a galaxy, the black background remained black, uncharacteristic of watercolor.";

    public static readonly string WatercolorBlogP5_16 =
        "So, I added two Enhancement Filters that I feel give a great finishing touch to the post-processing pipeline. The first is actually a light Cangiante over the screen, weighted by the paper height. Similar to the Pigment Granulation calculations, it preserves the colors of paper valleys and lightens the color of hills.";

    public static readonly string WatercolorBlogP5_17 =
        "This worked well in softening dark colors and emphasizing the paper texture, but did slightly desaturate the entire image, which could be acceptable for a watercolor aesthetic. However, I prefer adding a vibrancy filter, which emphasizes already saturated colors, preserving the effect of Cangiante on dark colors whilst brightening more saturated values.";

    public static readonly string WatercolorBlogP6_0 =
        "Implementing a post-processing system like this is a lot of shader code, but does give you a pipeline that has a lot of artistic freedom and parameters to tweak, which is usually quite difficult in heavily stylized pipelines. Below are a few screenshots from my stylized galaxy, which renders lit, unlit and volumetric objects whilst keeping the stylization consistent. I recommend using bold colors and simplifying high-frequency detail, like you would with real watercolor. That is where the pipeline shines.";

    public static readonly string WatercolorBlogP6_1 =
        "Whilst I am quite happy with how this turned out for my project, stylization is an art, not a strict science. I recommend removing and adding elements to this pipeline for your specific use case and experiment with different effects.";

    public static readonly string WatercolorBlogP6_2 =
        "An effect that interests me but I haven’t found the time for, is adding bloom to the pipeline. Naturally, adding bloom after this post-processing will result in an incoherent effect, as it would be completely separate from the pipeline. Implementing custom bloom passes that give a stylized gradient before the post-processing is applied could result in an interesting effect.";

    public static readonly string WatercolorBlogP6_3 =
        "Furthermore, whilst the Edge-Aware blur is a viable solution, it is quite inefficient. I believe it is worth looking for a more efficient solution that resolves the relatively small artifacts resulting from the discontinuous noise.";

    public static readonly string VulkanEngineP0 =
        "Making a Vulkan Rendering Engine from scratch proved to be a significant challenge, but its low-level nature has given me a deeper understanding of real-time graphics. It has also allowed me to prioritize unique aesthetics and learning new techniques, whilst keeping a performant rendering application.";

    public static readonly string VulkanEngineP1 =
        "Since I had 20 weeks to complete a game within a not yet existing rendering engine, I knew I had to pick my battles. Because I wanted a stylized game with a custom render pipeline, I focused on Shader Development features, a Frame Graph & basic game engine functionality (Hierarchies, UI etc.).";

    public static readonly string VulkanEngineP2 =
        "Implementing a Frame Graph (with Vulkan’s Dynamic Rendering) allows me to create custom Render Passes, which are sorted based on their dependencies. I am using a standard approach for this, which is building a Directed Acyclic Graph and topologically sorting it. Additionally, I also have a pre-sort based on the ‘Render Event’, which is just an unsigned integer assigned to every pass. Below is an example render pass:";

    public static readonly string VulkanEngineP3 =
        "My hierarchy is an OOP approach that prioritizes efficient and selective rendering pipelines. My object nodes are located in a ‘Context’, and each ‘Context’ decides which render passes it needs to render. Like the ‘Context’, the nodes also decide how they should be rendered. For example, a player node has a few simple draw calls for the shape and the VFX. But, a galaxy node renders an entire galaxy in a few optimized draw calls, with custom instancing buffers.";

    public static readonly string VulkanEngineP4 =
        "The rendering commands are collected in a ‘DrawCallPool’, based on filters like Shader Pass and Context Type. This keeps the Render Passes abstract whilst prioritising shader flexibility.";

    public static readonly string VulkanEngineP5 =
        "Using the SpirV-Reflect library, I am able to reflect Descriptor Layouts automatically for my materials, which is extremely important for efficient shader development. Below is an example shader default lit shader written with Slang:";

    public static readonly string VulkanEngineP6 =
        "Materials, textures & shaders (graphics & compute) can all be loaded in with one-line commands. There is also support for creating procedural textures & meshes.";

    public static readonly string GalaxySDFP0 =
        "For my graduation project ‘My Watercolor Galaxy’ I rendered all of my 3D objects as Sphere-Traced Signed Distance Fields (SDF). The mathematical nature of SDF’s creates a unique aesthetic, where the round shapes are quite different from sharp polygons. But more importantly, it allowed me to easily create pseudo-random variety for all the galaxy objects, critical for a sandbox game.";

    public static readonly string GalaxySDFP1 =
        "Below is an example shader for the ‘Space Goo’, which I think showcases the advantages quite well:";

    public static readonly string GalaxySDFP2 =
        "If you want to know more about how I efficiently rendered large & complex scenes with Sphere Tracing, you can read more about it here:";

    public static readonly string GalaxySDFP3 =
        "Any galaxy needs planets and asteroids. The planet is just a sphere with a ring, simple to make with SDF’s. The asteroids are smooth-min spheres that have precomputed voronoi noise carved out of them.";

    public static readonly string GalaxySDFP4 =
        "Like the planets, the sun is also a SDF sphere. For my stylized black hole, I implemented an Accretion Disk SDF, which I think creates a very convincing shape.";

    public static readonly string GalaxySDFP5 =
        "Finally, the player is a UFO inspired largely by a ShaderToy shader made by user ‘Blackle’:";

    public static readonly string GalaxySDFP6 =
        "The base is made up of two smooth-min spheres and gets its texture from a radial gradient. The exhaust is a cube that is sliced diagonally with a plane. The alien is made of smooth-min spheres & lines.";

    public static readonly string WcStylizationP0 =
        "For my graduation project ‘My Watercolor Galaxy’, I worked on developing a stylized watercolor post-processing pipeline. In my research I could find very little practical applications of watercolor stylization in games. Most implementations tend to rely on stylized illustrations, but I wanted to create a procedural pipeline that would turn any render into watercolor.";

    public static readonly string WcStylizationP1 =
        "If you are interested a in-depth look at the post-processing pipeline, I wrote a blog about it:";

    public static readonly string WcStylizationP2 =
        "The shaded objects use a shading model based on the ‘Cangiante’ paint technique, preserving vibrant hues and mixing in the color of the canvas, simulating the translucency of watercolor.";

    public static readonly string WcStylizationP3 =
        "The effect also has layered UV offsets, for the canvas texture and hand tremors. Applying these offsets are important in making the geometry feel paint-like, distorting shapes and creating slight inconsistencies, simulating human error.";

    public static readonly string WcStylizationP4 =
        "The hand tremor buffer uses a technique I created called Surface & Screen Stable Noise, which lets 3D objects sample noise that remains a consistent Screen-Space size from any distance.";

    public static readonly string WcStylizationP5 =
        "Additionally to the hand tremor, objects write to a separate target called the ‘Watercolor Control’ buffer, which stores material properties for the post-processing.";

    public static readonly string WcStylizationP6 =
        "Using a separate blurred target on half resolution, an effect similar to the Wet-on-wet watercolor technique is created, applied to objects in the distance. The same target is also used for an Edge Darkening effect, using the Difference of Gaussians.";

    public static readonly string NebulaP0 =
        "For ‘My Watercolor Galaxy’, a galaxy sandbox game, I wanted the player to place colorful nebulas and have them fly through and interact with a real volume.";

    public static readonly string NebulaP1 =
        "In my previous volumetric rendering work, I have always worked with clouds that are high in the sky, which allows me to just draw them on the background of the scene. The problem with having volumetric objects is that they need to be sorted like transparents, but not rendered like them. To solve this problem, I created a small render-pipeline that uses Screen-Space Tile Partitioning, combined with Sphere Tracing & Volumetric Raymarching.";

    public static readonly string NebulaP2 =
        "First I divide the screen into 16x16 pixel tiles. Then in a compute shader I compute the Tile Partitioning with every volumetric object, assigning their indices to overlapping tiles.";

    public static readonly string NebulaP3 =
        "My ray-marching algorithm starts with a sphere-trace, tracing towards the bounds of the closest volumetric object (sphere SDF). When the ray reaches this SDF, it switches to volumetric raymarching, accumulating transmittance. While the culled tiles will help a lot with performance, I still do the raymarch on half-resolution.";

    public static readonly string NebulaP4 =
        "After the raymarch, I combine the half-resolution buffer with the main color target with a depth-aware upsample. This minimizes the artifacts around edges of opaque objects, created from the half-resolution blending.";

    public static readonly string NebulaP5 =
        "For the color of the nebulas, I decided to directly use the density value as a gradient, which gives an intriguing blend that matches the stylized aesthetic of watercolor.";
}
