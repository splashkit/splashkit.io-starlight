---
title: install dotnet-sdk command not working
description: Issue with the `brew cask install dotnet-sdk` command not working on MacOS, and how to fix it.
sidebar:
  label: 2. Brew cask install
#  attrs:
#    class: apple
---

<h1> Issue : MacOS </h1>

### `brew cask install dotnet-sdk` command not working (or any issues installing Homebrew)

<br>

## Solution

The corrected command is:

```shell
brew install dotnet-sdk --cask
```

Or alternatively, you can download .NET 7.0 from the [Microsoft website](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) and click on the macOS installer link.

**Note**: Arm64 is used for M1 chips onwards, and x64 is used for Intel based chips.
