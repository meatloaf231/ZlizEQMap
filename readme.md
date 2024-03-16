# ZLizEqMapLoaf

ZLizEqMapLoaf is a branch of ZLizEQMap, a map tool for use when playing on servers that emulate old versions of EverQuest. It features a local database of maps from the old EQAtlas website (now hosted on allakabor.com and tessmage.com), along with player positioning (x plotted on map), transparent overlay, waypoints, zone connections, and more.

Originally devloped by ZLiz http://www.zlizeq.com/ZlizEQ_Projects-ZlizEQMap

Adapted for TKAP by Baler

Main ZlizEQMap repo currently maintained by Cadsuane

ZLizEqMapLoaf maintained by Meatloaf231

### Main window layout update

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/8c8462f2-86a2-4803-9237-231b630e58e1)

1. Updated layout, map and legend info are now in a splitbox panel so they can be resized without rescaling the entire UI.
2. Options moved to right-hand side since there's a lot more options now, including the ability to arbitrarily zoom the map. All your waypoints and markers get scaled up or down automatically. 
3. New tab in options for advanced/debug tools, some things in here are not the most thoroughly tested and let you force certain behavior from the UI that may not be nice to use or pretty to look at. 
4. Notes feature added (more details in a later section)


---

### Popout map

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/6e0de7b6-236b-4aca-bf0b-4141a1b55fea)

- The popout map can be resized and positioned independently, and remembers where it was positioned, its width and height, and its opacity/AOT settings.
- Opacity/AOT setting visibility can be toggled using the gear icon in the top left. 
- Automatically syncs with the main UI map, including player position, waypoint, and notes.

The button to launch it is located here:

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/f7c457d2-3f56-40c3-ba15-9d4e451a9ff8)


Side-by-side with the main window: 

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/4b4bac79-d07e-4b74-a76c-5001f9f49722)

---

### Custom Notes
The notes feature allows users to save custom map markers. Notes are rendered on the map just like the player position and waypoint.

There's a setting in the options area to setting to toggle showing the notes on the map. This has three states, checked, unchecked, and partial. Unchecked, the notes will be hidden. Checked, the notes will show. Partial, the notes will show as circles at their coordinates with a corresponding number instead of their text.

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/1019ac42-62a9-49fd-b4df-c9229da3a3f1)

- The "set to player loc" button fills the new note coordinate input box with the known player coordinate values. If the "auto" box is checked, that will happen automatically any time a new player location is parsed from logs. 
- Font style and color can be customized, just for fun. 
- If the Auto-save notes checkbox is checked, it will save the notes to disk any time you add, remove, or edit any note. The notes collections can be saved manually using the Save Notes button.
- Notes are saved per map/submap, and use in-game coordinates instead of map image pixel coordinates. 
- The last column in the grid, titled DEL, contains a button that allows you to remove the notes.
- The notes are stored in a json file in the same directory as the settings .ini

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/faeacd56-6eff-44b3-8dea-5e5d6d839663)

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/0e9925e1-a97e-4b78-bdd0-3206d2bce51c)

---

### Location history tracking

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/2090bbb7-3b94-49d0-bf31-8baee2498769)

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/c224211c-533f-4efc-965c-ac782e1abecd)

Simple feature to track player location history, rendering it on the map as a line behind the player marker joining each previously recorded player coordinate point. Line slowly decreases in opacity as the points get "older".  If the location history box is unchecked, the history line won't be rendered on the map.

Stores a user-defined count of previous locations that the client has parsed, unique per application run - they're not saved anywhere on disk, so if you restart the application, it starts from scratch.

---

### Advanced options

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/f5c3d02a-c789-47fd-90f0-b24749da0f19)

- Player X and Player Y allow the user to overwrite the player coordinate values in the backend, as if those x/y values had been parsed from the log.
- Parse Timer controls how often the timer ticks and triggers a new check of the log values for new zones or player loc info. By default this is 1000 ms.
- Force map scale and the buttons below override the map scaling mode. Not very pretty or helpful but can be useful for debugging or troubleshooting so I left them in. 
- Launch Map Coord Tool opens the new map coordinate tool (see below)

---

### Map coordinate tool

