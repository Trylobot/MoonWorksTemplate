using MoonWorks.Graphics;

namespace ProjectName.Graphics
{
    public class RenderPasses
    {
        public RenderPass ExampleRenderPass { get; }
        public RenderPasses(GraphicsDevice graphicsDevice)
        {
            var clearPassDescription = new ColorTargetDescription
            {
                Format = TextureFormat.R8G8B8A8,
                LoadOp = LoadOp.Clear,
                StoreOp = StoreOp.Store,
                MultisampleCount = SampleCount.One
            };

            ExampleRenderPass = new RenderPass(
                graphicsDevice,
                clearPassDescription
            );
        }
    }
}