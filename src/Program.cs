using System;
using System.IO;
using System.Runtime.InteropServices;
using MoonWorks;

namespace ProjectName
{
	class Program
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetDllDirectory(string lpPathName);


		static void Main(string[] args)
		{
			WindowCreateInfo windowCreateInfo = new WindowCreateInfo
			{
				WindowWidth = 1280,
				WindowHeight = 720,
				WindowTitle = "ProjectName",
				ScreenMode = ScreenMode.Windowed
			};

			FramerateSettings framerateSettings = new FramerateSettings
			{
				Mode = FramerateMode.Uncapped,
				Cap = 60
			};

			ProjectNameGame game = new ProjectNameGame(
				windowCreateInfo,
				MoonWorks.Graphics.PresentMode.FIFORelaxed,
				framerateSettings,
				true
			);

			game.Run();
		}
	}
}
