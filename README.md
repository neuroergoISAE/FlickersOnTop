C#

Download VisualStudio 2022
https://visualstudio.microsoft.com/vs/


There are two projects : 
+ Interface2App - which includes th graphical interface that define the information of flickers 
+ VisualSimuli - which implements the main program


HOW DOES IT WORKS ?

+ First you run project Interface2App (in bar Startup Project) 
Attention: Because of this program will create a file in Desktop so you must look at line 25 file GraphicalInterface.cs to change filePath to your suitable folder.
```
Ex: C:\\Users\\Lenovo\\Desktop\\test_file.txt ==> C:\\Users\\Asus(name of your computer)\\Desktop\\test_file.txt
```
+ You do the same thing at line 116 in file CPlay.cs 

+ In order to run FLickering Image, just sample change flixibleSin function to ImageFlicker in Program.cs file 
Attention: you have to coppy chessboard.bmp file in FlickersOnTop folder and paste in in bin/debug folder.
+ Finally, change Startup project to VisualStimuli and run program.


P/s: An icon chessboard (Interface.lik) are already created in folder FlickerOnTop to help you easly open Interface2App without run it in VisualStudio.


All files are coded in C# and runing in VisualStudio 



