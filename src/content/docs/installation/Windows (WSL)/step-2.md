---
title: Install SplashKit
sidebar:
  label: 2. SplashKit
#   attrs:
#     class: windows-wsl
---

Once you have WSL installed, you can install the SplashKit library:

## Steps

1. Open up a WSL/Ubuntu terminal.

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
