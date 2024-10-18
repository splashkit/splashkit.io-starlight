---
title: Install Visual Studio Code
sidebar:
  label: 3. Visual Studio Code
#   attrs:
#     class: linux
---

Once you have the [built splashkit](/installation/linux/step-3/) you
can download and install Visual Studio Code to use as a source code editor.

## Steps

1. Download [Visual Studio Code](https://code.visualstudio.com/)

    ![Downloading Visual Studio Code for Ubuntu](/gifs/linux/download-vsc.gif)

2. Open up a terminal.

    ![Opening a terminal in Ubuntu](/gifs/linux/open-terminal.gif)

3. Install Visual Studio Code

    In the terminal window, change directory using the ```cd``` command to the
    directory where Visual Studio Code downloaded

    ```shell
    cd ~/Downloads
    ```

    Then, install the .deb package by copying and pasting the code below into
    your terminal and pressing enter.

    ```shell
    sudo dpkg -i code_1.*.deb
    ```

    ![Installing Visual Studio Code on Ubuntu](/gifs/linux/install-vsc.gif)

4. In Visual Studio Code you should install the following extensions:

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
