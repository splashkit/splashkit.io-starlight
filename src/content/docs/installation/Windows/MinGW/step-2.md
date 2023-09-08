---
title: Installing the SplashKit SDK
description: A guide on installing Splashkit SDK through pacman.
---
Once you have MSYS2 installed, you can install the SplashKit library:

## Steps:

1. Start by installing the **git** client. This will be used to download and update SplashKit. Run the following at the Terminal:

    ```bash
    pacman -S git --noconfirm --disable-download-timeout
    ```

1. In your MSYS2 Terminal, paste and run the following line

    ```bash
    bash <(curl -s https://raw.githubusercontent.com/splashkit/skm/master/install-scripts/skm-install.sh)
    ```

    This can also be found on the [SplashKit](http://www.splashkit.io) home page.

    ![](/gifs/windows/6.gif)

1. Restart the terminal and execute `skm` to test it was successfully installed.

    ```bash
    skm
    ```

    You should see the following messages:

    ```bash
    Splashkit is installed successfully!
    Missing skm command. For help use 'skm help'
    ```

    SplashKit supports a number of languages. Run `skm help` at the terminal to see the different commands you can run.



