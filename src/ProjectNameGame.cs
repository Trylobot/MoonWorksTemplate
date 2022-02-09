using MoonWorks.Graphics;
using MoonWorks.Window;
using MoonWorks;
using ProjectName.Graphics;

namespace ProjectName
{
    class ProjectNameGame : Game
    {
        private GraphicsObjects GraphicsObjects { get; }

        private int RenderWidth { get; }
        private int RenderHeight { get; }

        public ProjectNameGame(
            WindowCreateInfo windowCreateInfo,
            PresentMode presentMode,
            bool debugMode
        ) : base(windowCreateInfo, presentMode, 60, debugMode)
        {
            // Insert your game initialization logic here.
            GraphicsObjects = new GraphicsObjects(
                GraphicsDevice,
                windowCreateInfo.WindowWidth,
                windowCreateInfo.WindowHeight
            );
            RenderWidth = (int)windowCreateInfo.WindowWidth;
            RenderHeight = (int)windowCreateInfo.WindowHeight;
        }

        protected override void Update(System.TimeSpan dt)
        {
            // Insert your game update logic here.
        }

        protected override void Draw(System.TimeSpan dt, double alpha)
        {
            // Replace this with your own drawing code.

            var commandBuffer = GraphicsDevice.AcquireCommandBuffer();

            commandBuffer.BeginRenderPass(
                GraphicsObjects.RenderPasses.ExampleRenderPass,
                GraphicsObjects.Framebuffers.ExampleFramebuffer,
                new Rect
                {
                    X = 0,
                    Y = 0,
                    W = RenderWidth,
                    H = RenderHeight
                },
                Color.CornflowerBlue.ToVector4()
            );

			commandBuffer.EndRenderPass();

            commandBuffer.QueuePresent(
                GraphicsObjects.RenderTargets.ExampleRenderTarget.TextureSlice,
                Filter.Nearest,
				Window
            );

            GraphicsDevice.Submit(commandBuffer);
        }
    }
}
