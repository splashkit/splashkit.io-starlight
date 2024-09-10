---
title: Install MSYS2 and Command Line Tools
sidebar:
  label: 1. MSYS2 and Command Line Tools
  attrs:
    class: windows
---

MSYS2 provide a unix terminal environment for Windows. We will need this to run the build commands to create our SplashKit programs.

## Install MSYS2/MINGW64 Terminal

1. Download the installer from the official MSYS2 website: [www.msys2.org](https://www.msys2.org/)

2. To install MSYS2, double-click the downloaded executable file, and follow the on-screen instructions.

    *It is strongly recommended that you use the default install path, but you can customise the other installation options as needed.*

    :::note[Which Terminal?]
    MSYS2 comes with a variety of terminal environments. The **MINGW64** terminal environment is recommended for 64-bit computers (MINGW32 for 32-bit) as it has been found to support the C# and C++ terminal commands you will use.

    Therefore, you should use the **MINGW64** (MSYS2 MINGW64) terminal, which you can find by searching "mingw64" in the Windows Start menu and selecting the **MSYS2 MINGW64** App.
    :::

    :::tip[Pin it!]
    To make it easier to open each time, you can pin your terminal to the Taskbar.

    - Open MINGW64 terminal.
    - Right-click on the blue MSYS2 App icon in the taskbar.
    - Select "Pin to taskbar".

    :::

## Install Command Line Tools

To install SplashKit, you will firstly need to install some command line tools using the `pacman` package manager.

1. Copy and paste the following command into your **MINGW64** terminal window to install the `git`, `clang`, `gcc` and `gdb` pacman packages:

    ```shell
    pacman -S git mingw-w64-x86_64-clang mingw-w64-x86_64-gcc mingw-w64-x86_64-gdb --noconfirm --disable-download-timeout
    ```

    :::caution[Paste commands into MINGW64 Terminal]
    Unfortunately, you won't be able to use `Ctrl` + `V` to paste.

    Instead, right-click anywhere in the terminal window and then select **Paste**.
    :::
