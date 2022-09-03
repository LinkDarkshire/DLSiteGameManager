# DLSiteGameManager

First of all its not my work just releasing it here to work better with it.

Original can be found here: https://ulmf.org/threads/dlsite-game-manager-0-3-3.6298/

The Mod is from here: https://ulmf.org/threads/dlsite-game-manager-0-3-3.6298/page-7#post-685603

The coded bases on the Version v.0.46 of the Mod with the fix for the new Tags and Categories of DLSite from here: 
https://ulmf.org/threads/dlsite-game-manager-0-3-3.6298/page-12#post-1187399

This mod contains some fixes, tweaks, additional functions, and also basic voice works support for Lux's DLSite Game Manager 0.3.3.

# General Functions

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

# Mod Changes

- Reworked logic for scanning folders when adding works - not only executables will be added, but also any non-empty folders with RJ code in name, and some additional file types, which can be specified in <Extensions> setting in Settings.xml (for now there are playlists, which will be handy when managing voice works). This will allow batch-adding of any types of DLSite works, not only games. Also replaced most instances of "game" word in UI with "work".
- Recompiled targeting .NET Framework 4.6.2 to enable long paths support (> 259 characters) for Windows 10 Anniversary Update (1607) and later.
- Tags are now pulled from english dlsite even when there are no english page instead of translating them (by 3-digit tag codes using english dlsite advanced search page as a reference).
- Added option to download tags from user reviews.
- /Announce/ tag will be added for announced works.
- Added "Auto Set Category From DLSite" option.
- Added "Rename/Organize by template" context menu command, "Renaming template" settings field and "Use \ to organize in folders (relative to Main Folder)" checkbox (see Instructions section for details). 
- Added "Update Path" context menu command for the cases when folder or file was renamed or moved. This function will try to find new path by searching RJ code in parent folder (to existing path) or main folder (if set in settings). Also it will search for eligible files (executables or playlists) in existing work's folder (see Instructions section for details).
- Added <FileManagerPath> and <FileManagerArgs> setting in Settings.xml to allow opening work's folder (via double-click or "Open Containing folder" context menu) in external file managers (e.g. Total Commander) instead of Explorer (see Instructions section for details).
- Works can now also be added by drag and dropping text file with RJ codes (all RJ codes will be read, other text will be ignored). Can be helpful to quickly check lists of works (such as pastebins or IRC listings).
- Added "Download info" context menu command to allow batch downloading info for already added works.
- Fixed Google Translate title, removed translating tags.
- Fixed "Failed to connect to DLsite" error when there are no sample images.
- Fixed not downloading no_img image for announce works without cover image.
- Fixed rare situation of images not downloading when there are cover with RE code but list image with RJ code.
- Increased padding between rows in main list.
- Made word-wrap and autosize for rows for tags in info window.
- Made separate "Look for RJCodes in folder paths" and "Look for RJCodes in file and folder names" settings.
- Made comments searchable.
- Ratings can now be changed directly in the Rating column in Details view.


Voice works support specific changes:
- Added option to download HVDB info for voice works (tags, CVs and english title).
- Added "Prefer HVDB English Title" option when there are different DLSite and HVDB english titles.
- Added "Filter CVs" option - as HVDB has in most cases both english and japanese names for CVs, but no means to distinguish them, I implemented simple filter - if number of japanese names for CVs is equal to number of english names, download only the english, else - download all.
- Added "Open HVDB Page" to context menu.
- If there are playlists (m3u, m3u8, pls, aimppl, aimppl4, cue) in work's folders, they will be added as work's path automatically during adding works, and can be played by double-clicking on work in program window.



# Instructions

- Adding works to manager:
	- For best results make sure that for DLSite works folder names contain RJ code (RE, VJ, BJ codes also count), and for non-DLSite works folder contain one executable or playlist file.
	- There are two preferred ways to add works:
		- Drag and drop individual work's or entire collection's folder(s) into program's window - this will add all works even if they are already in the list.
		- Use Action -> Add Games menu command - this will scan a specified folder and will add only works that are not already in the list. Specified folder will be set as Main folder.
	- Both ways any non-empty folders with RJ code in name will be added as DLSite works, also all executables and playlists will be added regardless of names. Additional file types can be specified in <Extensions> setting in Settings.xml. Files with specific words in name (such as config, unins, setup) can be excluded from the scan via <FilesToIgnore> setting in Settings.xml.
	- Path to any file in scanned folders must not exceed 259 characters if your OS is earlier then Windows 10 Anniversary Update (1607), or the scan will hang. Path lengths can be checked with this program for example https://github.com/deadlydog/PathLengthChecker
	- For Windows 10 Anniversary Update (1607) and later long paths support must be enabled, instruction can be found here for example: https://www.howtogeek.com/266621/how-to-make-windows-10-accept-file-paths-over-260-characters/

