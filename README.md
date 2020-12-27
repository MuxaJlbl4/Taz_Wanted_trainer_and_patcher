# Taz Wanted Trainer & Patcher
![1](https://user-images.githubusercontent.com/20092823/103023795-a78a4b00-455f-11eb-8a0b-5cc30d4b49b1.png)  
![2](https://user-images.githubusercontent.com/20092823/103023800-a8bb7800-455f-11eb-8efa-32f29f1c434e.png)  

## **[🠗 Download 🠗](https://github.com/MuxaJlbl4/Taz_Wanted_trainer_and_patcher/releases/download/v2.0/Taz.Wanted.Trainer.Patcher.exe)**

## Requirements
- **Taz: Wanted PC Game** - Version 1.0
- **[Microsoft .NET Framework 4](https://www.microsoft.com/download/confirmation.aspx?id=17718)** - Already preinstalled on Windows 8/10
- **[d3d8to9](https://github.com/crosire/d3d8to9/releases)** - Put d3d8.dll to game folder (optional)

## Usage
### Trainer
While game is running, use keys to activate/deactivate cheats:
- **F1 - Invisibility** - Timeless test tube effect
- **F2 - Always burp** - Timeless super burp soda can effect
- **F3 - Super jump** - Hold jump to move up
- **F4 - Freeze timers** - Freezes all level timers
- **F5 - Debug menu** - Calls developers debug menu with cool features
- **F6 - Draw distance** - Toggles draw distance limitations
- **F7 - Smooth lighting** - Toggles smooth lighting feature (very buggy and unstable)
- **F8 - Disallow jumps** - Toggles ability to jump for more challenging gameplay
- **-/= - Game speed** - Decrease/Increase in game time speed
- **Num1/3 - Save/Load position** - Stores/Restores current Taz coordinates position
- **Num5 - Fly mode** - Toggles fly mode:
	- **Num2/8** - Move in X coordinates
	- **Num4/6** - Move in Y coordinates
	- **Num7/9** - Move in Z coordinates

### Patcher
Select necessary patches and click **Patch** or **Patch and Play!** All needed backups will be created automatically. Click **Restore** to restore all settings and files to original.
#### Load options:
- **NoCD patch** - Removes CD check during startup
- **No draw limit** - Disables draw distance limitations
- **Disable logo videos** - Disables Blitz games, Infogrames and Warner Bros. intro videos
- **No warning banner** - Disables unskipable safety intro warning
- **Language** - Change game language to En/Fr/Ge/It/Sp
#### Video options:
- **Aspect ratio** - Changes picture proportions (fills automatically, depends of resolution)
- **Resolution** - Changes video resolution (fills automatically with system resolution)
- **Windowed mode** - Launches game in windowed mode with selected resolution and ratio
#### Native options:
- **Launcher** - Launches native Taz: Wanted launcher
- **Video** - Launches native video setup
- **Audio** - Launches native audio setup
- **Controls** - Launches native controls setup
- **Game folder** - Opens game folder in explorer

## Game screenshots
![screens](https://user-images.githubusercontent.com/20092823/30523732-30c460a4-9bef-11e7-8b69-e0b33f27a09c.png)

## Used repos:
- **[GlobalKeyboardHook](https://github.com/jparnell8839/globalKeyboardHook)** - Key hooking functionality
- **[d3d8to9](https://github.com/crosire/d3d8to9)** - Converting Direct3D 8 API to Direct3D 9
- **[QuickBMS](http://aluigi.altervista.org/quickbms.htm)** - Game resource unpacking

## Known issues:
- Functional and other hooked keys (F1-F8, -, =) doesn't respond in other apps, when program is running
- Custom resolution and windowed mode may not work without [d3d8to9](https://github.com/crosire/d3d8to9) API converter
- Some non standard resolutions with fullscreen mode may crash game on startup
- Enabled smooth lighting crashes game in some scenes
