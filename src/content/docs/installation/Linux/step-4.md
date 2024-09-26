---
title: Install Language Specific Tools
sidebar:
  label: 4. Language Tools
  attrs:
    class: linux
---

SplashKit works with a number of programming languages. Each of these has its own set of tools you will need to install.

### For C# .NET

To install .NET for using C# with Splashkit, this will depend on your Linux distribution. You can find the instructions for all Linux distributions on the [.NET website](https://dotnet.microsoft.com/en-us/download?initial-os=linux).

- For Ubuntu, you can follow the instructions [here](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu).
- For Debian, you can follow the instructions [here](https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian).
- For Fedora, you can follow the instructions [here](https://learn.microsoft.com/en-us/dotnet/core/install/linux-fedora).
- For Arch, you will need to install the `dotnet-sdk` package from the AUR.
  - You can do this with:
    ```bash
    yay -S dotnet-sdk
    ```
  - You can also install the `dotnet-runtime` package if you only want to run .NET applications with the command:
    ```bash
    yay -S dotnet-runtime
    ```

### For C++

- For C++, you (should) _already_ be ready to go.

Guides for other supported languages like Python and Pascal are coming soon.

## What's next?

Congratulations! If you've followed these steps correctly, then you will have
installed all the tools needed to start programming with SplashKit!

It's time to get programming...
