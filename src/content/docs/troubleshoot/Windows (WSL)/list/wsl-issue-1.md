---
title: Stack overflow Exception for GUI applications in WSL
description: Stack Overflow Exception when trying to open GUI application in WSL and how to resolve it.
sidebar:
  label: 1. Stack Overflow
  attrs:
    class: windows
---
<h1> Issue : WSL </h1>

### Stack Overflow Exception when trying to open GUI application in WSL

![skm install](/images/installation/wsl/stack-overflow-error-wsl.png)

## Solutions

To run Linux GUI Apps in WSL, you need to install the correct vGPU driver for your system. Here are the steps to resolve the stack overflow exception:

### Step 1

- Update your WSL with the command `wsl --update`, then restart your WSL by doing `wsl --shutdown` and then `wsl` to restart it.

### Step 2

- Find and install the correct vGPU driver for your system to run Linux GUI apps:

  - [Intel Graphics Driver](https://www.intel.com/content/www/us/en/download/19344/intel-graphics-windows-dch-drivers.html)
  - [AMD Graphics Driver](https://www.amd.com/en/support/download/drivers.html)
  - [NVIDIA Graphics Driver](https://www.nvidia.com/Download/index.aspx?lang=en-us)