![image](https://github.com/meatloaf231/ZlizEQMapLoaf/assets/2507658/66cdf254-a6a7-4b8d-be65-1ea99a12695d)

- Lets you mess around with image size, coordinate grid, and zero point values to help better match up in-game coordinates with image pixel values
- Grid density controls how frequently grid lines show up, and grid boundary multiplier just makes the grid up to five times larger for maps where the zero point is way off in the middle of nowhere.
- Yes I made this almost entirely to help fix the Neriak map scaling/coord values.
- Includes a blurb explaining a bit more about it because it's a weird little tool.

---

## Backend:

Optimized map image dimension check. Before, every time it needed to get the image height/width for the map coordinate -> map image pixel location conversion, it would reload the entire image from disk. Now it stores the map once it's loaded and just reloads it on zone switch instead of every single parse. 

Improved the settings loading so that it can endure a bad setting or two. Now if there's a bad setting that it can't parse or the file is corrupt or something, it reads as much as it can, sets the rest of the settings to default, and prompts the user if they'd like to make a backup file of the bad settings file as it is right now so they can go dig through it later.

Miscellaneous refactors of a ton of existing code. Pulled a lot of stuff out of the main form .cs file and moved it to services, added some utility methods, etc. Mostly cleanup and not functional changes, just reducing and "oh we don't need to do that every time, this should be in a separate method, not in the event handler", etc. 

The Settings and Help window contains a "use legacy UI" check that can be used to toggle back to the older layout and functionality but includes the bugfixes and some of the optimizations. It does require restarting the application to take effect.

---

# END OF FORK-SPECIFIC README, ORIGINAL README BELOW

okay cool



# ZlizEQMap


ZlizEQMap is a map tool mainly designed for servers that emulate old versions of EverQuest. It features a local database of maps from the old EQAtlas website (now hosted on allakabor.com and tessmage.com), along with player positioning (x plotted on map), transparent overlay, waypoints, zone connections, and more.

Original developer - Zliz http://www.zlizeq.com/ZlizEQ_Projects-ZlizEQMap

Adapted for TKAP by Baler

Updates and currently maintained by Cadsuane


## Build

Clone a build in IDE of your choice. 
If you run into build errors, removing the project from the solution and re-adding solved my issues.


## Features

- Complete EQAtlas map library for the old world, The Planes, Kunark, Velious and selected other zones (some maps slightly improved and edited)
- Player location on the map, marked with an 'x' when you perform a /loc in-game
- In addition to marking the player location, can show direction arrow (based on Sense Heading)
- Automatic zone switching as you zone in-game
- EQAtlas map legend (some slightly edited)
- Automatic detection of which character you're playing
- Multiple maps per zone, for example in dungeons with multiple floors
- List of clickable connected zones for each zone
- Waypoint functionality
- Adjustable transparency and always-on-top
- Server-agnostic; supports Project1999, The Al'Kabor Project, and can be extended to match any server
- Classic eqatlas.com look

## Screenshots

![Map](./Images/GeneralMapView.jpg)
General map view; player location marked by red arrow.

![Transparency](./Images//MapOverlayTransparency.jpg)
Displaying map overlay feature; adjustable window transparency.

## Requirements

Microsoft Windows
.NET Framework 4.0
Tested on Windows 7 64-bit.

## Installation and Running

Extract the contents of the .zip file to any directory you like
Run ZlizEQMap.exe
Running it for the first time, a form will pop up where you must input the path to your EverQuest directory. Second, choose a zone dataset that matches the server you want to play on. You must also choose whether the log files for your EQ install are found in the \Logs subdirectory or in the root EQ directory. For somewhat modern clients such as Titanium, often used by Project1999, choose the "\Logs directory" option. For The Al'Kabor Project (EQMac client), choose the "Root directory" option.

All of the options can be changed later.

Furthermore, you can click a button to enable logging permanently in EQ.

Click OK, and the map window will open, by default in East Commonlands.


## Usage
First, you must enable logging in EverQuest, if you haven't done it already upon the first run of the program. Open your EQ directory in a file explorer and find the file named "eqclient.ini". Open it in your favorite text editor, and look for a line starting with "Log=". If it says "Log=TRUE", logging is enabled. If it says "Log=FALSE", simply change it to "Log=TRUE". Save the file and exit your text editor. EQ will now automatically log everything you see in your chat window(s) to text files named after your character and server, for example "eqlog_Zliz_project1999.txt".

If the program hasn't switched zones already for you (it won't detect it on the very first load, and not always if you start it up after having started EQ - a design/performance compromise), choose the zone you're in in the combobox in the top right corner.

As soon as the slightest thing is added to your log file (anything in your chat windows for example), the program will pick it up and display the name of the active character in the program's title bar at the top.

Now type /loc in-game and your position will be updated within a second with a red 'x' on the map. It's a good idea to make a macro (social) with /loc in it, bound to an easily accessible hotkey.

You can furthermore make it show the direction you're facing. This is dependent on performing a successful Sense Heading within 1 second before you do the /loc. If your Sense Heading fails or is on cooldown, the normal 'x' will be shown. In order to best make this work, make a macro like this:
```
/doability 1
/loc
```
...where the "1" after /doability points to the position your Sense Heading skill is in on the 2x3 "Abilities" grid.
If you run "off the map" and perform a /loc, a red circle will be shown instead of an 'x' where your location was last plotted. You will see this if you run down the East Commonlands tunnel towards Northern Desert of Ro, as the map only contains the mouth of the tunnel where traders hang out. Another zone where this is prominent is Eastern Plains of Karana, where the very long gorge leading towards Highpass Hold is not drawn on the map.

More information can be found at [ZLiz's website here.](http://www.zlizeq.com/ZlizEQ_Projects-ZlizEQMap)

