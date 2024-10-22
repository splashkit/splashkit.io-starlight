---
title: Error while loading shared libraries, skm global install failed
description: Issue with the error `libSplashKit.so` not found when trying to run a SplashKit program on Linux, and how to fix it.
sidebar:
  label: 1. skm global install not working
#  attrs:
#    class: linux
---

<h1> Issue : Linux </h1>

### Error while trying to run `skm global install` command

![skm install](/images/installation/linux/skm-global-linux-fail.png)

## Solutions

If you're getting an error while trying to install Splashkit using `skm global install` command, it's likely your `bash` or `zsh` is unable to find the SplashKit library. You can manually add the library to your path.

### Updating your `~/.bashrc` profile

```bash
nano ~/.bashrc
```

Then add the following two lines near the end of the file:

```bash
export PATH="$PATH:$HOME/.splashkit:$PATH"
export LD_LIBRARY_PATH="$HOME/.splashkit/lib/linux:$LD_LIBRARY_PATH"
```

Then run the following command to update your profile:

```bash
source ~/.bashrc
```

### Updating your `~/.zshrc` file

```bash
nano ~/.zshrc
```

Then add the following two lines near the end of the file:

```bash
export PATH="$PATH:$HOME/.splashkit:$PATH"
export LD_LIBRARY_PATH="$HOME/.splashkit/lib/linux:$LD_LIBRARY_PATH"
```

Then run the following command to update your profile:

```bash
source ~/.zshrc
```
