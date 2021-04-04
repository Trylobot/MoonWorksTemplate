using System;
using System.IO;
using System.Runtime.InteropServices;
using MoonWorks;
using MoonWorks.Window;

namespace ProjectName
{
    class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetDllDirectory(string lpPathName);


        static void Main(string[] args)
        {
#if NETCOREAPP
            DllMap.Initialise(false);
#endif

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetDllDirectory(Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    Environment.Is64BitProcess ? "x64" : "x86"
                ));
            }

            WindowCreateInfo windowCreateInfo = new WindowCreateInfo
            {
                WindowWidth = 1280,
                WindowHeight = 720,
                WindowTitle = "ProjectName",
                ScreenMode = ScreenMode.Windowed
            };

            ProjectNameGame game = new ProjectNameGame(
                windowCreateInfo,
                MoonWorks.Graphics.PresentMode.FIFORelaxed,
                true
            );

            game.Run();
        }
    }
}