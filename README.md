Flickers on top
=======================

Overview
------------------
FlickersOnTop is a program that allows users to use a graphical interface to create defined flickers or make flickering images. It would make the process of defining flickers become more suitable when these experiments are practiced in neuroegonomics's laboratory.

Organization of the repo
---------------

There are two projects:

- Interface2App: the GUI to define the number and parameters of the flickers.
- VisualSimuli: implements the main program.

How to use it
---------------

1. Change `filePath` in [line 88 of the file GraphicalInterface.cs](**private void bt_save** function )(https://github.com/ludovicdmt/FlickersOnTop/blob/main/Interface2App/GraphicalInterface.cs#L88) to save the configuration file of the flickers in a suitable folder **on your computer**. For instance: `C:\\Users\\MyComputer\\Desktop\\test2_file.txt`.
2. Change `filePath` in [line 243 of the file GraphicalInterface.cs](**private void btn_save_imediately_Click** function )(https://github.com/ludovicdmt/FlickersOnTop/blob/main/Interface2App/GraphicalInterface.cs#L88) to save the configuration file of the flickers in a suitable folder **on your computer**. For instance: `C:\\Users\\MyComputer\\Desktop\\test1_file.txt`.
3. Change `filePath` in [line 284 of the file GraphicalInterface.cs](**private void btn_image** function )(https://github.com/ludovicdmt/FlickersOnTop/blob/main/Interface2App/GraphicalInterface.cs#L284) to save the configuration file of the images in a suitable folder **on your computer**. For instance: `C:\\Users\\MyComputer\\Desktop\\image_file.txt`.

4. Change also accordingly [line 120 in file CPlay.cs](https://github.com/ludovicdmt/FlickersOnTop/blob/main/CPlay.cs#L120) to the same `filePath` with (1).
5. Change also accordingly [line 304 in file CPlay.cs](https://github.com/ludovicdmt/FlickersOnTop/blob/main/CPlay.cs#L304) to the same `filePath` with (3).

⚠️ Warning: the image must be in file bmp.For instance: `chessboard.bmp`.

6. Finally, set Startup project to `Interface2App` and compilte the program.


Dependencies
---------------

- All files are coded in C# and runing in VisualStudio.  
- Download VisualStudio 2022: <https://visualstudio.microsoft.com/vs/>  
- There are 2 application extension: `SDL2.dll`
                                   -`LSL.dll`
- For most cases, it will automatically be added to project when you do download. However, if you meet problem like [BadImageFormatException: An attempt was made to load a program with an incorrect format. (Exception from HRESULT: 0x8007000B)] when trying to complite program
You should make sure the two extentions are in x64 bits version and you can download them there:

 - https://www.libsdl.org/download-2.0.php
 - https://github.com/sccn/liblsl/releases

 
And then, you must go to project's properties -> Build -> change Platform target to `x64`.
![This is an image](https://user-images.githubusercontent.com/102971418/176470491-9454a7da-a7c8-4472-b526-578e37f3c928.png)

Help!

---------------

If you experience issues during installation and/or use of this program, you can post a new issue on the [GitHub issues webpage](https://github.com/ludovicdmt/FlickersOnTop/issues). We will reply to you as soon as possible and are very interested in to the improvement of this tool.  
