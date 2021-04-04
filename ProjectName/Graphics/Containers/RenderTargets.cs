using MoonWorks.Graphics;

namespace ProjectName.Graphics
{
    public class RenderTargets
    {
        public RenderTarget ExampleRenderTarget { get; }

        public RenderTargets(
            GraphicsDevice graphicsDevice,
            uint renderDimensionsX,
            uint renderDimensionsY
        ) {
            ExampleRenderTarget = RenderTarget.CreateBackedRenderTarget(
                graphicsDevice,
                renderDimensionsX,
                renderDimensionsY,
                TextureFormat.R8G8B8A8,
                false
            );
        }
    }
}
