## 📤 Unpacking
0. Make sure you have at least 1 GB free memory space if you want unpack all files
1. Press **Unpack game resources**
2. Choose Taz Pak files (`.pc`, `.xpb`, `.ps2`) in the first file dialog
3. Choose output folder in the second file dialog
4. Multiple files unpacking can take much time. It's Ok if app looks like not responding
5. Use specific tools for opening and editing unpacked media files (Audacity, Foobar2000+vgmstream, Bitmap/Hex editors...)

## 📥 Repacking
0. It's recommended to make backup of original Pak files
1. Press **Repack game resources**
2. Choose folder with unpacked resources in the first file dialog
3. Choose output file in the second file dialog


## 🎨 Modding
As an example, you can add vehicles at the level:
1. Unpack any `.pc` file with `.lom` file
2. Add objects to `.lom` file:
```c
Level
{
    ...
	Object
	{
		Name = "floorpolisher"
		SPECIALTYPE = "VEHICLE"
		TYPE = "FLOORPOLISHER"

		Instance
		{
			Name = "floorpolisher00"
			PosX = 0.000
			PosY = -5050.00
			PosZ = 0.000
			RotX = 0.000
			RotY = 1.000
			RotZ = 0.000
			RotW = 0.000
			SclX = 1.000
			SclY = 1.000
			SclZ = 1.000
		}
	}
	
	Object
	{
		Name = "MOTION"
		SPECIALTYPE = "VEHICLE"
		TYPE = "ROCKETBIKE"

		Instance
		{
			Name = "MOTION00"
			PosX = 200.00
			PosY = -5050.00
			PosZ = 0.000
			RotX = 0.000
			RotY = 0.000
			RotZ = 0.000
			RotW = -1.000
			SclX = 1.000
			SclY = 1.000
			SclZ = 1.000
		}
	}
	
	Object
	{
		Name = "trolley"
		SPECIALTYPE = "VEHICLE"
		TYPE = "TROLLEY"

		Instance
		{
			Name = "trolley00"
			PosX = 0.000
			PosY = -5050.00
			PosZ = 200.00
			RotX = -0.000
			RotY = -0.500
			RotZ = 0.000
			RotW = -0.500
			SclX = 1.000
			SclY = 1.000
			SclZ = 1.000
		}
	}
    ...
}
```

3. Replace **PosX/Y/Z** with **STARTPOSITION** (or any other) values

4. Create folders and files (copy from other unpacked `.pc` files):
- `\objects\floorpolisher.obe` - vrmuseum.pc
- `\objects\motion.obe` - vrgrandc.pc
- `\objects\trolley.obe` - vrdeptstr.pc
- `\textures\cleaner.bmp` - vrmuseum.pc
- `\textures\cleaner2.bmp` - vrmuseum.pc
- `\textures\cleaner2a.bmp` - vrmuseum.pc
- `\textures\cleaner3.bmp` - vrmuseum.pc
- `\textures\cleaner3a.bmp` - vrmuseum.pc
- `\textures\cleaner4.bmp` - vrmuseum.pc
- `\textures\cleaner5.bmp` - vrmuseum.pc
- `\textures\cleanera.bmp` - vrmuseum.pc
- `\textures\trolleyhandle01.bmp` - vrdeptstr.pc
- `\textures\trolleyhandle03.bmp` - vrdeptstr.pc
- `\textures\trolleyhandle04.bmp` - vrdeptstr.pc
- `\textures\trolleymesh01.bmp` - vrdeptstr.pc
- `\textures\trolleymesh02.bmp` - vrdeptstr.pc
- `\textures\trolleymesh03.bmp` - vrdeptstr.pc
- `\textures\trolleywheel01.bmp` - vrdeptstr.pc
- `\textures\trolleywheel02.bmp` - vrdeptstr.pc
- `\textures\trolleywheel03.bmp` - vrdeptstr.pc

5. Repack results back as original .pc file
