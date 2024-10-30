---
title: Install SplashKit
sidebar:
  label: 2. SplashKit
#   attrs:
#     class: linux
---

Once you have installed the [Command Line Tools](/installation/linux/step-1/) you can install SplashKit and build the SplashKit library from its source.

## Steps

1. Open up a terminal.

    ![Opening a terminal](/gifs/linux/open-terminal.gif)

2. Install the SplashKit Manager by copy/pasting the command below into your terminal and press enter.

    ```shell
    bash <(curl -s https://raw.githubusercontent.com/splashkit/skm/master/install-scripts/skm-install.sh)
    ```

3. Restart the terminal and execute `skm` to test it was successfully installed.

    ```shell
    skm
    ```

    You should see the following messages:

    ```shell
    SplashKit is installed successfully!
    Missing skm command. For help use 'skm help'
    ```

4. Run the following command to install the necessary dependencies and compile splashkit.

    ```shell
    skm linux install
    ```

5. Run the following command to install splashkit globally.

    ```shell
    skm global install
    ```
