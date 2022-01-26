using MoonWorks.Graphics;

namespace ProjectName.Graphics
{
    public class GraphicsObjects
    {
        public RenderTargets RenderTargets { get; }
        public Framebuffers Framebuffers { get; }
        public RenderPasses RenderPasses { get; }

        public GraphicsObjects(
            GraphicsDevice graphicsDevice,
            uint renderDimensionsX,
            uint renderDimensionsY
        ) {
            RenderPasses = new RenderPasses(graphicsDevice);
            RenderTargets = new RenderTargets(
                graphicsDevice,
                renderDimensionsX,
                renderDimensionsY
            );
            Framebuffers = new Framebuffers(
                graphicsDevice,
                RenderPasses,
                RenderTargets,
                renderDimensionsX,
                renderDimensionsY
            );
        }
    }
}
