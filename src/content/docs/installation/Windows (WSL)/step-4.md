---
title: Install Language Specific Tools
description: Install the language specific tools for SplashKit on Windows (WSL).
sidebar:
  label: 4. Language Tools
  # attrs:
  #   class: windows
---

## Steps

SplashKit works with a number of programming languages. Each of these has its own set of tools you will need to install.
/installation/windows/mingw/

### For C# .NET

To install .NET for using C# with Splashkit head to the [.NET website](https://dotnet.microsoft.com/en-us/download?initial-os=linux) and follow the instructions for your Ubuntu distribution.

### For C++

For C++, you're _already_ ready to go.

### For Python

For Installing python3 run the following commands:

#### Installing python

```bash
sudo apt install python3
```

Optionally, you can also install `pip`:

```bash
sudo apt install python3-pip
```

#### Checking the version of python and pip installed

To check python version run:

```bash
python3 --version
```

To check pip version run:

```bash
pip3 --version
```

## What's next?

Congratulations! If you've followed these steps correctly, then you will have installed all the tools needed to start programming with SplashKit!