- Using "Rename/Organize by template" context menu command, "Renaming template" settings field and "Use \ for folders (relative to Main Folder)" checkbox:
	- Renaming template may contain {rjcode}, {title}, {circle}, {category}, {cvs} tags, which will be replaced with corresponding values during renaming, also {foldername} tag can be used, which will be replaced with current work's folder name. At least {rjcode} or {foldername} tag must be present.
	- Example template: {rjcode} [{circle}] {title}
	- When "Use \ to organize in folders (relative to Main Folder)" checkbox is checked, backslash can be used to specify folder structure relative to Main Folder. {rjcode} tag must be in the part of the template after last backslash. Example: {category}\{circle}\[{rjcode}] {title}
	- If unchecked or Main Folder is not set or work's folder is outside of Main Folder, only part of the template after last backslash will be used for renaming.
	- Works without RJ code will be ignored.
	- Path will be updated automatically. 
	- Be vary of long titles, as to not exceed 259 characters path length limit if not supported by OS.

- Using "Update Path" context menu command: 
	This function will try to find new path by searching RJ code in parent folder (to existing path) or main folder (if set in settings). Also it will search for eligible files (executables or playlists) in existing work's folder. Useful in following cases:
	- Work's folder was renamed.
	- Work's folder was moved to subfolder of current folder.
	- Work's folder was moved to main folder.
	- In work's folder playlist or exe file was created, renamed or deleted.
	
- Using <FileManagerPath> and <FileManagerArgs> setting in Settings.xml to allow opening work's folder (via double-click or "Open Containg folder" context menu) in external file managers (e.g. Total Commander) instead of Explorer:
	For Explorer (default):
		<FileManagerPath>explorer.exe</FileManagerPath>
		<FileManagerArgs>"{0}"</FileManagerArgs>
	For Total Commander (change path if needed):
		<FileManagerPath>c:\Program Files\Total Commander\TOTALCMD.EXE</FileManagerPath>
		<FileManagerArgs>/o /s /L="{0}"</FileManagerArgs>

- Compiling from source code:
	- Download Microsoft Visual Studio 2010 or later (I used free Microsoft Visual Studio Community 2017).
	- When installing, choose .NET desktop development and .NET Framework 4.6.2 development tools.
	- Open \GameManager.src\GameManager.sln in Visual Studio.
	- Press F5 to compile.
	- Compiled executable will be at \GameManager.src\GameManager\bin\Release\GameManager.exe. Move it to main folder.

# Changelog
Build 0.46.3
- Fixed reading of DLSite Tags and Categories
- Fixed Rename/Organize

Build 0.46
- Fixed Google Translate for titles.
- Fixed DLSite ratings.

Build 0.45
- Added app.manifest to support long paths on Windows 10 Creators Update and later.

Build 0.44
- Now all archives will be unpacked upon adding, regardless of containing exe file or not.

Build 0.43
- Added additional check for HVDB page for works with "Voiced" option.
- Small tweak to uncensor in Rename/Organize function.
- Fixed not downloading HVDB info for works with no japanese DLSite page.

Build 0.42
- Fixed tags downloading in english when "Japanese DLSite" option was enabled.

Build 0.41
- Fixed error when downloading info for works with no japanese DLSite page.
- Fixed cases of RJ code named txt files mistakenly being added as work path when work's folder or exe do not contain RJ code in name.

Build 0.40
- Ratings can now be changed directly in the Rating column in Details view.

Build 0.39
- Added {foldername} tag to renaming template, which will be replaced with current work's folder name.

Build 0.38
- Fixed rare situation of images not downloading when there are cover with RE code but list image with RJ code.
- Fixed error from build 0.35 in "Open Containg folder" context menu command.
- Fixed error when folder selected in "Add works" contains RJ code.
- Added <FilesToIgnore> setting in Settings.xml to allow excluding filenames with specific words (such as config, unins, setup) from the scan.
- Made separate "Look for RJCodes in folder paths" and "Look for RJCodes in file and folder names" settings.

