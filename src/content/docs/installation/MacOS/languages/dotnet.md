---

title: Installing the .NET Core SDK on macOS
sidebar:
  hidden: true
  attrs:
    class: apple
---

For coding in C#, you will need to install the `.NET` SDK which will allow you to use the *dotnet* terminal command to create, build, and run your C# project code.

## Steps

1. Download the latest version of the .NET SDK for macOS from the official .NET website: [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

2. Run the downloaded installer and follow on-screen instructions.

3. In Visual Studio Code you should install the following extensions:

    - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
    - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
    - [Intellicode for C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscodeintellicode-csharp)
    - [C# XML Documentation Comments](https://marketplace.visualstudio.com/items?itemName=k--kato.docomment)
    - [vscode-icons](https://marketplace.visualstudio.com/items?itemName=vscode-icons-team.vscode-icons)

    You can do this from the command line by executing:

    ```shell
    code --install-extension ms-dotnettools.csharp
    code --install-extension ms-dotnettools.csdevkit
    code --install-extension ms-dotnettools.vscodeintellicode-csharp
    ```
