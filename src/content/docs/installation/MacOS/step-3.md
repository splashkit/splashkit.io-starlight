---
title: Install Visual Studio Code
sidebar:
  label: 3. Visual Studio Code
  # attrs:
  #   class: apple
---

Visual Studio Code, also commonly known as *VS Code* or just *Code*, is a powerful and versatile code editor that enables efficient coding, debugging, and collaboration for your SplashKit projects!

## Steps

1. Download `Visual Studio Code`, found at [code.visualstudio.com](https://code.visualstudio.com).

2. Install Visual Studio Code.

    ![Gif showing Visual Studio installation in Finder](/gifs/macos/vs-code-install.gif)

3. In Visual Studio Code you should install the following extensions:

    For C#:

    - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
    - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
    - [Intellicode for C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscodeintellicode-csharp)

    You can do this from the command line by executing:

    ```shell
    code --install-extension ms-dotnettools.csharp
    code --install-extension ms-dotnettools.csdevkit
    code --install-extension ms-dotnettools.vscodeintellicode-csharp
    ```

    For C++:

    - [C++ Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-vscode.cpptools-extension-pack)

    You can do this from the command line by executing:

    ```shell
    code --install-extension ms-vscode.cpptools-extension-pack
    ```
