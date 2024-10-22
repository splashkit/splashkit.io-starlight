---
title: Error while loading shared libraries, skm global install failed
description: Issue with the error `libSplashKit.so` not found when trying to run a SplashKit program on Linux, and how to fix it.
sidebar:
  label: 2. libSplashKit.so not found
#  attrs:
#    class: linux
---

<h1> Issue : Linux </h1>

### `error while loading shared libraries: libSplashKit.so` not found when trying to run a SplashKit program

![skm install](/images/installation/linux/missing-library.png)

## Solutions

When you see the error `libSplashKit.so` not found, it's likely your `bash` or `zsh` is unable to find the SplashKit library. If you've recently updated or changed your `bash` or `zsh` profile, you may need to manually add the library to your path.

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
