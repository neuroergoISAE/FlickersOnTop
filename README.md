Flickers on top
=======================

Organization of the repo
---------------

There are two projects:

- Interface2App: the GUI to define the number and parameters of the flickers;
- VisualSimuli: implements the main program

How to use it
---------------

1. Change `filePath` in [line 24 of the file GraphicalInterface.cs](https://github.com/ludovicdmt/FlickersOnTop/blob/main/Interface2App/GraphicalInterface.cs#L24) to save the configuration file of the flickers in a suitable folder on your computer. For instance: `C:\\Users\\MyComputer\\Desktop\\test_file.txt`.

2. Change also accordingly [line 117 in file CPlay.cs](https://github.com/ludovicdmt/FlickersOnTop/blob/main/CPlay.cs#L117).

3. In the [main Program.cs](https://github.com/ludovicdmt/FlickersOnTop/blob/main/Program.cs) you can choose to either make an image of a chessboard flicker: with the `ImageFlicker` function or a regular rectangle flicker with `flexibleSin` function.  
⚠️ Warning: you have to copy `chessboard.bmp` file in FlickersOnTop folder and paste in in bin/debug folder to use `ImageFlicker` function.

4. Finally, set Startup project to VisualStimuli and compilte the program.


Dependencies
---------------

All files are coded in C# and runing in VisualStudio.  
Download VisualStudio 2022: <https://visualstudio.microsoft.com/vs/>  

Help
---------------

If you experience issues during installation and/or use of this program, you can post a new issue on the [GitHub issues webpage](https://github.com/ludovicdmt/FlickersOnTop/issues). We will reply to you as soon as possible and are very interested in to the improvement of this tool.  
