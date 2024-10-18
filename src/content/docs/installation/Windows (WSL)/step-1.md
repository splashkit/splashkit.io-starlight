---
title: Install WSL and Command Line Tools
sidebar:
  label: 1. WSL and Command Line Tools
  # attrs:
  #   class: windows-wsl
---

## Install WSL (Ubuntu)

Windows Subsystem for Linux (WSL) is a feature of Windows that allows you to run a Linux environment on your Windows machine, without the need for a separate virtual machine or dual booting.

### Method 1: Command Line (Recommended)

You can install both WSL and Ubuntu from the command-line using the following steps that have been adapted from the instructions provided in the official Microsoft documentation: [Install Windows Subsystem for Linux (WSL)](https://learn.microsoft.com/en-us/windows/wsl/install). This is the recommended method.

Open Terminal, PowerShell or Windows Command Prompt in *administrator mode* by right-clicking and selecting "Run as administrator", then copy and paste the following command to install WSL and Ubuntu:

```bash
wsl --install
```

![Gif showing WSL terminal running wsl --install commands](/gifs/windows/wsl-terminal.gif)

### Method 2: Microsoft Store (Alternative)

Alternatively, you can install WSL (and Ubuntu) directly from the Microsoft Store if you have this on your Windows computer.

To do this, search "WSL" in the Microsoft Store app (as shown below), or [click this link](https://apps.microsoft.com/store/detail/9P9TQF7MRM4R).

![Gif showing WSL being installed from Microsoft store](/gifs/windows/install-wsl.gif)

You will also need to download **Ubuntu** from the Microsoft Store. Search "Ubuntu" in the Microsoft Store app, or [click this link](https://apps.microsoft.com/store/detail/9PDXGNCFSCZV).

### Create Ubuntu User Account

Firstly, you need to **Restart** your computer if you haven't done so already.

A terminal window installing Ubuntu should pop up automatically, otherwise open the WSL or Ubuntu app for this window to open.

When prompted, enter your new UNIX username and password.  
For example, with the username "**default-user**", your terminal would look like this:

![Image showing WSL terminal with ubuntu user account set up](/images/installation/windows/terminal-ubuntu-user-account.png)

You can see in the image above where the "**default-user**" username was first entered (shown in the pink box), and the same username being used with the terminal prompt (shown in the orange box).

:::tip[Troubleshooting tip:]
If you have issues installing the WSL with Ubuntu, you can reset the installation using the following command:

```bash
wsl --unregister Ubuntu
```

Then run the installation command again:

```bash
wsl --install
```

And lastly, search for `Ubuntu` to open the Ubuntu terminal, which will allow you to create the user account, as mentioned above.
:::

WSL is now setup and ready to use!

### Configure 'Windows Terminal'

Note: This step is *optional*.

If you want to be able to have your 'Windows **Terminal**' app automatically open with WSL, you can change the *Default profile* to use WSL (with Ubuntu) using the steps below:

Firstly, open the Terminal app, and click the drop-down arrow at the top of the window (shown in the green box in the image below), then click on "Settings" (shown in the orange box):

![Image showing Terminal App with how to open settings](/images/installation/windows/windows-terminal-settings.png)

Next, click on the drop-down menu within the *Default profile* section and select either of the **Ubuntu** profiles. *If you're unsure, select the one with the Linux penguin icon* (shown in the pink box):

![Image showing Terminal App with how to change default profile in settings](/images/installation/windows/windows-terminal-default-profile.png)

Click **Save**. (Don't forget this!)

Now your Terminal app will automatically use the WSL/Ubuntu command line when you open it.

:::note
Don't worry if you have different profiles in your Settings, as long as you can see at least one profile that has "Ubuntu" in the name (if you are using the default setup).
:::

:::tip[Pin it!]
To make it easier to open each time, you can pin your Terminal to the Taskbar.

- Open the Terminal App.
- Right-click on the Terminal App icon in the taskbar (shown in the orange box in the image below).
- Select "Pin to taskbar" (shown in the pink box):

![Image showing Terminal App pinning to taskbar](/images/installation/windows/terminal-pin-taskbar.png)
:::

## Install Command Line Tools

To install SplashKit on WSL, you will firstly need to install the `git`, `curl`, and `clang` tools using the `apt` command, which works with Ubuntu's **A**dvanced **P**ackaging **T**ool.

Open your WSL Terminal. You can do this by using the Windows Terminal app if you followed the steps above, by searching for "WSL" in the Windows Start menu and then select the **WSL** App, or by using the app for the Linux distribution you installed, such as **Ubuntu**, which is installed by default.

Update the package lists by running the following command in your **WSL Terminal**:

```shell
sudo apt update
```

Next, install the `git`, `curl` and `clang` tools by running the following command:

```shell
sudo apt install git curl clang
```

![Gif showing command above being run in WSL Terminal](/gifs/windows/wsl-git-curl.gif)
