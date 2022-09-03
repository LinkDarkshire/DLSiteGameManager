This mod contains some fixes, tweaks, additional functions, and also basic voice works support for Lux's DLSite Game Manager 0.3.3.


General Changes:
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



Instructions:

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