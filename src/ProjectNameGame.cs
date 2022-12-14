using MoonWorks.Graphics;
using MoonWorks;

namespace ProjectName
{
	class ProjectNameGame : Game
	{
		public ProjectNameGame(
			WindowCreateInfo windowCreateInfo,
			PresentMode presentMode,
			FramerateSettings framerateSettings,
			bool debugMode
		) : base(windowCreateInfo, presentMode, framerateSettings, 60, debugMode)
		{
			// Insert your game initialization logic here.
		}

		protected override void Update(System.TimeSpan dt)
		{
			// Insert your game update logic here.
		}

		protected override void Draw(double alpha)
		{
			// Replace this with your own drawing code.

			var commandBuffer = GraphicsDevice.AcquireCommandBuffer();
			var swapchainTexture = commandBuffer.AcquireSwapchainTexture(Window);

			commandBuffer.BeginRenderPass(
				new ColorAttachmentInfo(swapchainTexture, Color.CornflowerBlue)
			);

			commandBuffer.EndRenderPass();

			GraphicsDevice.Submit(commandBuffer);
		}

		protected override void Destroy()
		{

		}
	}
}
