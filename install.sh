#!/bin/bash
# Author: Evan Hemsley
# Usage: ./install.sh

# This file is heavily borrowed from Caleb Cornett's template install script.

# Get the directory of this script
MY_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"

MOONWORKS_VERSION=0.1.0

readlinkf(){ perl -MCwd -e 'print Cwd::abs_path shift' "$1";}

# Checks if git is installed
function checkGit()
{
    git --version > /dev/null 2>&1
    if [ ! $? -eq 0 ]; then
        echo >&2 "ERROR: Git is not installed. Please install git to download MoonWorks."
        exit 1
    fi
}

# Pulls MoonWorks from github
function pullMoonWorks()
{
    checkGit
    cd lib
    git submodule add https://gitea.moonside.games/MoonsideGames/MoonWorks.git
    git checkout $MOONWORKS_VERSION
    cd ..
    echo "Updating to the latest release of MoonWorks..."
	git submodule update --init --recursive
	if [ $? -eq 0 ]; then
		echo "Finished updating!"
	else
		echo >&2 "ERROR: Unable to update."
		exit 1
	fi
}

# Downloads and extracts prepackaged archive of native libraries ("moonlibs")
function getLibs()
{
    # Downloading
    echo "Downloading latest moonlibs..."
    curl http://moonside.games/files/moonlibs.tar.bz2 > "$MY_DIR/moonlibs.tar.bz2"
    if [ $? -eq 0 ]; then
        echo "Finished downloading!"
    else
        >&2 echo "ERROR: Unable to download successfully."
        exit 1
    fi

    # Decompressing
    echo "Decompressing moonlibs..."
    mkdir -p "$MY_DIR"
    tar xjC "$MY_DIR" -f "$MY_DIR"/moonlibs.tar.bz2
    if [ $? -eq 0 ]; then
        echo "Finished decompressing!"
        echo ""
        rm "$MY_DIR"/moonlibs.tar.bz2
    else
        >&2 echo "ERROR: Unable to decompress successfully."
        exit 1
    fi
}

getLibs

read -p "Enter your project name or 'exit' to quit: " newProjectName
if [[ $newProjectName = 'exit' || -z "$newProjectName" ]]; then
    exit 1
fi

NEW_PROJECT_DIR="$MY_DIR/../$newProjectName"

if [ -d "$NEW_PROJECT_DIR" ]; then
  >&2 echo "ERROR: Directory already exists."
  exit 1
fi

# copy everything into new dir
cp -R "$MY_DIR" "$NEW_PROJECT_DIR"

cd "$NEW_PROJECT_DIR"
files=(ProjectName.Core.sln ProjectName.Framework.sln .gitignore ProjectName/ProjectName.Core.csproj ProjectName/ProjectName.Framework.csproj ProjectName/ProjectNameGame.cs ProjectName/Program.cs ProjectName/Graphics/GraphicsObjects.cs ProjectName/Graphics/Containers/Framebuffers.cs ProjectName/Graphics/Containers/RenderPasses.cs ProjectName/Graphics/Containers/RenderTargets.cs .vscode/tasks.json .vscode/launch.json)
for file in "${files[@]}"; do
    sed -i -e "s/ProjectName/$newProjectName/g" "./$file"
    if [ "$(uname)" == "Darwin" ]; then
        rm ./${file}-e
    fi
done

mv ./ProjectName.Core.sln "./$newProjectName.Core.sln"
mv ./ProjectName.Framework.sln "./$newProjectName.Framework.sln"
mv ./ProjectName/ProjectName.Core.csproj "./ProjectName/$newProjectName.Core.csproj"
mv ./ProjectName/ProjectName.Framework.csproj "./ProjectName/$newProjectName.Framework.csproj"
mv ./ProjectName/ProjectNameGame.cs ./ProjectName/${newProjectName}Game.cs
mv ./ProjectName "./$newProjectName"
rm ./install.sh
rm ./LICENSE

rm -rf .git
git init
git branch -m main
mkdir lib
pullMoonWorks

dotnet sln ${newProjectName}.Framework.sln add lib/MoonWorks/MoonWorks.csproj
dotnet sln ${newProjectName}.Core.sln add lib/MoonWorks/MoonWorks.csproj

echo "Project $newProjectName created at: "

if [ "$(uname)" == "Darwin" ]; then
    echo $(readlinkf $NEW_PROJECT_DIR)
else
    echo $(readlink -f $NEW_PROJECT_DIR)
fi
