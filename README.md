# TyMemoryLeakManager
Visualise and act on the memory leak within Ty. Mainly for speedrunners.

## Getting Started
Unzip the folder and launch "Ty Memory Leak Manager.exe"

Next, launch Ty. TyMLM should immediately begin displaying the memory usage of Ty.

Now that the application knows where Ty.exe is in your filesystem, whenever Ty crashes or closes, it will immediately reopen.

Next time you start TyMLM, it will automatically open Ty for you.

To close Ty, first close TyMLM. Then you'll be able to cleanly exit Ty.

## Usage
The light green bar displays the current memory usage of Ty.

The total memory allowed for Ty is roughly 1550MB.

Upon selecting a category, a darker colored bar will appear.

This second bar shows the estimated memory leakage from a full run of the selected category.

Once starting a full run would cause a game crash before completion, a sound will chime and the bar will turn red.

Please note that memory usage fluctuates and can be unpredictable. It is also hard to account for the currently allocated memory which WILL be unloaded on level change.

For these reasons, only rely on the accuracy of the predictive bar when on the main menu and exercise caution using this app.

## Credits
Made by xMcacutt with code snippets pulled from Mul-Ty-Player written by xMcacutt and Tinsel
