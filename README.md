# MoonWorksTemplate

Template and build tasks for developing a cross-platform multi-target .NET 6 MoonWorks project in VSCode.

The generated solution file will also work in regular Visual Studio.

NOTE: OSX is broken right now because I need to set up MoltenVK.

## Features

- Project boilerplate code
- VSCode build tasks
- VSCode debugger integration

## Requirements

- [Git](https://git-scm.com/) or [Git for Windows](https://gitforwindows.org/) on Windows
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Build Tools for Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) on Windows
- [Visual Studio Code](https://code.visualstudio.com/)
- [VSCode C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

## Installation

- Make sure you have Git Bash from Git for Windows if you are on Windows
- Download this repository
- Run `install.sh`
- Move the newly created project directory wherever you want
- On Windows, add `C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin` to your system environment PATH variable after installing Build Tools for VS 2019

## Usage

- Open the project directory in VSCode
- Press Ctrl-Shift-B to open the build tasks menu
- Tasks use .NET 6.0 to build and run
- Press F5 to build and debug

## Acknowledgments

Thanks to Andrew Russell and Caleb Cornett's FNA templates for a starting point for this template.