Build 0.37
- Added "Download info" context menu command to allow batch downloading info for already added works.
- Added "Use \ for folders (relative to Main Folder)" checkbox to allow to specify folder structure relative to Main Folder.
- Made Comments searchable.
- Replaced most instances of "game" word in UI with "work".

Build 0.36
- Works can now also be added by drag and dropping text file with RJ codes (all RJ codes will be read, other text will be ignored).
- Added <Extensions> setting in Settings.xml to allow customizing which fyletypes would be added during folders scanning.
- Added option for filtering CVs.

Build 0.35
- Added <FileManagerPath> and <FileManagerArgs> setting in Settings.xml to allow opening work's folder (via "Open Containg folder" context menu command) in external file managers (e.g. Total Commander) instead of Explorer.
- Added check so AGTH or ChiiTrans will not try to run with non-exe files.
- Optimized code so the DLSite Advanced search page will be downloaded only once and not on every DLSite info downloading.
- Added filtering of CVs by language - if number of japanese names for CVs is equal to number of english names, return only the latter.
- Renamed "Game Folder" to "Main Folder" in Settings.
- Minor tweaks to rename function.
- Fixed adding files by drag and drop broken in 0.33.

Build 0.34
- Recompiled targeting .NET Framework 4.6.2 to enable long paths support (> 259 characters) for Windows 10 1607 and later.
- Fixed bug in "Update path" function.

Build 0.33
- Added "Prefer HVDB English Title" and "Auto Set Category From DLSite" options to Game Scanner which forgot to do in 0.30.
- Added "Rename work's folder by template" context menu command and "Renaming template" settings field. Renaming template must contain at least {rjcode} tag, and may contain {title}, {circle}, {cvs} tags, which will be replaced with corresponding values during renaming. Example template: {rjcode} [{circle}] {title}
- Autosize rows for title and path in GameEditControl.
- "Update Path" command now will search also for eligible files in existing work's folder.
- Fixed "Auto Move to Main Folder" option to work with folders.
- Fixed "Update Size" button to get size of the topmost folder with RJ code in name.

Build 0.32
- Fixed RPG Maker detection broken in 0.31.
- Added RPG Maker detection to "Download info" button.
- Added "Update Path" context menu and "/updatepathforall" searchbar command for the cases when folder or file was renamed or moved. This function will try to find new path by searching RJ code in parent folder (to existing path) or main folder (if set in settings).

Build 0.31
- Fixed error in downloading review tags when no main tags present on DLSite page.
- Fixed "Open HVDB Page" not working.
- Fixed incorrectly downloading CVs with @ symbol in name.
- Remove "N/A" and "n/a" from HVDB tags and CVs.
- Fixed grouping works with empty CVs field to Unknown group.
- Reworked searchbar commands code to use switch...case instead of if...else.
- Fixed using folder paths in GetDirectoryName statements.

Build 0.30
- Added "Prefer HVDB English Title" option.
- Added "Auto Set Category From DLSite" option.
- /Announce/ tag will be added for announced works.

Build 0.29
- Added padding between rows.
- Fixed incorrect size calculating for folders.
- Fixed getting incorrect titles with square brackets.
- Fixed no_img for announce works.

Build 0.28
- Fixed tags downloading bug when the tags are not listed in the dlsite advanced search page.

Build 0.27
- Automatically set category when downloading info.
- Enabled grouping by CVs.

Build 0.26
- Reworked logic for scanning folders for works - scan first for executables and playlists (m3u, m3u8, pls, aimppl, aimppl4, cue), then for any folder with rj code in name.

Build 0.25
- When double-click or run, if path is directory, open in explorer.

Build 0.24
- Automatically upgrade database file to new version (backwards compatible, but backup is advised).

Build 0.23
- Added "Open HVDB Page" to context menu.

Build 0.22
- Autosize rows for tags in GameEditControl.

Build 0.21
- Get HVDB English Title if English DLSite is unavailable.

Build 0.20
- Added separate DB entries and UI fields for HVDB tags and CVs.

Build 0.18
- Fixed Google Translate title, removed translating tags.

Build 0.17
- Added option to download HVDB tags and CVs for voice works to general tags string.

Build 0.15
- Added option to download tags from user reviews.

Build 0.07
- Fixed "Failed to connect to DLsite" error when there are no sample images.
- Tags are now pulled from english dlsite even when there are no english page instead of translating them (by 3-digit tag codes using english dlsite advanced search page as a reference).
