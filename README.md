Flickers on top 🖥️
=======================
[![DOI](https://zenodo.org/badge/483661450.svg)](https://zenodo.org/badge/latestdoi/483661450)

Overview
------------------
✨ FlickersOnTop is a program written in C# that offers SSVEP and code-VEP (using m-sequence) flickers implementation trough a Graphical User Interface for Windows only 🪟.   
No need to code ! You define flickers and place them in the interface. The flickers can be displayed on top of any interface or with a black background for pyschopysics experiments. 🧑‍🔬  
It provides [Lab Streaming Layer (LSL)](https://github.com/sccn/labstreaminglayer) integration.

🧠 It was developped in the [Human-Factors department](https://personnel.isae-supaero.fr/neuroergonomie-et-facteurs-humains-dcas?lang=en) of ISAE-Supaero (France) by the team under the supervision of [Frédéric Dehais](https://personnel.isae-supaero.fr/frederic-dehais/). 

📚 You can cite our work using the DOI on top or in the [`CITATION.cff`](https://github.com/ludovicdmt/FlickersOnTop/blob/main/CITATION.cff) file. 

⚠️ This project is still under-development and this is a beta version. If you experience some issue/bug, you can share it with us in the [GitHub issues webpage](https://github.com/ludovicdmt/FlickersOnTop/issues) and we would be very happy to work on it ! It can also be used to suggest further improvements. 

![FlickerOnTop](https://user-images.githubusercontent.com/19227268/207640580-4b37e8f1-eb59-4719-b924-be0f3882d3e6.PNG)

Organization of the repo
---------------
🧑‍💻 The code is divided in two parts : 
* Interface2App: A GUI to design and place flickers. It creats an XML files that would be used as input for the second part.
* VisualSimuli: Use the XML file to create and animate flickers.

How to use it
---------------
✍️ Download the compiled version in the [Release](https://github.com/ludovicdmt/FlickersOnTop/releases) section and then click on `Interface2App.exe`. It will launch the GUI and allows you to create some flickers. You can set the color of the flicker (default to white), the amplitude depth of the flicker (default from 0 to 100%) and if you want a blackbackground or the flickers on top of the current interface. You can also load an image (as for now only in `BMP` format, you can find some [online converter](https://image.online-convert.com/fr/convertir-en-bmp)) to replace the rectangle by this image (a checkerboard for instance).

🏃 You can then click on `TEST` to make the flicker run for 30s. If you click on `RUN` it will run until you press `Escape`. One LSL marker per flicker (with the corresponding information) is send at the start to synchronize the EEG recording.     

💾 The configuration files of the flickers is saved automatically in `XML` format. You can used to inspect later your design or to load it in the GUI to run the same configuraton.


Dependencies
---------------
💻 If you want to build a new version instead of using the `.exe`, here are some hints: 
- All files are coded in C# and runing in VisualStudio.  
- Download VisualStudio 2022: <https://visualstudio.microsoft.com/vs/>  
- There are 2 application extension: 
    * `SDL2.dll`
    * `LSL.dll`
- For most cases, it will automatically be added to project when you do download. However, if you meet problem like [BadImageFormatException: An attempt was made to load a program with an incorrect format. (Exception from HRESULT: 0x8007000B)] when trying to complite program
You should make sure the two extentions are in x64 bits version and you can download them there:

 - https://www.libsdl.org/download-2.0.php
 - https://github.com/sccn/liblsl/releases

 
And then, you must go to project's properties -> Build -> change Platform target to `x64`.
![Select plateform](https://user-images.githubusercontent.com/102971418/176470491-9454a7da-a7c8-4472-b526-578e37f3c928.png)

🆘 Help
--------------

If you experience issues during installation and/or use of this program, you can post a new issue on the [GitHub issues webpage](https://github.com/ludovicdmt/FlickersOnTop/issues). We will reply to you as soon as possible and are very interested in to the improvement of this tool !  
