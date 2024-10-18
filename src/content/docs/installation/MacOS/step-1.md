---
title: Install Xcode Command Line Tools
sidebar:
  label: 1. Command Line Tools
  # attrs:
  #   class: apple
---

The Command Line Tools provided by Xcode provide a large amount of developer
tools required to compile and develop applications.

## Steps

1. Open the _Terminal_ application.

    :::tip[How do I find the Terminal on my Mac?]

    1. Press _**Command**_ (⌘) + _**Space bar**_ to open the Spotlight Search.  
    2. Start typing "Terminal".  
    3. Click the **Terminal** app.

    :::

2. Copy the command below and paste it into your terminal and press enter.

    ```shell
    xcode-select --install
    ```

    ![Gif showing Spotlight Search to open Terminal and pasting Xcode install command](/gifs/macos/terminal-xcode-install.gif)

    **Note:** After running the command above, if you get something like this:

    ![A Terminal window showing message that 'Command Line Tools' are already installed](/images/installation/macos/xcode-install.png)

    That means you've already installed Xcode, and are ready to move to the next step!
