//From Author's Original Post https://ulmf.org/forum/hentai/hentai-games/9683-dlsite-game-manager-0-3-3

Hello, I have created a program that makes it easier to organize a massive collection of RPG Maker games. I originally created this program a long time ago to organize my own game collection and continued to develop it as a hobby. I now consider the program mostly finished and I hope that someone will find it as useful as I have.

Here are some images of the program in action: imgur.com/a/F6kcr

The program can currently:
Find RJCodes in file names, folder names and text files and use them to download game information and sample images from DLSite.
Attach AGTH (or Chiitrans) and Translation Aggregator to games when they are run.
Find the correct h-code for Wolf RPG games depending on its version.
Extract CG from encrypted RPG Maker and Wolf RPG archives.
Extract games from zip and rar-archives.
Translate Japanese title and tags.
Quickly find games matching a specific tag or RJCode.
Change the screen resolution while playing games (I like to lower my resolution when playing RPG Maker games to make the window appear larger).


Below is a detailed user manual. It's kind of long, but I recommend that you at least skim it because some of the things this program can do aren't very obvious.

Adding games
To add your existing collection of games to the game library, click add games in the action menu and select the folder where you keep your RPG Maker games as the scan folder and proceed. The program will create a list of all the .exe files in this folder. Go through this list and remove any entries that aren't actually games, such as uninstallers.

When you press "add", the program will connect to DLSite and download information and images for games whose RJCodes it was able to identify. This will probably take a while. Adding my collection of 170 games took 5 minutes. For games without an RJCode, you can manually add one later by selecting the game in the list, clicking "edit", entering a valid RJCode and clicking "download info".

Adding a single game
The easiest way to add a new game to your collection is to drag and drop an exe, zip or rar file into the program window. Archives will be unpacked to the "game folder" path specified in the settings menu. If the archive name or any file or folder names inside the archive contains an RJCode, information and images will be automatically downloaded before the game is added to the list.

When you add an executable file, the program will ask if it should move the folder that contains the file to your game folder. This behavior can be disabled in the settings menu. You can also drag and drop folders into the program window, which will add all executable files inside the folder to the list of games. Dragging and dropping multiple files, folders and archives of different types is supported.

Adding images
The thumbnails displayed in the upper right corner can be enlarged by mousing over them. To scroll to the next image, left click an image. To add a new image to a game, right click an image, or the empty space where an image should have been, and select "add new image". The image will be copied to the game's image folder. A game's "list image" is the image displayed to the left of the game's title in the list view and above the game's title in the tile view. To change a game's list image, right click a thumbnail. If you have a very high resolution monitor, all images will probably appear small. You can fix this in the settings menu.

Customizing the list
By default, the list of games is sorted and grouped by the non-visible "date added" column. Many columns are hidden by default and can be displayed by right clicking the column header. You can reorder columns by dragging them around in the column header and resize them by dragging the line between columns. To view the game collection as tiles instead of as a list, select "view" and "tiles" in the top left.

Some fields in the information panel to the right below the images are also hidden by default. To show them or hide others, right click the panel.

AGTH
To use AGTH and Translation Aggregator to translate games, set the AGTH and translator program paths in the settings menu to your "agth.exe" and "Translation Aggregator.exe" paths respectively. If you are using Chiitrans, set the AGTH path to your "chiitrans.exe" and leave the translator program path blank. To disable AGTH for a single game or change its AGTH parameters, right click a game in the list and select "properties". The parameters you choose here will override the default parameters.

CG extraction
To extract CG from an RPG Maker or Wolf RPG game, right click the game and select "Extract CG". You can also select a specific archive to extract by selecting "Action" and "Extract CG" in the top left. A program called arc_conv is used for extraction, so a lot more than RPG Maker archives can be extracted, for example .xp3 archives.

Searching
Press ctrl-F to display the search bar. You can search for titles, RJCodes, circle names, categories, ratings, languages and tags. When searching for multiple tags, use comma to seperate them. For example searching for "breast, sex" will display all games that have a tag containing "breast" and a tag containing "sex".

Screen resolution
To change the desktop resolution when running any game, select a resolution in the settings menu. To change the desktop resolution when running a specific game, right click the game and select properties. The desktop resolution will revert back to what is was before the game was ran when either the game or Game Manager exits, whichever comes first.

Ok, that pretty much covers it. Have fun organizing your games and let me know below if you have any questions or suggestions for improvement.



The program is a Windows Forms application created with C# .NET. The bulk of the UI is created with a slightly modified version of ObjectListView, a library for creating better lists in Windows.

To compile and run the code, open GameManager.sln in Microsoft Visual Studio 2010 or later and press F5 or choose "debug -> start debugging" in the context menu.

The source code is published under a copyleft license, which means that you are free to modify and share the program in any way that you wish, as long as you include your modified source code with your redistribution.