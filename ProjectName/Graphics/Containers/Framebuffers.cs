using MoonWorks.Graphics;

namespace ProjectName.Graphics
{
    public class Framebuffers
    {
        public Framebuffer ExampleFramebuffer { get; }

        public Framebuffers(
            GraphicsDevice graphicsDevice,
            RenderPasses renderPasses,
            RenderTargets renderTargets,
            uint renderDimensionsX,
            uint renderDimensionsY
        ) {
            ExampleFramebuffer = new Framebuffer(
                graphicsDevice,
                renderDimensionsX,
                renderDimensionsY,
                renderPasses.ExampleRenderPass,
                null,
                renderTargets.ExampleRenderTarget
            );
        }
    }
}