// Сгенерировано с помощью DeepSeek LLM
// Получение разрешения Windows без корректировок DPI
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public static class ScreenHelper
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public int Width => Right - Left;
        public int Height => Bottom - Top;
    }

    [DllImport("user32.dll")]
    private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

    private const int ENUM_CURRENT_SETTINGS = -1;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;
        public int dmPositionX;
        public int dmPositionY;
        public int dmDisplayOrientation;
        public int dmDisplayFixedOutput;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;
        public short dmLogPixels;
        public int dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
        public int dmICMMethod;
        public int dmICMIntent;
        public int dmMediaType;
        public int dmDitherType;
        public int dmReserved1;
        public int dmReserved2;
        public int dmPanningWidth;
        public int dmPanningHeight;
    }

    /// <summary>
    /// Получает физическое разрешение основного монитора
    /// </summary>
    public static Size GetPhysicalResolution()
    {
        DEVMODE devMode = new DEVMODE();
        devMode.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));

        if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref devMode))
        {
            return new Size(devMode.dmPelsWidth, devMode.dmPelsHeight);
        }

        // Fallback для систем, где EnumDisplaySettings не сработал
        return new Size(
            System.Windows.Forms.SystemInformation.VirtualScreen.Width,
            System.Windows.Forms.SystemInformation.VirtualScreen.Height
        );
    }

    /// <summary>
    /// Получает масштабированную рабочую область (без панели задач)
    /// </summary>
    public static Rectangle GetPhysicalWorkingArea()
    {
        try
        {
            Size resolution = GetPhysicalResolution();
            Screen primaryScreen = Screen.PrimaryScreen;

            // Коэффициент масштабирования между виртуальным и физическим экраном
            double xRatio = resolution.Width / (double)System.Windows.Forms.SystemInformation.VirtualScreen.Width;
            double yRatio = resolution.Height / (double)System.Windows.Forms.SystemInformation.VirtualScreen.Height;

            return new Rectangle(
                (int)(primaryScreen.WorkingArea.X * xRatio),
                (int)(primaryScreen.WorkingArea.Y * yRatio),
                (int)(primaryScreen.WorkingArea.Width * xRatio),
                (int)(primaryScreen.WorkingArea.Height * yRatio)
            );
        }
        catch
        {
            // Fallback на всю область экрана
            Size resolution = GetPhysicalResolution();
            return new Rectangle(0, 0, resolution.Width, resolution.Height);
        }
    }

    /// <summary>
    /// Получает текущий масштаб DPI системы
    /// </summary>
    public static float GetSystemDpiScale()
    {
        try
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                return g.DpiX / 96f;
            }
        }
        catch
        {
            return 1.0f;
        }
    }
}