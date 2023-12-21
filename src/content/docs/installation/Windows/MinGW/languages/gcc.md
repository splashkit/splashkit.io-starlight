---
title: Installing GCC on Windows
sidebar:
  hidden: true
  attrs:
    class: windows
---
GCC is essential for Windows users because it provides a powerful and reliable compiler for programming languages like C, C++, and more.
## Steps

1. Open an MSYS2 terminal
1. Run the following command:

    ```shell
    pacman --disable-download-timeout -S mingw-w64-{x86_64,i686}-gcc mingw-w64-{i686,x86_64}-gdb
    ```

    ![](/gifs/windows/install-gpp-msys.gif)

1. Run the compiler from either the **MSYS2 MinGW 64-bit** or **MSYS2 MinGW 32-bit** terminals

    ![](/gifs/windows/demo-compiler.gif)

1. In Visual Studio Code you should install the following extensions:

  - C++ (search for `ms-vscode.cpptools`)
  - vscode-icons (search for `vscode-icons`)

    ![](/gifs/windows/extensions.gif)


