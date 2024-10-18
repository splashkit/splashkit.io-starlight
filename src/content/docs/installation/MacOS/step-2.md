---
title: Install SplashKit
sidebar:
  label: 2. SplashKit
#   attrs:
#     class: apple
---

[SplashKit](https://splashkit.io) is a beginner's all-purpose software toolkit that will allow you to create fun and exciting programs more easily, especially for Graphical User Interface (GUI) programs.

## Steps

1. Copy the following code and paste and run it within the Terminal.

    ```shell
    bash <(curl -s https://raw.githubusercontent.com/splashkit/skm/master/install-scripts/skm-install.sh)
    ```

    This is the code from the [SplashKit Homepage](http://splashkit.io).

    ![Gif showing skm installing in Terminal](/gifs/macos/skm-install.gif)

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

3. *(Optional if on latest macOS version)*  
    Run the following command to install the necessary dependencies and compile splashkit.

    ```shell
    skm macos install
    ```

4. Run the following command to install splashkit globally:

    ```shell
    skm global install
    ```

    ![Gif showing skm installing globally in Terminal](/gifs/macos/skm-global-install.gif)
