---
title: Install SplashKit
sidebar:
  label: 2. SplashKit
#   attrs:
#     class: windows
---

Once you have MSYS2 installed, you can install the SplashKit library:

## Steps

1. In your MSYS2 Terminal, copy/paste and run the following line

    ```shell
    bash <(curl -s https://raw.githubusercontent.com/splashkit/skm/master/install-scripts/skm-install.sh)
    ```

    This can also be found on the [SplashKit](http://www.splashkit.io) home page.

    <!-- TODO: Add gif -->

2. Restart the terminal and execute `skm` to test it was successfully installed.

    ```shell
    skm
    ```

    You should see the following messages:

    ```shell
    SplashKit is installed successfully!
    Missing skm command. For help use 'skm help'
    ```

    SplashKit supports a number of languages. Run `skm help` at the terminal to see the different commands you can run.

3. Run the following command to install splashkit globally:

    ```shell
    skm global install
    ```
