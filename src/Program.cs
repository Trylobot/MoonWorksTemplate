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
