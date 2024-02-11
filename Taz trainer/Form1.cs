using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Utilities;
using Microsoft.Win32;
using System.IO;
using FormSerialisation;
using System.Net;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Taz_trainer.Properties;
using TarExample;
using System.Globalization;
using static DPI_Per_Monitor;

namespace Taz_trainer
{
    public partial class form : System.Windows.Forms.Form
    {
        // dll import (pinvoke.net)
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        string gihubUrl = "https://github.com";
        string TazFolderPath = "";
        float maxSpd = 2f;
        float Xcoord = 0f;
        float Ycoord = 0f;
        float Zcoord = 0f;
        float camSpd = 2000f;
        float flyStep = 5000f;

        // DPI hacking
        void SetUserFonts(float scaleFactorX, float scaleFactorY)
        {
            var OldFont = Font;
            Font = new Font(OldFont.FontFamily, 11f * scaleFactorX, OldFont.Style, GraphicsUnit.Pixel);
            Refresh();
            OldFont.Dispose();
        }
        protected override void DefWndProc(ref Message m)
        {
            DPI_Per_Monitor.Check_WM_DPICHANGED_WM_NCCREATE(SetUserFonts, m, this.Handle);
            base.DefWndProc(ref m);
        }

        public form()
        {
            // Make the GUI ignore the DPI setting
            //Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            InitializeComponent();
            DPI_Per_Monitor.TryEnableDPIAware(this, SetUserFonts);

            gkh.HookedKeys.Add(Keys.F1);
            gkh.HookedKeys.Add(Keys.F2);
            gkh.HookedKeys.Add(Keys.F3);
            gkh.HookedKeys.Add(Keys.F4);
            gkh.HookedKeys.Add(Keys.F5);
            gkh.HookedKeys.Add(Keys.F6);
            gkh.HookedKeys.Add(Keys.F7);
            gkh.HookedKeys.Add(Keys.F8);
            gkh.HookedKeys.Add(Keys.F9);
            gkh.HookedKeys.Add(Keys.F10);
            gkh.HookedKeys.Add(Keys.F11);
            gkh.HookedKeys.Add(Keys.F12);
            gkh.HookedKeys.Add(Keys.Insert);
            gkh.HookedKeys.Add(Keys.Home);
            gkh.HookedKeys.Add(Keys.End);
            gkh.HookedKeys.Add(Keys.OemMinus);
            gkh.HookedKeys.Add(Keys.Oemplus);

            gkh.HookedKeys.Add(Keys.NumPad9);
            gkh.HookedKeys.Add(Keys.NumPad8);
            gkh.HookedKeys.Add(Keys.NumPad7);
            gkh.HookedKeys.Add(Keys.NumPad6);
            gkh.HookedKeys.Add(Keys.NumPad5);
            gkh.HookedKeys.Add(Keys.NumPad4);
            gkh.HookedKeys.Add(Keys.NumPad3);
            gkh.HookedKeys.Add(Keys.NumPad2);
            gkh.HookedKeys.Add(Keys.NumPad1);
            gkh.HookedKeys.Add(Keys.NumPad0);
            gkh.HookedKeys.Add(Keys.Multiply);
            gkh.HookedKeys.Add(Keys.Divide);


            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);


            TazFolderPath = getPathFromRegistry();

            if (TazFolderPath != "" && File.Exists(TazFolderPath + @"\Patcher.xml"))
            {
                try
                {
                    // Load form element states
                    FormSerialisor.Deserialise(this, TazFolderPath + @"\Patcher.xml");
                    textBoxRegistry.Text = getPathFromRegistry();
                }
                catch (Exception ex)
                {
                    this.statusField.Text = ex.Message.ToString();
                    this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                    // Default form element states
                    autoFillVideo(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    textBoxRegistry.Text = getPathFromRegistry();
                    langComboBox.SelectedIndex = 0;
                    apiComboBox.SelectedIndex = 0;
                    layoutComboBox.SelectedIndex = 0;
                    fogComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                // Default form element states
                autoFillVideo(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                textBoxRegistry.Text = getPathFromRegistry();
                langComboBox.SelectedIndex = 0;
                apiComboBox.SelectedIndex = 0;
                layoutComboBox.SelectedIndex = 0;
                fogComboBox.SelectedIndex = 0;
            }

            // Repacking tab init
            string RepackingHTML = Properties.Resources.Repacking;
            webBrowserRepacking.DocumentText = RepackingHTML;

            // Usage tab init
            //string html = Properties.Resources.README;
            //webBrowser.DocumentText = html;

            // Welcome Message
            this.statusField.Text = "v4.0";
            this.statusField.ForeColor = System.Drawing.Color.Black;
        }

        //#######################################################################################################################
        //Key hooker functions

        globalKeyboardHook gkh = new globalKeyboardHook();


        void gkh_KeyUp(object sender, KeyEventArgs e)
        {

            e.Handled = true;
        }


        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.invisibility.Checked = !this.invisibility.Checked;
                sendKey(Keys.F1, "{F1}");
            }
            if (e.KeyCode == Keys.F2)
            {
                this.superBelchCan.Checked = !this.superBelchCan.Checked;
                sendKey(Keys.F2, "{F2}");
            }
            if (e.KeyCode == Keys.F3)
            {
                this.superJump.Checked = !this.superJump.Checked;
                sendKey(Keys.F3, "{F3}");
            }
            if (e.KeyCode == Keys.F4)
            {
                this.freezeLevelTimer.Checked = !this.freezeLevelTimer.Checked;
                sendKey(Keys.F4, "{F4}");
            }
            if (e.KeyCode == Keys.F5)
            {
                this.debugMenu.Checked = !this.debugMenu.Checked;
                sendKey(Keys.F5, "{F5}");
            }
            if (e.KeyCode == Keys.F6)
            {
                this.drawDistance.Checked = !this.drawDistance.Checked;
                sendKey(Keys.F6, "{F6}");
            }
            if (e.KeyCode == Keys.F7)
            {
                this.textureFilter.Checked = !this.textureFilter.Checked;
                sendKey(Keys.F7, "{F7}");
            }
            if (e.KeyCode == Keys.F8)
            {
                this.textureAlpha.Checked = !this.textureAlpha.Checked;
                sendKey(Keys.F8, "{F8}");
            }
            if (e.KeyCode == Keys.F9)
            {
                this.fpsCap.Checked = !this.fpsCap.Checked;
                sendKey(Keys.F9, "{F9}");
            }
            if (e.KeyCode == Keys.F10)
            {
                this.smoothLighting.Checked = !this.smoothLighting.Checked;
                sendKey(Keys.F10, "{F10}");
            }
            if (e.KeyCode == Keys.F11)
            {
                this.disallowJump.Checked = !this.disallowJump.Checked;
                sendKey(Keys.F11, "{F11}");
            }
            if (e.KeyCode == Keys.F12)
            {
                this.ballMode.Checked = !this.ballMode.Checked;
                sendKey(Keys.F12, "{F12}");
            }
            if (e.KeyCode == Keys.Insert)
            {
                this.debugInfo.Checked = !this.debugInfo.Checked;
                sendKey(Keys.Insert, "{Insert}");
            }
            if (e.KeyCode == Keys.Home)
            {
                this.undestructibleWorld.Checked = !this.undestructibleWorld.Checked;
                sendKey(Keys.Home, "{Home}");
            }
            if (e.KeyCode == Keys.End)
            {
                this.bulldozerMode.Checked = !this.bulldozerMode.Checked;
                sendKey(Keys.End, "{End}");
            }
            if (e.KeyCode == Keys.OemMinus)
            {
                changeGameSpeed(0);
                sendKey(Keys.OemMinus, "{-}");
            }
            if (e.KeyCode == Keys.Oemplus)
            {
                changeGameSpeed(1);
                sendKey(Keys.Oemplus, "{=}");
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                //if (e.IsRepeat) return;
                this.flyMode.Checked = !this.flyMode.Checked;
                sendKey(Keys.NumPad5, "{5}");
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(0); //Z+
                }
                sendKey(Keys.NumPad9, "{9}");
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(4); //Y+
                }
                sendKey(Keys.NumPad8, "{8}");
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(1); //Z-
                }
                sendKey(Keys.NumPad7, "{7}");
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(2); //X+
                }
                sendKey(Keys.NumPad6, "{6}");
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(3); //X-
                }
                sendKey(Keys.NumPad4, "{4}");
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                this.loadPos.Checked = !this.loadPos.Checked;
                sendKey(Keys.NumPad3, "{3}");
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(5); //Y-
                }
                sendKey(Keys.NumPad2, "{2}");
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                this.savePos.Checked = !this.savePos.Checked;
                sendKey(Keys.NumPad1, "{1}");
            }
            if (e.KeyCode == Keys.NumPad0)
            {
                this.flyCamera.Checked = !this.flyCamera.Checked;
                sendKey(Keys.NumPad0, "{0}");
            }
            if (e.KeyCode == Keys.Multiply)
            {
                incFPScap();
                sendKey(Keys.Multiply, "{*}");
            }
            if (e.KeyCode == Keys.Divide)
            {
                decFPScap();
                sendKey(Keys.Divide, "{/}");
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F4)
            {
                this.kill_Click(sender, e);
            }

            e.Handled = true;
        }

        private void sendKey(System.Windows.Forms.Keys item, String key)
        {
            //sends keycode for another apps without hooking
            gkh.HookedKeys.Remove(item);
            SendKeys.Send(key);
            gkh.HookedKeys.Add(item);
        }

        //#######################################################################################################################
        //Process functions

        public string procName = "Taz";


        //Searching process
        private int findProcessId(string procName)
        {
            var procList = Process.GetProcesses();

            foreach (var proc in procList)
            {
                if (proc.ProcessName == procName && proc.ProcessName.Length == procName.Length)
                {
                    return proc.Id;
                }
            }
            return 0;
        }


        //Read memory from process
        private byte[] checkAndRead(IntPtr adress, byte[] bytes, int size, IntPtr mem)
        {
            int procId = findProcessId(procName);
            if (procId == 0)
            {
                this.statusField.Text = "Change option failed. " + procName + " process not found!";
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return bytes;
            }
            this.statusField.Text = procName + "process found";
            var handle = OpenProcess(0x001F0FFF, false, procId);
            ReadProcessMemory(handle, (IntPtr)adress, bytes, size, out mem);
            CloseHandle(handle);
            return bytes;
        }


        //Write process in memory
        private void checkAndWrite(IntPtr adress, byte[] bytes, int size, IntPtr mem)
        {
            int procId = findProcessId(procName);
            if (procId == 0)
            {
                this.statusField.Text = "Change option failed. " + procName + " process not found!";
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
            var handle = OpenProcess(0x001F0FFF, false, procId);
            this.statusField.Text = procName + " process found. Handle = " + handle;
            this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            if (WriteProcessMemory(handle, (IntPtr)adress, bytes, size, out mem) == false)
            {
                this.statusField.Text = "WriteProcessMemory failed! Handle = " + handle;
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            };
            CloseHandle(handle);
        }

        //Kill process
        private void killProcess()
        {
            int procId = findProcessId(procName);
            if (procId == 0)
            {
                this.statusField.Text = "Kill process failed. " + procName + " process not found!";
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
            else
            {
                Process.GetProcessById(procId).Kill();
                this.statusField.Text = procName + " process killed";
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
        }

        //#######################################################################################################################
        //Other

        private void autoFillVideo(int width, int height)
        {
            //fill resolution
            this.width.Text = width.ToString();
            this.height.Text = height.ToString();
            this.windowed.Checked = false;
        }

        private void autoAspect(int width, int height)
        {
            //calculate aspect ratio
            int a = width;
            int b = height;
            int aspect1 = 0;
            int aspect2 = 0;
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            if (a != 0)
            {
                aspect1 = width / a;
                aspect2 = height / a;
            }
            //if long
            while (aspect1 > 255 || aspect2 > 255)
            {
                aspect1 /= 2;
                aspect2 /= 2;
            }
            //fill aspect
            this.aspect1.Text = aspect1.ToString();
            this.aspect2.Text = aspect2.ToString();
        }
        private void width_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string width = this.width.Text;
                string height = this.height.Text;
                if (width == "")
                    width = "0";
                if (height == "")
                    height = "0";
                autoAspect(UInt16.Parse(width), UInt16.Parse(height));
                windowed.Checked = true;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }
        private void height_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string width = this.width.Text;
                string height = this.height.Text;
                if (width == "")
                    width = "0";
                if (height == "")
                    height = "0";
                autoAspect(UInt16.Parse(width), UInt16.Parse(height));
                windowed.Checked = true;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void playSound(System.IO.Stream stream)
        {
            if (trainerSound.Checked == true)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(stream);
                player.Play();
            }

        }


        //#######################################################################################################################
        //Cheats
        private void drawDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.drawDistance.Checked == true)
            {
                //environment
                byte[] bytes = { 0xFF, 0xFF }; // mov word ptr [esi+1E6h], 0FFFFh
                checkAndWrite((IntPtr)0x00474FC4, bytes, bytes.Length, new IntPtr());
                byte[] bytes2 = { 0xEB }; // jmp
                checkAndWrite((IntPtr)0x00474FD0, bytes2, bytes2.Length, new IntPtr());

                // CollectibleTwinkle
                byte[] bytes3 = { 0x00, 0x00, 0x80, 0x7F }; // +Inf
                checkAndWrite((IntPtr)0x005F66E8, bytes3, bytes3.Length, new IntPtr());
                byte[] bytes4 = { 0xE8, 0x66, 0x5F, 0x00 }; // fcomp [+Inf]
                checkAndWrite((IntPtr)0x0047E00B, bytes4, bytes4.Length, new IntPtr());
                byte[] bytes5 = { 0xD9, 0xE8, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }; // fld1; nops
                checkAndWrite((IntPtr)0x0047E016, bytes5, bytes5.Length, new IntPtr());

                message("Infinity Draw Distance: On");
            }
            else
            {
                //environment
                byte[] bytes = { 0x00, 0x00 }; // mov word ptr [esi+1E6h], 0h
                checkAndWrite((IntPtr)0x00474FC4, bytes, bytes.Length, new IntPtr());
                byte[] bytes2 = { 0x75 }; // jnz
                checkAndWrite((IntPtr)0x00474FD0, bytes2, bytes2.Length, new IntPtr());

                // CollectibleTwinkle
                //byte[] bytes3 = { 0x00, 0x00, 0x00, 0x00 }; // 00
                //checkAndWrite((IntPtr)0x005F66E8, bytes3, bytes3.Length, new IntPtr());
                byte[] bytes4 = { 0xF4, 0x75, 0x5F, 0x00 }; // fcomp [5000.0]
                checkAndWrite((IntPtr)0x0047E00B, bytes4, bytes4.Length, new IntPtr());
                byte[] bytes5 = { 0xD9, 0x46, 0x3C, 0xD8, 0x0D, 0xE4, 0x7E, 0x5F, 0x00, 0xD9, 0xFE }; // fld dword ptr [esi+3Ch]; fmul [0.00062831852]; fsin
                checkAndWrite((IntPtr)0x0047E016, bytes5, bytes5.Length, new IntPtr());

                message("Infinity Draw Distance: Off");
            }
        }

        private void superJump_CheckedChanged(object sender, EventArgs e)
        {
            //code injection
            byte[] bytes = { 0x51, 0x50, 0x8B, 0x0D, 0x90, 0x83, 0x6C, 0x00, 0x8B, 0x49, 0x20, 0x81, 0xF9, 0x00, 0x00, 0x00, 0x00, 0x74, 0x17, 0x8B, 0x0D, 0xC0, 0x8B, 0x6C, 0x00, 0x8B, 0x89, 0xC0, 0x01, 0x00, 0x00, 0xB8, 0x00, 0xC0, 0xDA, 0x44, 0x89, 0x81, 0x98, 0x00, 0x00, 0x00, 0x58, 0x59, 0xD9, 0x44, 0x24, 0x58, 0xD8, 0x63, 0x08, 0xD9, 0x9F, 0xC8, 0x00, 0x00, 0x00, 0xE9, 0x82, 0xBB, 0xE6, 0xFF };
            checkAndWrite((IntPtr)0x005F6692, bytes, bytes.Length, new IntPtr());

            //Inject jmp
            if (this.superJump.Checked == true)
            {
                byte[] bytes2 = { 0xE9, 0x48, 0x44, 0x19, 0x00, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x00462245, bytes2, bytes2.Length, new IntPtr());

                message("Moon Jump: On (Hold Jump Button)");
            }
            else
            {
                byte[] bytes2 = { 0xD9, 0x44, 0x24, 0x58, 0xD8, 0x63, 0x08 };
                checkAndWrite((IntPtr)0x00462245, bytes2, bytes2.Length, new IntPtr());

                message("Moon Jump: Off");
            }
        }


        private void changeGameSpeed(byte ch)
        {
            //read current speed
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            bytes = checkAndRead((IntPtr)0x006F4A3C, bytes, bytes.Length, new IntPtr());
            float current = BitConverter.ToSingle(bytes, 0);

            //PositiveInfinity stops game, all other commented values crashes
            float[] values = { /* 0, Single.Epsilon, 0.0000001f, */ 0.000001f, 0.001f, 0.01f, 0.1f, 1, maxSpd /*, Single.MaxValue, Single.PositiveInfinity*/ };
            int index = Array.FindIndex(values, x => x == current);

            if (index == -1) index = Array.FindIndex(values, x => x == 1);

            if (!((index == 0 && ch == 0) || (index == values.Length - 1 && ch == 1)))
            {
                //inc or dec speed
                if (ch == 1) index++;
                else index--;
            }
            checkAndWrite((IntPtr)0x006F4A3C, BitConverter.GetBytes(values[index]), BitConverter.GetBytes(values[index]).Length, new IntPtr());
            string num = values[index].ToString();
            if (index == 0) num = "0,000001";
            message("Game Speed: x" + num);
        }


        private void superBelchCan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.superBelchCan.Checked == true)
            {
                byte[] bytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x00482FE2, bytes, bytes.Length, new IntPtr());

                message("Burp Soda Mode: On (Press Rant)");
            }
            else
            {
                byte[] bytes = { 0x0F, 0x85, 0x95, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00482FE2, bytes, bytes.Length, new IntPtr());

                message("Burp Soda Mode: Off");
            }
        }


        private void invisibility_CheckedChanged(object sender, EventArgs e)
        {
            var adress = 0x006C8BC0; //Base adress
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            bytes = checkAndRead((IntPtr)adress, bytes, bytes.Length, new IntPtr());
            adress = BitConverter.ToInt32(bytes, 0);
            adress += 0x1CC;
            bytes = checkAndRead((IntPtr)adress, bytes, bytes.Length, new IntPtr());
            adress = BitConverter.ToInt32(bytes, 0);
            adress += 0x170;

            if (this.invisibility.Checked == true)
            {
                byte[] bytes2 = { 0x85 };
                checkAndWrite((IntPtr)0x0051F2E7, bytes2, bytes2.Length, new IntPtr());
                bytes2[0] = 0x01;
                checkAndWrite((IntPtr)0x0051F47E, bytes2, bytes2.Length, new IntPtr());
                //bytes2[0] = 0x01;
                checkAndWrite((IntPtr)adress, bytes2, bytes2.Length, new IntPtr());


                message("Invisibility Mode: On");
            }
            else
            {
                byte[] bytes2 = { 0x84 };
                checkAndWrite((IntPtr)0x0051F2E7, bytes2, bytes2.Length, new IntPtr());
                bytes2[0] = 0x00;
                checkAndWrite((IntPtr)0x0051F47E, bytes2, bytes2.Length, new IntPtr());
                //bytes2[0] = 0x00;
                checkAndWrite((IntPtr)adress, bytes2, bytes2.Length, new IntPtr());

                message("Invisibility Mode: Off");
            }
        }


        private void flyMode_CheckedChanged(object sender, EventArgs e)
        {

            byte[] bytes = { 0x81, 0xBF, 0xA0, 0x01, 0x00, 0x00, 0x74, 0x61, 0x7A, 0x64, 0x0F, 0x84, 0xC5, 0xBB, 0xE6, 0xFF, 0xD9, 0x44, 0x24, 0x54, 0xD8, 0x63, 0x04, 0xD9, 0x9F, 0xC4, 0x00, 0x00, 0x00, 0xE9, 0xB3, 0xBB, 0xE6, 0xFF };
            checkAndWrite((IntPtr)0x005F6670, bytes, bytes.Length, new IntPtr());

            /*
            //Editing taz state in structure
            adress = 0x006C8BC0; //Base adress
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            adress = BitConverter.ToInt32(bytes, 0);
            adress += 0x1C8; //Second adress
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            adress = BitConverter.ToInt32(bytes, 0);
            adress += 0xB0; //Target adress

            bytes[0] = 0x00;
            size = 1;

            if (this.flyMode.Checked == true)
            {
                bytes[0] = 0x00; // 3C;
            }
            */

            //Change instruction for gravity
            if (this.flyMode.Checked == true)
            {
                byte[] bytes2 = { 0xE9, 0x33, 0x44, 0x19, 0x00, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x00462238, bytes2, bytes2.Length, new IntPtr());

                message("Fly Mode: On (Use Numpad)");
            }
            else
            {
                //Z force = 0
                var adress = 0x006C8BC0; //Base adress
                byte[] bytes3 = { 0x00, 0x00, 0x00, 0x00 };
                bytes = checkAndRead((IntPtr)adress, bytes3, bytes3.Length, new IntPtr());
                adress = BitConverter.ToInt32(bytes3, 0);
                adress += 0x1C0;
                bytes = checkAndRead((IntPtr)adress, bytes3, bytes3.Length, new IntPtr());
                adress = BitConverter.ToInt32(bytes3, 0);
                adress += 0x98;
                checkAndWrite((IntPtr)adress, bytes3, bytes3.Length, new IntPtr());

                byte[] bytes2 = { 0xD9, 0x44, 0x24, 0x54, 0xD8, 0x63, 0x04 };
                checkAndWrite((IntPtr)0x00462238, bytes2, bytes2.Length, new IntPtr());

                message("Fly Mode: Off");
            }
        }

        private void movement(byte dir)
        {
            //Read taz structure coordinates offset
            float value;
            var adress = 0x006C8BC0; //Base adress
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            int size = bytes.Length;
            var mem = new IntPtr();
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            adress = BitConverter.ToInt32(bytes, 0);
            switch (dir)
            {

                case (0): //Z+
                    //Coordinate
                    adress += 0xC4;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    /*
                    //Camera
                    adress = 0x00708994;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    //Camera point at
                    adress = 0x007089A4;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    */
                    break;

                case (1): //Z-
                    //Coordinate
                    adress += 0xC4;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    /*
                    //Camera
                    adress = 0x00708994;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    //Camera point at
                    adress = 0x007089A4;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    */
                    break;

                case (2): //X+
                    //Coordinate
                    adress += 0xC0;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    /*
                    //Camera
                    adress = 0x00708990;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    //Camera point at
                    adress = 0x007089A0;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    */
                    break;

                case (3): //X-
                    //Coordinate
                    adress += 0xC0;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    /*
                    //Camera
                    adress = 0x00708990;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    //Camera point at
                    adress = 0x007089A0;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    */
                    break;

                case (4): //Y+
                    //Coordinate
                    adress += 0xC8;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    /*
                    //Camera
                    adress = 0x00708998;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    //Camera point at
                    adress = 0x007089A8;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value += 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    */
                    break;

                case (5): //Y-
                    //Coordinate
                    adress += 0xC8;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    /*
                    //Camera
                    adress = 0x00708998;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    //Camera point at
                    adress = 0x007089A8;
                    bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
                    value = BitConverter.ToSingle(bytes, 0);
                    value -= 1000;
                    bytes = BitConverter.GetBytes(value);
                    checkAndWrite((IntPtr)adress, bytes, size, mem);
                    */
                    break;
            }
        }

        private void savePos_CheckedChanged(object sender, EventArgs e)
        {
            //Read taz structure coordinates offset
            float value;
            var adress = 0x006C8BC0; //Base adress
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            int size = bytes.Length;
            var mem = new IntPtr();
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            adress = BitConverter.ToInt32(bytes, 0);
            adress += 0xC0;
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            value = BitConverter.ToSingle(bytes, 0);
            Xcoord = value;
            adress += 0x4;
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            value = BitConverter.ToSingle(bytes, 0);
            Ycoord = value;
            adress += 0x4;
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            value = BitConverter.ToSingle(bytes, 0);
            Zcoord = value;

            savedCoordX.Text = Xcoord.ToString();
            savedCoordY.Text = Ycoord.ToString();
            savedCoordZ.Text = Zcoord.ToString();

            message("Taz Position Saved");
        }

        private void loadPos_CheckedChanged(object sender, EventArgs e)
        {
            //Read taz structure coordinates offset
            var adress = 0x006C8BC0; //Base adress
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            int size = bytes.Length;
            var mem = new IntPtr();
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            adress = BitConverter.ToInt32(bytes, 0);
            adress += 0xC0;
            bytes = BitConverter.GetBytes(Xcoord);
            checkAndWrite((IntPtr)adress, bytes, size, mem);
            adress += 0x4;
            bytes = BitConverter.GetBytes(Ycoord);
            checkAndWrite((IntPtr)adress, bytes, size, mem);
            adress += 0x4;
            bytes = BitConverter.GetBytes(Zcoord);
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            message("Taz Position Loaded");
        }

        private void flyCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (this.flyCamera.Checked == true)
            {
                
                // Hide messages
                byte[] bytes2 = { 0x00 };
                checkAndWrite((IntPtr)0x00643008, bytes2, bytes2.Length, new IntPtr());
                byte[] bytes3 = { 0x00 };
                checkAndWrite((IntPtr)0x0064301C, bytes3, bytes3.Length, new IntPtr());
                // Fly camera state
                byte[] bytes = { 0x01 };
                checkAndWrite((IntPtr)0x0071C4D4, bytes, bytes.Length, new IntPtr());
                // Controls suspend
                byte[] controlsuspend = { 0x01 };
                checkAndWrite((IntPtr)0x006C8E02, controlsuspend, controlsuspend.Length, new IntPtr());
                // Custom camera speed
                byte[] spd = BitConverter.GetBytes(camSpd);
                checkAndWrite((IntPtr)0x00731340, spd, spd.Length, new IntPtr());
                byte[] camSpdOffset = { 0x40, 0x13, 0x73, 0x00 };
                checkAndWrite((IntPtr)0x004E14ED, camSpdOffset, camSpdOffset.Length, new IntPtr());
                checkAndWrite((IntPtr)0x004E14FB, camSpdOffset, camSpdOffset.Length, new IntPtr());
                checkAndWrite((IntPtr)0x004E1505, camSpdOffset, camSpdOffset.Length, new IntPtr());


                message("Photo Mode: On (Velocity = " + camSpd.ToString() + ")" );
            }
            else
            {
                // Fly camera state
                byte[] bytes = { 0x00 };
                checkAndWrite((IntPtr)0x0071C4D4, bytes, bytes.Length, new IntPtr());
                // Restore messages
                byte[] bytes2 = { 0x74 };
                checkAndWrite((IntPtr)0x00643008, bytes2, bytes2.Length, new IntPtr());
                byte[] bytes3 = { 0x66 };
                checkAndWrite((IntPtr)0x0064301C, bytes3, bytes3.Length, new IntPtr());
                // Controls restore
                byte[] controlsuspend = { 0x00 };
                checkAndWrite((IntPtr)0x006C8E02, controlsuspend, controlsuspend.Length, new IntPtr());
                // Restore camera speed
                byte[] camSpdOffset = { 0xF8, 0x73, 0x5F, 0x00 };
                checkAndWrite((IntPtr)0x004E14ED, camSpdOffset, camSpdOffset.Length, new IntPtr());
                checkAndWrite((IntPtr)0x004E14FB, camSpdOffset, camSpdOffset.Length, new IntPtr());
                checkAndWrite((IntPtr)0x004E1505, camSpdOffset, camSpdOffset.Length, new IntPtr());

                message("Photo Mode: Off");
            }

        }
        private void freezeLevelTimer_CheckedChanged(object sender, EventArgs e)
        {

            if (this.freezeLevelTimer.Checked == true)
            {
                //bonuscrates
                byte[] bytes = { 0x31, 0xDB, 0xEB, 0x10 };
                checkAndWrite((IntPtr)0x004ECF9F, bytes, bytes.Length, new IntPtr());

                //bonusrace
                byte[] bytes2 = { 0xA1, 0x2C, 0xC6, 0x71, 0x00, 0x83, 0xF8, 0x01, 0xEB, 0x10 };
                checkAndWrite((IntPtr)0x004F7305, bytes2, bytes2.Length, new IntPtr());

                //gladiatoons
                byte[] bytes3 = { 0x8A, 0x15, 0x54, 0x4A, 0x6F, 0x00, 0x84, 0xD2, 0xC7, 0x44, 0x24, 0x14, 0x00, 0x00, 0x00, 0x00, 0xEB, 0x10 };
                checkAndWrite((IntPtr)0x00518D88, bytes3, bytes3.Length, new IntPtr());

                //leveltime
                byte[] bytes4 = { 0x0F, 0xBE, 0x0D, 0x30, 0x4C, 0x70, 0x00, 0x51, 0xEB, 0x10 };
                checkAndWrite((IntPtr)0x004A7543, bytes4, bytes4.Length, new IntPtr());

                //security boxes
                //byte[] bytes5 = { 0xE9, 0xC1, 0x00, 0x00, 0x00 };
                //checkAndWrite((IntPtr)0x0044B7C7, bytes5, bytes5.Length, new IntPtr());
                //byte[] bytes6 = { 0xC7, 0x44, 0x24, 0x08, 0xCD, 0xCC, 0xCC, 0x3D, 0xEB, 0x1A };
                //checkAndWrite((IntPtr)0x0044B8BE, bytes6, bytes6.Length, new IntPtr());
                byte[] bytes5 = { 0x90, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x0044AE2B, bytes5, bytes5.Length, new IntPtr());


                message("Freeze Timers & Sam Boxes: On");
            }
            else
            {
                //bonuscrates
                byte[] bytes = { 0xD9, 0x05, 0x88, 0x4B };
                checkAndWrite((IntPtr)0x004ECF9F, bytes, bytes.Length, new IntPtr());

                //bonusrace
                byte[] bytes2 = { 0xD9, 0x05, 0x88, 0x4B, 0x6F, 0x00, 0xA1, 0x2C, 0xC6, 0x71 };
                checkAndWrite((IntPtr)0x004F7305, bytes2, bytes2.Length, new IntPtr());

                //gladiatoons
                byte[] bytes3 = { 0xD9, 0x05, 0x88, 0x4B, 0x6F, 0x00, 0x8A, 0x15, 0x54, 0x4A, 0x6F, 0x00, 0x84, 0xD2, 0xD8, 0x05, 0x84, 0x65 };
                checkAndWrite((IntPtr)0x00518D88, bytes3, bytes3.Length, new IntPtr());

                //leveltime
                byte[] bytes4 = { 0xD9, 0x05, 0xB8, 0x8B, 0x6C, 0x00, 0x0F, 0xBE, 0x0D, 0x30 };
                checkAndWrite((IntPtr)0x004A7543, bytes4, bytes4.Length, new IntPtr());

                //security boxes
                //byte[] bytes5 = { 0x0F, 0x85, 0x2C, 0x02, 0x00 };
                //checkAndWrite((IntPtr)0x0044B7C7, bytes5, bytes5.Length, new IntPtr());
                //byte[] bytes6 = { 0x74, 0x1A, 0x48, 0x74, 0x0D, 0x48, 0x75, 0x1C, 0xC7, 0x44 };
                //checkAndWrite((IntPtr)0x0044B8BE, bytes6, bytes6.Length, new IntPtr());
                byte[] bytes5 = { 0xE8, 0x50, 0xEC, 0xFF, 0xFF };
                checkAndWrite((IntPtr)0x0044AE2B, bytes5, bytes5.Length, new IntPtr());

                message("Freeze Timers & Sam Boxes: Off");
            }
        }

        private void textureFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.textureFilter.Checked == true)
            {
                //set D3DTSS_MAGFILTER filtering value to D3DTEXF_POINT (Stage 0 + Stage 1)
                byte[] bytes = { 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00655E00, bytes, bytes.Length, new IntPtr());

                message("Texture Filter: Nearest-Neighbour");
            }
            else
            {
                //set D3DTSS_MAGFILTER filtering value to D3DTEXF_LINEAR (Original)
                byte[] bytes = { 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00655E00, bytes, bytes.Length, new IntPtr());

                message("Texture Filter: Linear");
            }
        }

        private void textureAlpha_CheckedChanged(object sender, EventArgs e)
        {
            if (this.textureAlpha.Checked == true)
            {
                //set D3DTSS_ALPHAOP value to D3DTOP_BLENDTEXTUREALPHA
                byte[] bytes = { 0x0D };
                checkAndWrite((IntPtr)0x0057384C, bytes, bytes.Length, new IntPtr());

                message("Show Alpha Textures: On");
            }
            else
            {
                //set D3DTSS_ALPHAOP value to D3DTOP_MODULATE2X (Original)
                byte[] bytes = { 0x05 };
                checkAndWrite((IntPtr)0x0057384C, bytes, bytes.Length, new IntPtr());

                message("Show Alpha Textures: Off");
            }
        }

        private void debugMenu_CheckedChanged(object sender, EventArgs e)
        {
            SingleCallInitialise();

            // Get Debug Menu State
            byte[] state = { 0x00 };
            checkAndRead((IntPtr) 0x00752028, state, 1, new IntPtr());

            if (state[0] == 0)
            {
                // Debug Menu Activate
                // DbgMenuShow.CEA
                byte[] enterGui = { 0x68, 0x80, 0x37, 0x4A, 0x00, 0xE8, 0xE6, 0xB6, 0xE4, 0xFF, 0x83, 0xC4, 0x04, 0xC3 };
                checkAndWrite((IntPtr) 0x00731500, enterGui, enterGui.Length, new IntPtr());

                byte[] codeInjection = { 0xE8, 0xFB, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00731400, codeInjection, codeInjection.Length, new IntPtr());

                message("");
            }
            else
            {
                // Debug Menu Deactivate
                // DbgMenuHide.CEA
                byte[] exitGui = { 0xE8, 0x5B, 0xB7, 0xE4, 0xFF, 0xC3 };
                checkAndWrite((IntPtr)0x00731500, exitGui, exitGui.Length, new IntPtr());

                byte[] codeInjection = { 0xE8, 0xFB, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00731400, codeInjection, codeInjection.Length, new IntPtr());

                message("");
            }
        }

        private void debugInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.debugInfo.Checked == true)
            {
                //debugTextOn_1929
                byte[] bytes = { 0x01 };
                checkAndWrite((IntPtr)0x006F4CAA, bytes, bytes.Length, new IntPtr());

                message("Show Debug Info: On");
            }
            else
            {
                //debugTextOn_1929
                byte[] bytes = { 0x00 };
                checkAndWrite((IntPtr)0x006F4CAA, bytes, bytes.Length, new IntPtr());

                message("Show Debug Info: Off");
            }
        }

        private void disallowJump_CheckedChanged(object sender, EventArgs e)
        {
            if (this.disallowJump.Checked == true)
            {
                byte[] bytes = { 0xE9, 0x97, 0x01, 0x00, 0x00, 0x90 };
                checkAndWrite((IntPtr)0x00481207, bytes, bytes.Length, new IntPtr());

                byte[] bytes2 = { 0xE9, 0x69, 0x01, 0x00, 0x00, 0x90 };
                checkAndWrite((IntPtr)0x004825CB, bytes2, bytes2.Length, new IntPtr());

                byte[] bytes3 = { 0xE9, 0xAF, 0x01, 0x00, 0x00, 0x90 };
                checkAndWrite((IntPtr)0x004842E9, bytes3, bytes3.Length, new IntPtr());

                message("No Jumps Mode: On");
            }
            else
            {
                byte[] bytes = { 0x0F, 0x84, 0x96, 0x01, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00481207, bytes, bytes.Length, new IntPtr());

                byte[] bytes2 = { 0x0F, 0x84, 0x68, 0x01, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x004825CB, bytes2, bytes2.Length, new IntPtr());

                byte[] bytes3 = { 0x0F, 0x84, 0xAE, 0x01, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x004842E9, bytes3, bytes3.Length, new IntPtr());

                message("No Jumps Mode: Off");
            }
        }
        private void undestructibleWorld_CheckedChanged(object sender, EventArgs e)
        {
            if (this.undestructibleWorld.Checked == true)
            {
                if (this.bulldozerMode.Checked == true)
                    bulldozerMode.Checked = false;
                byte[] bytes = { 0xEB, 0x0D };
                checkAndWrite((IntPtr)0x0041B87B, bytes, bytes.Length, new IntPtr());

                message("No Destructions Mode: On");
            }
            else
            {
                byte[] bytes = { 0x75, 0x16 };
                checkAndWrite((IntPtr)0x0041B87B, bytes, bytes.Length, new IntPtr());

                message("No Destructions Mode: Off");
            }
        }

        private void bulldozerMode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bulldozerMode.Checked == true)
            {
                if (this.undestructibleWorld.Checked == true)
                    undestructibleWorld.Checked = false;
                byte[] bytes = { 0xB9, 0x01, 0x00, 0x00, 0x00, 0x90 }; // Alt Undestructible - 0xB9, 0x01, 0x00, 0x00, 0x00, 0x90
                checkAndWrite((IntPtr)0x0041B93C, bytes, bytes.Length, new IntPtr()); // mov ecx,1; nop

                message("Bulldozer Mode: On");
            }
            else
            {
                byte[] bytes = { 0x0F, 0x87, 0x48, 0xFF, 0xFF, 0xFF }; // Original
                checkAndWrite((IntPtr)0x0041B93C, bytes, bytes.Length, new IntPtr()); // ja def_41B942 

                message("Bulldozer Mode: Off");
            }
        }

        private void SmoothLighting_CheckedChanged(object sender, EventArgs e)
        {

            if (checkAltLight.Checked)
            {
                // Unstable Lighting
                //Code injection
                byte[] bytes = { 0x50, 0xB8, 0x05, 0x00, 0x00, 0x00, 0x89, 0x87, 0x44, 0x01, 0x00, 0x00, 0x58, 0xD8, 0x1D, 0x3C, 0x73, 0x5F, 0x00, 0xE9, 0x77, 0xBB, 0xE6, 0xFF };
                checkAndWrite((IntPtr)0x005F66D0, bytes, bytes.Length, new IntPtr());
                //Jump to injection
                byte[] bytes2 = { 0xE9, 0x72, 0x44, 0x19, 0x00, 0x90 };
                checkAndWrite((IntPtr)0x00462259, bytes2, bytes2.Length, new IntPtr());

                if (this.smoothLighting.Checked == true)
                {
                    //Lighting mode 5
                    byte[] bytes3 = { 0x05 };
                    checkAndWrite((IntPtr)0x005F66D2, bytes3, bytes3.Length, new IntPtr());

                    message("Smooth Actor Lighting: On");
                }
                else
                {
                    //Lighting mode 4
                    byte[] bytes3 = { 0x04 };
                    checkAndWrite((IntPtr)0x005F66D2, bytes3, bytes3.Length, new IntPtr());

                    message("Smooth Actor Lighting: Off");
                }
            }
            else
            {

            }
        }

        private void fpsCap_CheckedChanged(object sender, EventArgs e)
        {
            /*
            label(returnhere)
            label(exit)

            "Taz.exe"+1F6700:
            // DrawFrame
            call Taz.exe+90110

            sleep1:
            // bkTimerRead__Fv
            call 005785F0
            push edx
            push eax

            mov edx,[00731338]
            mov eax,[00731334]
            push edx
            push eax

            // bkTimerDelta__FUiUi
            call 00578700
            push 0x1
            push 0x1
            push edx
            push eax
            // bkTimerToScanlines__FUiii
            call 005786B0
            add esp,0x20
            fcomp [00731330]
            fnstsw ax
            test ah,1
            jne sleep1

            exit:
            // bkTimerRead__Fv
            call 005785F0
            mov [00731338],edx
            mov [00731334],eax

            jmp returnhere

            "Taz.exe"+A77EC:
            jmp "Taz.exe"+1F6700
            returnhere:
            */
            byte[] bytes = { 0xE8, 0x0B, 0x9A, 0xE9, 0xFF, 0xE8, 0xE6, 0x1E, 0xF8, 0xFF, 0x52, 0x50, 0x8B, 0x15, 0x38, 0x13, 0x73, 0x00, 0xA1, 0x34, 0x13, 0x73, 0x00, 0x52, 0x50, 0xE8, 0xE2, 0x1F, 0xF8, 0xFF, 0x68, 0x01, 0x00, 0x00, 0x00, 0x68, 0x01, 0x00, 0x00, 0x00, 0x52, 0x50, 0xE8, 0x81, 0x1F, 0xF8, 0xFF, 0x83, 0xC4, 0x20, 0xD8, 0x1D, 0x30, 0x13, 0x73, 0x00, 0xDF, 0xE0, 0xF6, 0xC4, 0x01, 0x75, 0xC6, 0xE8, 0xAC, 0x1E, 0xF8, 0xFF, 0x89, 0x15, 0x38, 0x13, 0x73, 0x00, 0xA3, 0x34, 0x13, 0x73, 0x00, 0xE9, 0x9D, 0x10, 0xEB, 0xFF };
            checkAndWrite((IntPtr)0x005F6700, bytes, bytes.Length, new IntPtr());
            byte[] bytes2 = { 0xE9, 0x0F, 0xEF, 0x14, 0x00 };
            checkAndWrite((IntPtr)0x004A77EC, bytes2, bytes2.Length, new IntPtr());

            if (this.fpsCap.Checked == true)
            {
                float miliseconds = (1000 / (float)numericFpsCap.Value) / 1000;

                // Float delay in seconds
                byte[] bytes3 = BitConverter.GetBytes(miliseconds);
                checkAndWrite((IntPtr)0x00731330, bytes3, bytes3.Length, new IntPtr());

                message("FPS Cap: " + numericFpsCap.Value.ToString() + " Hz");
            }
            else
            {
                // 0,00
                byte[] bytes3 = { 0x00, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00731330, bytes3, bytes3.Length, new IntPtr());

                message("FPS Cap: Unlimited");
            }
        }

        private void numericFpsCap_ValueChanged(object sender, EventArgs e)
        {
            fpsCap_CheckedChanged(sender, e);
        }

        private void incFPScap()
        {
            if (this.fpsCap.Checked == true)
                numericFpsCap.UpButton();
            else
                message("FPS Cap: Unlimited (F9 to Toggle)");
        }

        private void decFPScap()
        {
            if (this.fpsCap.Checked == true)
                numericFpsCap.DownButton();
            else
                message("FPS Cap: Unlimited (F9 to Toggle)");
        }

        private void ballMode_CheckedChanged(object sender, EventArgs e)
        {
            SingleCallInitialise();

            //BallMouseTazSwitch();
            if (ballMode.Checked)
            {
                // Ball.CEA

                byte[] ballCode = { 0x68, 0x01, 0x00, 0x00, 0x00, 0x68, 0xCC, 0x70, 0x64, 0x00, 0xE8, 0xF1, 0xF1, 0xD6, 0xFF, 0x83, 0xC4, 0x08, 0x68, 0x00, 0x00, 0x00, 0x00, 0x68, 0xCC, 0x70, 0x64, 0x00, 0x68, 0x2C, 0xF7, 0x63, 0x00, 0xE8, 0x8A, 0x14, 0xD4, 0xFF, 0x83, 0xC4, 0x0C, 0x68, 0x1B, 0x00, 0x00, 0x00, 0xE8, 0x4D, 0xAC, 0xD4, 0xFF, 0x83, 0xC4, 0x04, 0x68, 0x1B, 0x00, 0x00, 0x00, 0xE8, 0xB0, 0xA8, 0xD4, 0xFF, 0x83, 0xC4, 0x04, 0xC3 };
                checkAndWrite((IntPtr)0x00731500, ballCode, ballCode.Length, new IntPtr());

                byte[] activateCheatPatch = { 0xEB, 0x0B };
                checkAndWrite((IntPtr)0x0047C077, activateCheatPatch, activateCheatPatch.Length, new IntPtr());

                byte[] deactivateCheatPatch = { 0xEB, 0x07 };
                checkAndWrite((IntPtr)0x0047C29C, deactivateCheatPatch, deactivateCheatPatch.Length, new IntPtr());

                byte[] codeInjection = { 0xE8, 0xFB, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00731400, codeInjection, codeInjection.Length, new IntPtr());

                message("Glover Ball: On");
            }
            else
            {
                // BalltoTaz.CEA
                byte[] tazCode = { 0x68, 0x1B, 0x00, 0x00, 0x00, 0xE8, 0x76, 0xAC, 0xD4, 0xFF, 0x83, 0xC4, 0x04, 0xC3 };
                checkAndWrite((IntPtr)0x00731500, tazCode, tazCode.Length, new IntPtr());

                byte[] deactivateCheatPatch = { 0xEB, 0x07 };
                checkAndWrite((IntPtr)0x0047C29C, deactivateCheatPatch, deactivateCheatPatch.Length, new IntPtr());

                byte[] codeInjection = { 0xE8, 0xFB, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00731400, codeInjection, codeInjection.Length, new IntPtr());

                message("Glover Ball: Off");
            }
        }

        private void SingleCallInitialise()
        {
            // Is already injected?
            byte[] init = { 0x00 };
            init = checkAndRead((IntPtr)0x00731400, init, 1, new IntPtr());
            if (init[0] == 0)
            {
                // Injections.CEA
                byte[] singleCallCode = { 0xE9, 0x11, 0x00, 0x00, 0x00, 0xB8, 0x11, 0x00, 0x00, 0x00, 0xA3, 0x01, 0x14, 0x73, 0x00, 0xB0, 0xE9, 0xA2, 0x00, 0x14, 0x73, 0x00, 0x68, 0xB8, 0xA0, 0x6F, 0x00, 0xE9, 0xC4, 0x63, 0xD7, 0xFF };
                checkAndWrite((IntPtr)0x00731400, singleCallCode, singleCallCode.Length, new IntPtr());

                byte[] singleCallCodeInjection = { 0xE9, 0x1C, 0x9C, 0x28, 0x00 };
                checkAndWrite((IntPtr)0x004A77DF, singleCallCodeInjection, singleCallCodeInjection.Length, new IntPtr());
            }
        }

        private void message(string message)
        {
            if (trainerText.Checked == true)
            {
                //Check text length
                if (message.Length > 33)
                {
                    message = "To Looooooooooooooooooong Message";
                }

                //Correct position of dbg text
                byte[] bytes = { 0xD1, 0xF8, 0x68, 0x80, 0x00, 0x00, 0x00, 0x83, 0xE8, 0x40, 0x90 };
                checkAndWrite((IntPtr)0x004A362B, bytes, bytes.Length, new IntPtr());

                //Copy text to dbg string 2 + 0 at end
                byte[] bytes2 = Encoding.ASCII.GetBytes(message);
                checkAndWrite((IntPtr)0x00642A94, bytes2, bytes2.Length + 1, new IntPtr());

                //Hide dbg string 2
                byte[] bytes3 = { 0x00 };
                checkAndWrite((IntPtr)0x00642A78, bytes3, bytes3.Length, new IntPtr());
                /*
                //Remove jump to show dbg text
                byte[] bytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x004A3557, bytes, 6, new IntPtr());
                */
                //Show time of dbg text (3.0)
                byte[] bytes4 = { 0x00, 0x00, 0xE0, 0x40 }; // 7.00
                checkAndWrite((IntPtr)0x00642038, bytes4, bytes4.Length, new IntPtr());

                //Restart timer
                timer.Stop();
                timer.Start();
            }

            playSound(Properties.Resources.moveselection);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            /*
            //Restore original instructions of show dbg text
            byte[] bytes = { 0x0F, 0x84, 0x17, 0x02, 0x00, 0x00 };
            checkAndWrite((IntPtr)0x004A3557, bytes, bytes.Length, new IntPtr());
            */

            //Restore show time of dbg text
            byte[] bytes4 = { 0x00, 0x00, 0x20, 0x41 }; // 10.00
            checkAndWrite((IntPtr)0x00642038, bytes4, bytes4.Length, new IntPtr());

            //Restore position of dbg text
            byte[] bytes = { 0x2B, 0xC2, 0x68, 0x80, 0x00, 0x00, 0x00, 0xD1, 0xF8, 0xF7, 0xD8 };
            checkAndWrite((IntPtr)0x004A362B, bytes, bytes.Length, new IntPtr());

            //Restore original dbg  text string 1
            byte[] bytes3 = { 0x42 };
            checkAndWrite((IntPtr)0x00642A78, bytes3, bytes3.Length, new IntPtr());

            //Restore original dbg  text string 2
            byte[] bytes2 = { 0x46, 0x6F, 0x67, 0x3A, 0x6D, 0x69, 0x6E, 0x20, 0x25, 0x64, 0x2C, 0x20, 0x6D, 0x61, 0x78, 0x20, 0x25, 0x64, 0x2C, 0x20, 0x52, 0x47, 0x42, 0x28, 0x25, 0x64, 0x2C, 0x25, 0x64, 0x2C, 0x25, 0x64, 0x29, 0x00 };
            checkAndWrite((IntPtr)0x00642A94, bytes2, bytes2.Length, new IntPtr());
        }

        //#######################################################################################################################
        //Patcher
        private string getPathFromRegistry()
        {
            //Read path from registry
            string TazPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Infogrames Interactive\TazWanted\Release", "Location", null);
            if (TazPath == null)
            {
                // Search in x86 registry
                TazPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Infogrames Interactive\TazWanted\Release", "Location", null);
            }
            if (TazPath == null)
            {
                MessageBox.Show("Unable to find Taz Wanted game path in registy. Make sure that game installed properly or select path manually in Settings tab.", "Game path not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (TazPath == "")
            {
                MessageBox.Show("Taz Wanted game path registy value is empty. Make sure that game installed properly or select path manually in Settings tab.", "Game path not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return TazPath;
        }



        private void patch_Click(object sender, EventArgs e)
        {
            try
            {

                bool backuped = false;

                //backup Taz.exe
                if (File.Exists(TazFolderPath + "\\Taz.exe.backup") == false)
                {
                    File.Copy(TazFolderPath + "\\Taz.exe", TazFolderPath + "\\Taz.exe.backup", true);
                    backuped = true;
                }

                //backup taz.dat
                if (File.Exists(TazFolderPath + "\\taz.dat.backup") == false)
                {
                    File.Copy(TazFolderPath + "\\taz.dat", TazFolderPath + "\\taz.dat.backup", true);
                    backuped = true;
                }

                //noCD 
                if (this.noCD.Checked == true)
                {
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {

                        byte[] bytes = new byte[] { 0x33, 0xC0, 0x40, 0xC3 };
                        file.Position = 0xA1F10;
                        file.WriteByte(bytes[0]);
                        file.WriteByte(bytes[1]);
                        file.WriteByte(bytes[2]);
                        file.WriteByte(bytes[3]);
                        file.Close();
                    }
                }
                else
                {
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[] { 0x81, 0xEC, 0x38, 0x01 };
                        file.Position = 0xA1F10;
                        file.WriteByte(bytes[0]);
                        file.WriteByte(bytes[1]);
                        file.WriteByte(bytes[2]);
                        file.WriteByte(bytes[3]);
                        file.Close();
                    }
                }

                //4gb
                if (this.patch4gb.Checked == true)
                {
                    //4gb patch
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x12E;
                        file.WriteByte(0x2F);
                        file.Close();
                    }
                }
                else
                {
                    //restore 2gb
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x12E;
                        file.WriteByte(0x0F);
                        file.Close();
                    }
                }

                //disable draw distance
                if (this.disableDrawDistance.Checked == true)
                {
                    //enviroment
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[] { 0xFF, 0xFF, 0xEB }; // 00 00 75
                        file.Position = 0x74FC4;
                        file.WriteByte(bytes[0]);
                        file.WriteByte(bytes[1]);
                        file.Position = 0x74FD0;
                        file.WriteByte(bytes[2]);
                        //file.Close();


                        byte[] bytes0 = { 0x00, 0x00, 0x80, 0x7F };
                        byte[] bytes1 = { 0xE8, 0x66, 0x5F, 0x00 };
                        byte[] bytes2 = { 0xD9, 0xE8, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                        file.Position = 0x1F66E8;
                        file.Write(bytes0, 0, bytes0.Length);
                        file.Position = 0x7E00B;
                        file.Write(bytes1, 0, bytes1.Length);
                        file.Position = 0x7E016;
                        file.Write(bytes2, 0, bytes2.Length);
                        file.Close();
                    }

                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //max default
                        file.Position = 0x44;
                        file.WriteByte(0xFF);
                        file.WriteByte(0xFF);
                        file.Close();
                    }
                }
                else
                {
                    //restore draw distace
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[] { 0x00, 0x00, 0x75 };
                        file.Position = 0x74FC4;
                        file.WriteByte(bytes[0]);
                        file.WriteByte(bytes[1]);
                        file.Position = 0x74FD0;
                        file.WriteByte(bytes[2]);
                        file.Close();
                    }
                    //restore effects draw distace
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes0 = { 0x00, 0x00, 0x00, 0x00 };
                        byte[] bytes1 = { 0xF4, 0x75, 0x5F, 0x00 };
                        byte[] bytes2 = { 0xD9, 0x46, 0x3C, 0xD8, 0x0D, 0xE4, 0x7E, 0x5F, 0x00, 0xD9, 0xFE };
                        file.Position = 0x1F66E8;
                        file.Write(bytes0, 0, bytes0.Length);
                        file.Position = 0x7E00B;
                        file.Write(bytes1, 0, bytes1.Length);
                        file.Position = 0x7E016;
                        file.Write(bytes2, 0, bytes2.Length);
                        file.Close();
                    }
                    //taz.dat distance max default
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x44;
                        file.WriteByte(0x30);
                        file.WriteByte(0x02);
                        file.Close();
                    }
                }

                // Fog
                // No fog
                if (this.fogComboBox.SelectedIndex == 0)
                {
                    // Restore fstp instructions
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] stock = new byte[] { 0xD9, 0x1D, 0xBC, 0x4C, 0x70, 0x00, 0xD9, 0x1D, 0xC4, 0x4C, 0x70, 0x00 };
                        file.Position = 0x8F464;
                        file.Write(stock, 0, stock.Length);
                        file.Close();
                    }
                }
                // Xbox/GameCube fog
                else if (this.fogComboBox.SelectedIndex == 1)
                {
                    // Skip fstp instructions
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] nops = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                        file.Position = 0x8F464;
                        file.Write(nops, 0, nops.Length);
                        file.Close();
                    }
                }
                // PlayStation 2 fog
                else if (this.fogComboBox.SelectedIndex == 2)
                {
                    // Skip fstp instructions
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        /*
                        label(returnhere)

                        "Taz.exe"+1F6800:
                        mov [0x00704CBC], 0x449c4000 // FogMin = 1250
                        push eax // Store eax
                        mov eax, 0x46ea6000 // eax = 30000
                        cmp eax, [0x00704CC4] // if FogMax < 30000
                        pop eax // Restore eax
                        ja returnhere // Skip FogMin and FogMax fstp
                        mov [0x00704CC4], 0x46ea6000 // FogMax = 30000
                        jmp returnhere // Skip FogMin and FogMax fstp

                        "Taz.exe"+8F464:
                        jmp "Taz.exe"+1F6800
                        nop
                        nop
                        nop
                        nop
                        nop
                        nop
                        nop
                        returnhere:
                        */

                        // Code Injection
                        byte[] injection = new byte[] { 0xC7, 0x05, 0xBC, 0x4C, 0x70, 0x00, 0x00, 0x40, 0x9C, 0x44, 0x50, 0xB8, 0x00, 0x60, 0xEA, 0x46, 0x3B, 0x05, 0xC4, 0x4C, 0x70, 0x00, 0x58, 0x0F, 0x87, 0x53, 0x8C, 0xE9, 0xFF, 0xC7, 0x05, 0xC4, 0x4C, 0x70, 0x00, 0x00, 0x60, 0xEA, 0x46, 0xE9, 0x44, 0x8C, 0xE9, 0xFF };
                        file.Position = 0x1F6800;
                        file.Write(injection, 0, injection.Length);

                        // Jump to Injection
                        byte[] jmp = new byte[] { 0xE9, 0x97, 0x73, 0x16, 0x00, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                        file.Position = 0x8F464;
                        file.Write(jmp, 0, jmp.Length);
                        file.Close();
                    }
                }

                //resolution and windowed
                if (this.changeResolution.Checked == true)
                {
                    byte[] width = BitConverter.GetBytes(UInt32.Parse(this.width.Text));
                    byte[] height = BitConverter.GetBytes(UInt32.Parse(this.height.Text));

                    // taz.dat
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //width
                        file.Position = 0x24;
                        file.WriteByte(width[0]);
                        file.WriteByte(width[1]);
                        file.WriteByte(width[2]);
                        file.WriteByte(width[3]);
                        //height
                        file.Position = 0x28;
                        file.WriteByte(height[0]);
                        file.WriteByte(height[1]);
                        file.WriteByte(height[2]);
                        file.WriteByte(height[3]);
                        //32 bits on color
                        file.Position = 0x30;
                        file.WriteByte(0x20);
                        //fullscreen
                        //file.Position = 0x34;
                        //file.WriteByte(0x00);
                        //lighting
                        //file.Position = 0x38;
                        //file.WriteByte(0x01);
                        //outlines
                        //file.Position = 0x3C;
                        //file.WriteByte(0x01);
                        //no voodoo
                        //file.Position = 0x40;
                        //file.WriteByte(0x00);
                        file.Close();
                    }

                    // Taz.exe
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //resolution in Taz.exe
                        file.Position = 0x8F134;
                        file.WriteByte(width[0]);
                        file.WriteByte(width[1]);
                        file.WriteByte(width[2]);
                        file.WriteByte(width[3]);
                        file.Position = 0x8F13E;
                        file.WriteByte(height[0]);
                        file.WriteByte(height[1]);
                        file.WriteByte(height[2]);
                        file.WriteByte(height[3]);
                        file.Close();
                    }
                    // taz.dat
                    if (this.windowed.Checked == false)
                    {
                        using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                        {
                            //fullscreen
                            file.Position = 0x34;
                            file.WriteByte(0x00);
                            file.Close();
                        }
                    }
                    else
                    {
                        using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                        {
                            //windowed
                            file.Position = 0x34;
                            file.WriteByte(0x01);
                            file.Close();
                        }
                    }
                }
                else // changeResolution.Checked == false
                {
                    //restore resolution in taz.dat
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //width
                        file.Position = 0x24;
                        file.WriteByte(0x00);
                        file.WriteByte(0x04);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        //height
                        file.Position = 0x28;
                        file.WriteByte(0x00);
                        file.WriteByte(0x03);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        //32 bits on color
                        file.Position = 0x30;
                        file.WriteByte(0x20);
                        //fullscreen
                        file.Position = 0x34;
                        file.WriteByte(0x00);
                        //lighting
                        //file.Position = 0x38;
                        //file.WriteByte(0x01);
                        //outlines
                        //file.Position = 0x3C;
                        //file.WriteByte(0x01);
                        //no voodoo
                        //file.Position = 0x40;
                        //file.WriteByte(0x00);
                        //language
                        //file.Position = 0x168;
                        //file.WriteByte(0x0);
                        file.Close();
                    }
                    //restore resolution in Taz.exe
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x8F134;
                        file.WriteByte(0x80);
                        file.WriteByte(0x02);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.Position = 0x8F13E;
                        file.WriteByte(0xE0);
                        file.WriteByte(0x01);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.Close();
                    }
                }

                //aspect ratio
                if (this.aspectRatio.Checked == true)
                {
                    byte aspect1 = Byte.Parse(this.aspect1.Text);
                    byte aspect2 = Byte.Parse(this.aspect2.Text);

                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //aspect
                        file.Position = 0x8FD76;
                        file.WriteByte(aspect1);
                        file.Position = 0x8FD7D;
                        file.WriteByte(aspect2);
                        //override widescreen
                        file.Position = 0x8F860;
                        file.WriteByte(0xB2); // mov dl,01
                        file.WriteByte(0x01);
                        file.WriteByte(0x90); // nops
                        file.WriteByte(0x90);
                        file.WriteByte(0x90);
                        file.WriteByte(0x90);

                        file.Close();
                    }
                }
                else
                {
                    //restore aspect ratio
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //4:3 aspect
                        file.Position = 0x8FD76;
                        file.WriteByte(0x04);
                        file.Position = 0x8FD7D;
                        file.WriteByte(0x03);
                        //override widescreen
                        file.Position = 0x8F860;
                        file.WriteByte(0x8A); // mov dl, byte ptr dword_6F4A38
                        file.WriteByte(0x15);
                        file.WriteByte(0x38);
                        file.WriteByte(0x4A);
                        file.WriteByte(0x6F);
                        file.WriteByte(0x00);

                        file.Close();
                    }
                }

                //texture filtering
                if (this.filtering.Checked == true)
                {
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x255E00;
                        file.WriteByte(0x01);
                        file.Position = 0x255E04;
                        file.WriteByte(0x01);
                        file.Close();
                    }
                }
                else
                {
                    //restore linear filtering
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x255E00;
                        file.WriteByte(0x02);
                        file.Position = 0x255E04;
                        file.WriteByte(0x02);
                        file.Close();
                    }
                }

                //warning banner time (Skip promo)
                if (this.skips.Checked == true)
                {
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x8F07D;
                        file.WriteByte(0x20);
                        file.WriteByte(0x00);
                        file.WriteByte(0x40);
                        file.Close();
                    }
                }
                else
                {
                    //restore warning banner time
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x8F07D;
                        file.WriteByte(0xF4);
                        file.WriteByte(0x73);
                        file.WriteByte(0x5F);
                        file.Close();
                    }
                }

                //disable videos (Skip promo)
                if (this.skips.Checked == true)
                {
                    if (Directory.Exists(TazFolderPath + "\\!Videos") == false && Directory.Exists(TazFolderPath + "\\Videos") == true)
                    {
                        Directory.Move(TazFolderPath + "\\Videos", TazFolderPath + "\\!Videos");
                    }
                }
                else
                {
                    //restore videos
                    if (Directory.Exists(TazFolderPath + "\\Videos") == false && Directory.Exists(TazFolderPath + "\\!Videos") == true)
                    {
                        Directory.Move(TazFolderPath + "\\!Videos", TazFolderPath + "/Videos");
                    }
                }

                // Mod Loader
                if (this.mods.Checked == true)
                {
                    // Create mods directory
                    if (Directory.Exists(TazFolderPath + "\\Mods") == false)
                    {
                        Directory.CreateDirectory(TazFolderPath + "\\Mods");
                    }
                    
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        // Patch search path (mods\)
                        file.Position = 0x2412C4;
                        byte[] searchpath = { 0x6D, 0x6F, 0x64, 0x73, 0x5C, 0x00, 0x00 };
                        file.Write(searchpath, 0, searchpath.Length);

                        // LoadGenericObjects Jumps
                        //file.Position = 0xD3690;
                        //byte[] ldgenobjjmp1 = { 0xEB, 0x1B };
                        //file.Write(ldgenobjjmp1, 0, ldgenobjjmp1.Length);

                        //file.Position = 0xD38F0;
                        //byte[] ldgenobjjmp2 = { 0xEB, 0x29 };
                        //file.Write(ldgenobjjmp2, 0, ldgenobjjmp2.Length);

                        //file.Position = 0xD3962;
                        //byte[] ldgenobjjmp3 = { 0xEB, 0x36 };
                        //file.Write(ldgenobjjmp3, 0, ldgenobjjmp3.Length);

                        //file.Position = 0xD39BF;
                        //file.WriteByte(0x90);

                        // LoadGenericObjects Pak names
                        //file.Position = 0xD3940;
                        //byte[] resobjoffset = { 0x44, 0x2D, 0x64, 0x00 };
                        //file.Write(resobjoffset, 0, resobjoffset.Length);

                        //file.Position = 0xD393E;
                        //file.WriteByte(0x08);

                        file.Close();
                    }
                }
                else
                {
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        // Patch search path (..\paks)
                        file.Position = 0x2412C4;
                        byte[] searchpath = { 0x2E, 0x2E, 0x5C, 0x70, 0x61, 0x6B, 0x73 };
                        file.Write(searchpath, 0, searchpath.Length);

                        // Restore LoadGenericObjects
                        file.Position = 0xD3690;
                        byte[] ldgenobjjmp1 = { 0x8B, 0x44 };
                        file.Write(ldgenobjjmp1, 0, ldgenobjjmp1.Length);

                        file.Position = 0xD38F0;
                        byte[] ldgenobjjmp2 = { 0xC3, 0x6A };
                        file.Write(ldgenobjjmp2, 0, ldgenobjjmp2.Length);

                        file.Position = 0xD3962;
                        byte[] ldgenobjjmp3 = { 0xC3, 0x6A };
                        file.Write(ldgenobjjmp3, 0, ldgenobjjmp3.Length);

                        file.Position = 0xD39BF;
                        file.WriteByte(0xC3);

                        // LoadGenericObjects Pak names
                        file.Position = 0xD3940;
                        byte[] ghostoffset = { 0xCC, 0x70, 0x64, 0x00 };
                        file.Write(ghostoffset, 0, ghostoffset.Length);

                        file.Position = 0xD393E;
                        file.WriteByte(0x00);

                        file.Close();
                    }
                }

                //voodoo
                if (this.voodoo.Checked == true)
                {
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //voodoo
                        file.Position = 0x40;
                        file.WriteByte(0x01);
                        file.Close();
                    }
                }
                else
                {
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //restore voodoo
                        file.Position = 0x40;
                        file.WriteByte(0x00);
                        file.Close();
                    }
                }

                //extra debug cheats
                if (this.extraDebug.Checked == true)
                {
                    //patch
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //set item flag
                        byte[] addeax = new byte[] { 0xB8, 0x00, 0x00, 0x00, 0x00, 0x90 };
                        file.Position = 0xA2F81;
                        file.Write(addeax, 0, addeax.Length);

                        //set last id
                        byte[] lastid = new byte[] { 0x80, 0x56, 0x00, 0x00 };
                        file.Position = 0xA2FA0;
                        file.Write(lastid, 0, lastid.Length);

                        //set callback id
                        byte[] callid = new byte[] { 0xE6 };
                        file.Position = 0xA37A2;
                        file.Write(callid, 0, callid.Length);

                        //set callback check id
                        byte[] callcheckid = new byte[] { 0xE6 };
                        file.Position = 0xA3BB3;
                        file.Write(callcheckid, 0, callcheckid.Length);

                        //deactivate max id
                        byte[] demaxid = new byte[] { 0x1E };
                        file.Position = 0x7BE4D;
                        file.Write(demaxid, 0, demaxid.Length);

                        //deactivate all max id
                        byte[] deallmaxid = new byte[] { 0x1E };
                        file.Position = 0x7C3E2;
                        file.Write(deallmaxid, 0, deallmaxid.Length);

                        //first dbg activate id
                        byte[] firstdbg = new byte[] { 0x1F };
                        file.Position = 0xA5B57;
                        file.Write(firstdbg, 0, firstdbg.Length);

                        //first dbg deactivate id
                        byte[] defirstdbg = new byte[] { 0x1F };
                        file.Position = 0xA5B97;
                        file.Write(defirstdbg, 0, defirstdbg.Length);

                        //activate cheat switch case
                        byte[] actcase = new byte[] { 0x00, 0x12, 0x12, 0x12, 0x01, 0x02, 0x03, 0x04, 0x12, 0x12, 0x05, 0x06, 0x12, 0x07, 0x12, 0x08, 0x12, 0x12, 0x12, 0x09, 0x0A, 0x12, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0x11 };
                        file.Position = 0x7C160;
                        file.Write(actcase, 0, actcase.Length);

                        //deactivate cheat switch case
                        byte[] deactcase = new byte[] { 0x00, 0x0C, 0x0C, 0x0C, 0x0C, 0x0C, 0x01, 0x01, 0x0C, 0x02, 0x0C, 0x03, 0x0C, 0x0C, 0x0C, 0x04, 0x0C, 0x05, 0x06, 0x07, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x00 };
                        file.Position = 0x7C344;
                        file.Write(deactcase, 0, deactcase.Length);

                        file.Close();
                    }
                }
                else 
                {
                    //restore
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //restore item flag
                        byte[] addeax = new byte[] { 0x83, 0xE0, 0xFE, 0x83, 0xC0, 0x02 };
                        file.Position = 0xA2F81;
                        file.Write(addeax, 0, addeax.Length);

                        //restore last id
                        byte[] lastid = new byte[] { 0xE0, 0x55, 0x00, 0x00 };
                        file.Position = 0xA2FA0;
                        file.Write(lastid, 0, lastid.Length);

                        //restore callback id
                        byte[] callid = new byte[] { 0xDE };
                        file.Position = 0xA37A2;
                        file.Write(callid, 0, callid.Length);

                        //restore callback check id
                        byte[] callcheckid = new byte[] { 0xDD };
                        file.Position = 0xA3BB3;
                        file.Write(callcheckid, 0, callcheckid.Length);

                        //restore deactivate max id
                        byte[] demaxid = new byte[] { 0x14 };
                        file.Position = 0x7BE4D;
                        file.Write(demaxid, 0, demaxid.Length);

                        //restore deactivate all max id
                        byte[] deallmaxid = new byte[] { 0x14 };
                        file.Position = 0x7C3E2;
                        file.Write(deallmaxid, 0, deallmaxid.Length);

                        //restore first dbg activate id
                        byte[] firstdbg = new byte[] { 0x15 };
                        file.Position = 0xA5B57;
                        file.Write(firstdbg, 0, firstdbg.Length);

                        //restore first dbg deactivate id
                        byte[] defirstdbg = new byte[] { 0x15 };
                        file.Position = 0xA5B97;
                        file.Write(defirstdbg, 0, defirstdbg.Length);

                        //restore activate cheat switch case
                        byte[] actcase = new byte[] { 0x00, 0x12, 0x12, 0x12, 0x01, 0x02, 0x03, 0x04, 0x12, 0x12, 0x05, 0x06, 0x12, 0x07, 0x12, 0x08, 0x12, 0x12, 0x12, 0x09, 0x12, 0x0A, 0x12, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11 };
                        file.Position = 0x7C160;
                        file.Write(actcase, 0, actcase.Length);

                        //restore deactivate cheat switch case
                        byte[] deactcase = new byte[] { 0x00, 0x0C, 0x0C, 0x0C, 0x0C, 0x0C, 0x01, 0x01, 0x0C, 0x02, 0x0C, 0x03, 0x0C, 0x0C, 0x0C, 0x04, 0x0C, 0x05, 0x06, 0x07, 0x07, 0x07, 0x08, 0x09, 0x0A, 0x0B };
                        file.Position = 0x7C344;
                        file.Write(deactcase, 0, deactcase.Length);

                        file.Close();
                    }
                }

                /*
                //xInputPatch
                if (this.xInputPatch.Checked == true)
                {
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        // Player 1 Controller Pause to Key 8, Map to Key 7
                        file.Position = 0xC8;
                        file.WriteByte(0x08);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.WriteByte(0x07);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        // Player 2 Controller Pause to Key 8, Map to Key 7
                        file.Position = 0x158;
                        file.WriteByte(0x08);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.WriteByte(0x07);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.Close();
                    }
                }
                */
                //api
                //d3d8to9
                if (apiComboBox.SelectedIndex == 1 || apiComboBox.SelectedIndex == 3)
                {
                    string d3d9Folder = Path.Combine(TazFolderPath, "Wrappers", "d3d8to9");
                    string d3d9File = Path.Combine(d3d9Folder, "d3d8.dll");
                    // Check downloaded files
                    if (File.Exists(d3d9File) == false)
                    {
                        DownloadD3D8to9();
                    }
                    // Replace dll
                    File.Copy(d3d9File, Path.Combine(TazFolderPath, "d3d8.dll"), true);
                    // Remove Vulkan's wrapper
                    if (File.Exists(Path.Combine(TazFolderPath, "d3d9.dll")) && apiComboBox.SelectedIndex != 3)
                        File.Delete(Path.Combine(TazFolderPath, "d3d9.dll"));
                }
                //dgVoodoo2
                else if (apiComboBox.SelectedIndex == 2)
                {
                    string d3d11Folder = Path.Combine(TazFolderPath, "Wrappers", "dgVoodoo2");
                    string d3d11File = Path.Combine(d3d11Folder, "d3d8.dll");
                    string d3d11Zip = Path.Combine(d3d11Folder, "dgVoodoo2.zip");
                    // Check downloaded files
                    if (File.Exists(d3d11File) == false)
                    {
                        DownloadDgVoodoo2();
                    }
                    // Replace dll
                    File.Copy(d3d11File, Path.Combine(TazFolderPath, "d3d8.dll"), true);
                    // Remove Vulkan's wrapper
                    if (File.Exists(Path.Combine(TazFolderPath, "d3d9.dll")))
                        File.Delete(Path.Combine(TazFolderPath, "d3d9.dll"));
                }
                //Vanilla
                else
                {
                    // Remove d3d8 wrapper
                    if (File.Exists(Path.Combine(TazFolderPath, "d3d8.dll")))
                        File.Delete(Path.Combine(TazFolderPath, "d3d8.dll"));
                    // Remove Vulkan's wrapper
                    if (File.Exists(Path.Combine(TazFolderPath, "d3d9.dll")))
                        File.Delete(Path.Combine(TazFolderPath, "d3d9.dll"));
                }

                //dxvk
                if (apiComboBox.SelectedIndex == 3)
                {
                    string VulkanFolder = Path.Combine(TazFolderPath, "Wrappers", "dxvk");
                    string VulkanFile = Path.Combine(VulkanFolder, "d3d9.dll");
                    string VulkanTar = Path.Combine(VulkanFolder, "dxvk.tar.gz");
                    // Check downloaded files
                    if (File.Exists(VulkanFile) == false)
                    {
                        DownloadDxVk();
                    }
                    // Replace dll
                    File.Copy(VulkanFile, Path.Combine(TazFolderPath, "d3d9.dll"), true);
                }

                //language
                // If language not Russian
                if (langComboBox.SelectedIndex >= 0 && langComboBox.SelectedIndex <= 4)
                {
                    // Check lang files
                    if (File.Exists(TazFolderPath + "\\Paks\\text.pc.backup") == true && File.Exists(TazFolderPath + "\\Paks\\resTex.pc.backup") == true && File.Exists(TazFolderPath + "\\Paks\\text.pc") == true && File.Exists(TazFolderPath + "\\Paks\\resTex.pc") == true)
                    {
                        //Restore to original
                        File.Delete(TazFolderPath + "\\Paks\\text.pc");
                        File.Delete(TazFolderPath + "\\Paks\\resTex.pc");
                        File.Copy(TazFolderPath + "\\Paks\\text.pc.backup", TazFolderPath + "\\Paks\\text.pc", true);
                        File.Copy(TazFolderPath + "\\Paks\\resTex.pc.backup", TazFolderPath + "\\Paks\\resTex.pc", true);
                        File.Delete(TazFolderPath + "\\Paks\\text.pc.backup");
                        File.Delete(TazFolderPath + "\\Paks\\resTex.pc.backup");
                    }
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x168;
                        file.WriteByte((Byte)langComboBox.SelectedIndex);
                        file.Close();
                    }
                }
                // If language is Russian
                else if (langComboBox.SelectedIndex == 5)
                {
                    // Check files
                    if (File.Exists(TazFolderPath + "\\Paks\\text.pc") == true && File.Exists(TazFolderPath + "\\Paks\\resTex.pc") == true && !File.Exists(TazFolderPath + "\\Paks\\text.pc.backup") == true && !File.Exists(TazFolderPath + "\\Paks\\resTex.pc.backup") == true)
                    {
                        // Backup files
                        File.Copy(TazFolderPath + "\\Paks\\text.pc", TazFolderPath + "\\Paks\\text.pc.backup", true);
                        File.Copy(TazFolderPath + "\\Paks\\resTex.pc", TazFolderPath + "\\Paks\\resTex.pc.backup", true);
                        // Replace files
                        File.WriteAllBytes(TazFolderPath + "\\Paks\\text.pc", Properties.Resources.text);
                        File.WriteAllBytes(TazFolderPath + "\\Paks\\resTex.pc", Properties.Resources.resTex);
                        // Force modded english lang
                        using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                        {
                            file.Position = 0x168;
                            file.WriteByte(0x0);
                            file.Close();
                        }
                    }
                }

                //layout
                // Vanilla = 0 (Do Nothing)
                // XInput
                if (layoutComboBox.SelectedIndex == 1)
                {
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] xinput = new byte[] { 0x21, 0x00, 0x00, 0x00, 0x21, 0x00, 0x00, 0x00, 0x22, 0x00, 0x00, 0x00, 0x22, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x23, 0x00, 0x00, 0x00, 0x23, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        // Player 1
                        file.Position = 0x98;
                        file.Write(xinput, 0, xinput.Length);
                        // Player 2
                        file.Position = 0x128;
                        file.Write(xinput, 0, xinput.Length);

                        file.Close();
                    }
                }
                // DualShock 4
                else if (layoutComboBox.SelectedIndex == 2)
                {
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] ds4 = new byte[] { 0x21, 0x00, 0x00, 0x00, 0x21, 0x00, 0x00, 0x00, 0x22, 0x00, 0x00, 0x00, 0x22, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        // Player 1
                        file.Position = 0x98;
                        file.Write(ds4, 0, ds4.Length);
                        // Player 2
                        file.Position = 0x128;
                        file.Write(ds4, 0, ds4.Length);

                        file.Close();
                    }
                }


                //end
                this.statusField.Text = "Patched successfully (" + TazFolderPath + ")";
                if (backuped == true)
                {
                    this.statusField.Text += " and created backup of Taz.exe";
                }
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                //MessageBox.Show("Patched successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }


        private void restore_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("This will restore all game options and mods to default. Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Check backup
                    if (File.Exists(TazFolderPath + "\\Taz.exe.backup") == true)
                    {
                        //Replace
                        File.Delete(TazFolderPath + "\\Taz.exe");
                        File.Copy(TazFolderPath + "\\Taz.exe.backup", TazFolderPath + "\\Taz.exe", true);
                    }
                    else
                    {
                        this.statusField.Text = "Taz.exe.backup not found!";
                        this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                    }

                    //Check and restore language backup
                    if (File.Exists(TazFolderPath + "\\Paks\\text.pc.backup") == true && File.Exists(TazFolderPath + "\\Paks\\resTex.pc.backup") == true && File.Exists(TazFolderPath + "\\Paks\\text.pc") == true && File.Exists(TazFolderPath + "\\Paks\\resTex.pc") == true)
                    {
                        //Restore to original
                        File.Delete(TazFolderPath + "\\Paks\\text.pc");
                        File.Delete(TazFolderPath + "\\Paks\\resTex.pc");
                        File.Copy(TazFolderPath + "\\Paks\\text.pc.backup", TazFolderPath + "\\Paks\\text.pc", true);
                        File.Copy(TazFolderPath + "\\Paks\\resTex.pc.backup", TazFolderPath + "\\Paks\\resTex.pc", true);
                        File.Delete(TazFolderPath + "\\Paks\\text.pc.backup");
                        File.Delete(TazFolderPath + "\\Paks\\resTex.pc.backup");
                    }

                    //Check and restore taz.dat backup
                    if (File.Exists(TazFolderPath + "\\taz.dat.backup") == true)
                    {
                        //Replace
                        File.Delete(TazFolderPath + "\\taz.dat");
                        File.Copy(TazFolderPath + "\\taz.dat.backup", TazFolderPath + "\\taz.dat", true);
                    }
                    else
                    {
                        this.statusField.Text = "taz.dat.backup not found!";
                        this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    //Check and restore wrappers
                    // Remove d3d8 wrapper
                    if (File.Exists(Path.Combine(TazFolderPath, "d3d8.dll")))
                        File.Delete(Path.Combine(TazFolderPath, "d3d8.dll"));
                    // Remove Vulkan's wrapper
                    if (File.Exists(Path.Combine(TazFolderPath, "d3d9.dll")))
                        File.Delete(Path.Combine(TazFolderPath, "d3d9.dll"));
                    //restore videos
                    if (Directory.Exists(TazFolderPath + "\\Videos") == false && Directory.Exists(TazFolderPath + "\\!Videos") == true)
                        Directory.Move(TazFolderPath + "\\!Videos", TazFolderPath + "/Videos");
                    //restore end
                    this.statusField.Text = "Restored successfully (" + TazFolderPath + ")";
                    this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        //#######################################################################################################################
        //GUI

        private void aspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.aspectRatio.Checked == true)
            {
                this.aspect1.Enabled = true;
                this.pointsLabel.Enabled = true;
                this.aspect2.Enabled = true;
            }
            else
            {
                this.aspect1.Enabled = false;
                this.pointsLabel.Enabled = false;
                this.aspect2.Enabled = false;
            }
        }

        private void changeResolution_CheckedChanged(object sender, EventArgs e)
        {
            if (this.changeResolution.Checked == true)
            {
                this.windowed.Enabled = true;
                this.height.Enabled = true;
                this.xLabel.Enabled = true;
                this.width.Enabled = true;
                this.aspectRatio.Checked = true;
            }
            else
            {
                this.windowed.Enabled = false;
                this.windowed.Checked = false;
                this.height.Enabled = false;
                this.xLabel.Enabled = false;
                this.width.Enabled = false;
                this.aspectRatio.Checked = false;
            }
        }

        private void windowed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.windowed.Checked == false)
            {
                autoFillVideo(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                this.voodoo.Enabled = true;
            }
            else
            {
                this.voodoo.Enabled = false;
                this.voodoo.Checked = false;
            }
        }

        private void launcher_Click(object sender, EventArgs e)
        {
            try
            {
                string TazExecPath = '"' + TazFolderPath + "\\TazLauncher.exe" + '"' /*+ "Forced"*/;
                Process.Start(TazExecPath, "Forced");
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void video_Click(object sender, EventArgs e)
        {
            try
            {
                string TazConfigPath = TazFolderPath + "\\config.exe";
                Process.Start(TazConfigPath, "graphics " + "0"); //langComboBox.SelectedIndex.ToString());
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void audio_Click(object sender, EventArgs e)
        {
            try
            {
                string TazControlsPath = TazFolderPath + "\\config.exe";
                Process.Start(TazControlsPath, "sound " + "0"); //langComboBox.SelectedIndex.ToString());
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void controls_Click(object sender, EventArgs e)
        {
            try
            {
                string TazControlsPath = TazFolderPath + "\\config.exe";
                Process.Start(TazControlsPath, "control " + "0"); //langComboBox.SelectedIndex.ToString());
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void gameFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", TazFolderPath);
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void executable_Click(object sender, EventArgs e)
        {
            string TazExecPath = TazFolderPath + "\\Taz.exe";
            Process.Start(TazExecPath, "Launched");
        }

        private void play_Click(object sender, EventArgs e)
        {
            try
            {
                patch_Click(sender, e);
                if (statusField.Text.Contains("taz.dat") == false)
                    executable_Click(sender, e);
                else
                    MessageBox.Show("Game config file not found. Launch game via native launcher (Settings -> Shortcuts -> Launcher) to create config, then restart game via patcher.", "File taz.dat not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void tabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabs.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void applyRegistry_Click(object sender, EventArgs e)
        {
            try
            {
                // Check path attributes
                FileAttributes attr = File.GetAttributes(textBoxRegistry.Text);

                // If its a file, remove last filename
                if (!attr.HasFlag(FileAttributes.Directory))
                    textBoxRegistry.Text = Path.GetDirectoryName(textBoxRegistry.Text);

                // Clear slash at the end
                while (textBoxRegistry.Text.EndsWith("\\"))
                    textBoxRegistry.Text = textBoxRegistry.Text.Remove(textBoxRegistry.Text.Length - 1, 1);

                // Check path
                Path.GetFullPath(textBoxRegistry.Text);

                // Checks ok
                TazFolderPath = textBoxRegistry.Text;

                // Set registry value for x64 (needs admin privilegies)
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Infogrames Interactive\TazWanted\Release", "Location", TazFolderPath);
                // Set registry value for x86 (needs admin privilegies)
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Infogrames Interactive\TazWanted\Release", "Location", TazFolderPath);

                this.statusField.Text = "Registry game path successfully set to: " + TazFolderPath;
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                if (ex.TargetSite.MetadataToken == 100663603)
                    MessageBox.Show("This operation needs Administrative Mode. Try relaunch app as administrator.", "No permissions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void browseGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxRegistry.Text = folderBrowserDialog.SelectedPath;
                    applyRegistry.PerformClick();
                }
                /*
                // CommonOpenFileDialog instead of standard FolderBrowserDialog (needs WindowsAPICodePack-Shell from NuGet)
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    textBoxRegistry.Text = dialog.FileName;
                    applyRegistry.PerformClick();
                }
                */
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void githubLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MuxaJlbl4/Taz_Wanted_trainer_and_patcher");
        }
        /*
        private void gkhLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jparnell8839/globalKeyboardHook");
        }

        private void d3d8to9Link_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/crosire/d3d8to9");
        }

        private void qbmsLink_Click(object sender, EventArgs e)
        {
            Process.Start("http://aluigi.altervista.org/quickbms.htm");
        }
        private void fsLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Skkay/FormSerialisor");
        }
        private void symbols_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.retroreversing.com/ps2-demos/#list-of-games-available-with-debug-symbols");
        }
        */
        private void savePatcherSettings_Click(object sender, EventArgs e)
        {
            try
            {
                FormSerialisor.Serialise(this, TazFolderPath + @"\Patcher.xml");
                this.statusField.Text = "App settings successfully saved to: " + TazFolderPath + @"\Patcher.xml";
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void UnpackPak(String fileName, String OutputPath)
        {
            // Create New Folder
            OutputPath = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(fileName));
            Directory.CreateDirectory(OutputPath);
            // Open file
            byte[] pakFile = File.ReadAllBytes(fileName);
            //Parse Header
            //Int32 TimeStamp =       BitConverter.ToInt32(pakFile, 0x00);
            Int32 PakAlign = BitConverter.ToInt32(pakFile, 0x04);
            //Int32 Sound =          BitConverter.ToInt32(pakFile, 0x08);
            Int32 FilesCount = BitConverter.ToInt32(pakFile, 0x0C);
            Int32 InfoOffset = BitConverter.ToInt32(pakFile, 0x10) * PakAlign;
            //Int32 TagOffset =       BitConverter.ToInt32(pakFile, 0x14) * PakAlign;
            //Int32 Zero0 =           BitConverter.ToInt32(pakFile, 0x18);
            //Int32 TagCount =          BitConverter.ToInt32(pakFile, 0x1C);
            //Int32 FootOffset =      BitConverter.ToInt32(pakFile, 0x20) * PakAlign;
            //Int32 Dummy =          BitConverter.ToInt32(pakFile, 0x24);
            Int32 NamesOffset = BitConverter.ToInt32(pakFile, 0x28) * PakAlign;
            Int32 NamesSize = BitConverter.ToInt32(pakFile, 0x2C);
            //Int32 InfoSize =        BitConverter.ToInt32(pakFile, 0x30);
            //Int32 Zero1 =            BitConverter.ToInt32(pakFile, 0x34);
            //Int32 SixtyFour =       BitConverter.ToInt32(pakFile, 0x38);

            // Log Info to Desktop File
            //ASCIIEncoding asciiTag = new ASCIIEncoding();
            //File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Info"), TimeStamp.ToString() + "\t" + Sound.ToString() + "\t" + Zero0.ToString() + "\t" + TagCount.ToString() + "\t" + Dummy.ToString() + "\t" + Zero1.ToString() + "\t" + SixtyFour.ToString() + "\t" + asciiTag.GetString(pakFile, TagOffset, 16) + "\t" + Path.GetFileNameWithoutExtension(fileName) + "\n");

            //Parse Files
            for (Int32 i = 0; i < FilesCount; i++)
            {
                Int32 Base = (i * 32) + InfoOffset;
                // Parse File Info
                Int32 Offset = BitConverter.ToInt32(pakFile, Base + 0x00) * PakAlign;
                //Int32 Hash32 =      BitConverter.ToInt32(pakFile, Base + 0x04);
                Int32 Size = BitConverter.ToInt32(pakFile, Base + 0x08);
                Int32 NameOffset = BitConverter.ToInt32(pakFile, Base + 0x0C);
                Int32 IsFile = BitConverter.ToInt32(pakFile, Base + 0x10);
                //Int32 Zero =        BitConverter.ToInt32(pakFile, Base + 0x14);
                //Int64 Hash64 =      BitConverter.ToInt64(pakFile, Base + 0x18);

                // Is it file
                if (IsFile == 0 && Size == NamesSize)
                    continue;

                // Get Name
                string FileName = "";
                Int32 StrOffset = NamesOffset + NameOffset;
                Int32 StrLen = Array.IndexOf(pakFile, (byte)0, StrOffset) - StrOffset;
                ASCIIEncoding ascii = new ASCIIEncoding();
                FileName = ascii.GetString(pakFile, StrOffset, StrLen);

                // Log Hashes to Desktop File
                //File.AppendAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Hashes"), FileName + "\t" + Hash32.ToString("X4") + "\n");
                // Save Hashes to Dictionary
                //if (!Hashes.ContainsKey(FileName)) Hashes.Add(FileName, Hash32);

                // Check Subfolders
                string FilePath = Path.Combine(OutputPath, Path.GetDirectoryName(FileName));
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);

                // Get Content
                byte[] Content = new byte[Size];
                Content = pakFile.Skip(Offset).Take(Size).ToArray();
                // Unpack to File
                File.WriteAllBytes(Path.Combine(FilePath, Path.GetFileName(FileName)), Content);
            }
        }

        private void PackPak(String DirName, String OutputName)
        {
            /*
            // Deserialize Hashes
            Dictionary<string, UInt32> Hashes = new Dictionary<string, UInt32>();
            byte[] hashbin = Properties.Resources.Hashes;
            Stream hashstream = new MemoryStream(hashbin);
            using (hashstream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Hashes = (Dictionary<string, UInt32>)formatter.Deserialize(hashstream);
            }
            */

            // Init
            //Dictionary<string, UInt32> Hashes = new Dictionary<string, UInt32>();
            byte[] Header = { };
            byte[] Contents = { };
            byte[] FileNames = { };
            byte[] FileInfos = { };
            byte[] Footer = { };
            Dictionary<string, Int32> FileContentLocalOffsets = new Dictionary<string, Int32>();
            Dictionary<string, Int32> FileNameLocalOffsets = new Dictionary<string, Int32>();
            int HiddenFileHash = 881391266;
            int FileLocalOffset = 0;
            int NameLocalOffset = 0;
            int TagLocalOffset = 0;
            int TagCount = 0;
            int Remainder = 0;
            int FileSize = 0;
            int NamesSize = 0;
            int NamesRealSize = 0;
            int HiddenFileInfoLocalIndex = 0;
            int HeaderSize = 2048;
            int FooterSize = 32;
            // Read files (Exclude .pak.sys)
            //var Files = Directory.GetFiles(folderResourceBrowserDialog.SelectedPath, "*", SearchOption.AllDirectories).Where(name => !name.EndsWith(".pak.sys")).ToArray();
            // Sort Test
            //Files = Files.Reverse().ToArray();
            // Tags to end
            //string TagName = Path.Combine(folderResourceBrowserDialog.SelectedPath, "TagTable.pak.sys");
            //Files = Files.Append(TagName).ToArray();

            string[] Files = Directory.GetFiles(DirName, "*", SearchOption.AllDirectories).ToArray();

            // Append Hidden File
            Files = Files.Append("").ToArray();
            // Sort by Hashes
            UInt32[] UsedHashes = { };
            foreach (string FullName in Files)
            {
                string ShortName = FullName.Replace(DirName + "\\", "");
                NamesSize += ShortName.Length + 1;
                if (ShortName == "")
                    // Append Hidden File Hash (Without Name)
                    UsedHashes = UsedHashes.Append((UInt32)HiddenFileHash).ToArray();
                else
                    UsedHashes = UsedHashes.Append(CRC32.Crc32(Encoding.ASCII.GetBytes(ShortName.ToLower()))).ToArray();
            }


            Array.Sort(UsedHashes, Files);


            // Content + Names + Infos
            foreach (string FilePath in Files)
            {
                // Get Short Name
                string ShortName = FilePath.Replace(DirName + "\\", "");

                // Is Hidden
                if (ShortName == "")
                {
                    HiddenFileInfoLocalIndex = FileInfos.Length;
                    // Allocate Hidden FileNames File Info
                    Array.Resize<byte>(ref FileInfos, FileInfos.Length + 32);
                    continue;
                }

                // RawContent
                byte[] FileContent = File.ReadAllBytes(FilePath);
                FileSize = FileContent.Length;
                // + Alignment
                Remainder = FileContent.Length % 16;
                if (Remainder > 0) for (int i = 0; i < 16 - Remainder; i++) FileContent = FileContent.Append((byte)0).ToArray();
                // Append Content
                Contents = Contents.Concat(FileContent).ToArray();


                // FileNames
                FileNames = FileNames.Concat(Encoding.ASCII.GetBytes(ShortName)).ToArray();
                FileNames = FileNames.Append((byte)0).ToArray();


                // FileInfos
                // Global File Offset (\16)
                FileInfos = FileInfos.Concat(BitConverter.GetBytes((HeaderSize + FileLocalOffset) / 16)).ToArray();
                // Hash32
                FileInfos = FileInfos.Concat(BitConverter.GetBytes(CRC32.Crc32(Encoding.ASCII.GetBytes(ShortName.ToLower())))).ToArray();
                // Size
                FileInfos = FileInfos.Concat(BitConverter.GetBytes(FileSize)).ToArray();
                // Local Name Offset
                FileInfos = FileInfos.Concat(BitConverter.GetBytes(NameLocalOffset)).ToArray();
                // Is File + Some Tag Info
                if (ShortName == "TagTable.pak.sys")
                {
                    FileInfos = FileInfos.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
                    TagLocalOffset = FileLocalOffset;
                    TagCount = FileSize / 4;
                }
                else
                    FileInfos = FileInfos.Concat(BitConverter.GetBytes((Int32)1)).ToArray();
                // Zeroes
                FileInfos = FileInfos.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
                FileInfos = FileInfos.Concat(BitConverter.GetBytes((Int64)0)).ToArray();


                // Next Local Offsets
                FileLocalOffset += FileContent.Length;
                NameLocalOffset += ShortName.Length + 1;
            }


            // + Alignment for FileNames
            NamesRealSize = NameLocalOffset;
            Remainder = NameLocalOffset % 16;
            if (Remainder > 0) for (int i = 0; i < 16 - Remainder; i++) FileNames = FileNames.Append((byte)0).ToArray();


            // Add Hidden FileNames File Info
            byte[] HiddenFileInfos = { };
            HiddenFileInfos = HiddenFileInfos.Concat(BitConverter.GetBytes((HeaderSize + Contents.Length) / 16)).ToArray(); // FileInfo
            HiddenFileInfos = HiddenFileInfos.Concat(BitConverter.GetBytes(HiddenFileHash)).ToArray(); // Hash32
            HiddenFileInfos = HiddenFileInfos.Concat(BitConverter.GetBytes(NameLocalOffset)).ToArray(); // Size
            HiddenFileInfos = HiddenFileInfos.Concat(BitConverter.GetBytes(NameLocalOffset)).ToArray(); // Local Name Offset
            HiddenFileInfos = HiddenFileInfos.Concat(BitConverter.GetBytes((Int32)0)).ToArray(); // Is File
            HiddenFileInfos = HiddenFileInfos.Concat(BitConverter.GetBytes((Int32)0)).ToArray(); // Zeroes
            HiddenFileInfos = HiddenFileInfos.Concat(BitConverter.GetBytes((Int64)0)).ToArray(); // Zeroes
            Array.Copy(HiddenFileInfos, 0, FileInfos, HiddenFileInfoLocalIndex, HiddenFileInfos.Length);


            // Footer
            // Offset
            Footer = Footer.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
            // PakSize (\16)
            Footer = Footer.Concat(BitConverter.GetBytes((HeaderSize + Contents.Length + FileNames.Length + FileInfos.Length + FooterSize) / 16)).ToArray();
            // One
            Footer = Footer.Concat(BitConverter.GetBytes((Int32)1)).ToArray();
            // Zeroes
            Footer = Footer.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
            Footer = Footer.Concat(BitConverter.GetBytes((Int64)0)).ToArray();
            Footer = Footer.Concat(BitConverter.GetBytes((Int64)0)).ToArray();

            // Header
            // TimeStamp
            Header = Header.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
            // Align
            Header = Header.Concat(BitConverter.GetBytes((Int32)16)).ToArray();
            // Sound
            if (Path.GetDirectoryName(DirName).Contains("sound") || Path.GetDirectoryName(DirName).Contains("Sound"))
                Header = Header.Concat(BitConverter.GetBytes((Int32)1)).ToArray();
            else
                Header = Header.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
            // Files Count (+1 Hidden)
            Header = Header.Concat(BitConverter.GetBytes(Files.Length)).ToArray();
            // Info Offset (/16)
            Header = Header.Concat(BitConverter.GetBytes((HeaderSize + Contents.Length + FileNames.Length) / 16)).ToArray();
            // Tag Offset (/16)
            Header = Header.Concat(BitConverter.GetBytes((HeaderSize + TagLocalOffset) / 16)).ToArray();
            // Zero0
            Header = Header.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
            // TagCount
            Header = Header.Concat(BitConverter.GetBytes(TagCount)).ToArray();
            // FootOffset (/16)
            Header = Header.Concat(BitConverter.GetBytes((HeaderSize + Contents.Length + FileNames.Length + FileInfos.Length) / 16)).ToArray();
            // Dummy
            Header = Header.Concat(BitConverter.GetBytes((Int32)1)).ToArray();
            // Names Offset (/16)
            Header = Header.Concat(BitConverter.GetBytes((HeaderSize + Contents.Length) / 16)).ToArray();
            // Names Size
            Header = Header.Concat(BitConverter.GetBytes(NamesRealSize)).ToArray();
            // Info Size
            Header = Header.Concat(BitConverter.GetBytes(FileInfos.Length)).ToArray();
            // Zero1
            Header = Header.Concat(BitConverter.GetBytes((Int32)0)).ToArray();
            // 64
            Header = Header.Concat(BitConverter.GetBytes((Int32)64)).ToArray();
            // Zeroes
            Array.Resize<byte>(ref Header, 2048);


            // Final Concat
            byte[] RepackedFile = { };
            RepackedFile = RepackedFile.Concat(Header).ToArray();
            RepackedFile = RepackedFile.Concat(Contents).ToArray();
            RepackedFile = RepackedFile.Concat(FileNames).ToArray();
            RepackedFile = RepackedFile.Concat(FileInfos).ToArray();
            RepackedFile = RepackedFile.Concat(Footer).ToArray();

            // WriteOut
            Directory.CreateDirectory(Path.GetDirectoryName(OutputName));
            File.WriteAllBytes(OutputName, RepackedFile);


        }

        public static class CRC32
        {
            private static readonly uint[] crc_table =
                {
            0x00000000, 0x04c11db7, 0x09823b6e, 0x0d4326d9, 0x130476dc, 0x17c56b6b, 0x1a864db2, 0x1e475005,
            0x2608edb8, 0x22c9f00f, 0x2f8ad6d6, 0x2b4bcb61, 0x350c9b64, 0x31cd86d3, 0x3c8ea00a, 0x384fbdbd,
            0x4c11db70, 0x48d0c6c7, 0x4593e01e, 0x4152fda9, 0x5f15adac, 0x5bd4b01b, 0x569796c2, 0x52568b75,
            0x6a1936c8, 0x6ed82b7f, 0x639b0da6, 0x675a1011, 0x791d4014, 0x7ddc5da3, 0x709f7b7a, 0x745e66cd,
            0x9823b6e0, 0x9ce2ab57, 0x91a18d8e, 0x95609039, 0x8b27c03c, 0x8fe6dd8b, 0x82a5fb52, 0x8664e6e5,
            0xbe2b5b58, 0xbaea46ef, 0xb7a96036, 0xb3687d81, 0xad2f2d84, 0xa9ee3033, 0xa4ad16ea, 0xa06c0b5d,
            0xd4326d90, 0xd0f37027, 0xddb056fe, 0xd9714b49, 0xc7361b4c, 0xc3f706fb, 0xceb42022, 0xca753d95,
            0xf23a8028, 0xf6fb9d9f, 0xfbb8bb46, 0xff79a6f1, 0xe13ef6f4, 0xe5ffeb43, 0xe8bccd9a, 0xec7dd02d,
            0x34867077, 0x30476dc0, 0x3d044b19, 0x39c556ae, 0x278206ab, 0x23431b1c, 0x2e003dc5, 0x2ac12072,
            0x128e9dcf, 0x164f8078, 0x1b0ca6a1, 0x1fcdbb16, 0x018aeb13, 0x054bf6a4, 0x0808d07d, 0x0cc9cdca,
            0x7897ab07, 0x7c56b6b0, 0x71159069, 0x75d48dde, 0x6b93dddb, 0x6f52c06c, 0x6211e6b5, 0x66d0fb02,
            0x5e9f46bf, 0x5a5e5b08, 0x571d7dd1, 0x53dc6066, 0x4d9b3063, 0x495a2dd4, 0x44190b0d, 0x40d816ba,
            0xaca5c697, 0xa864db20, 0xa527fdf9, 0xa1e6e04e, 0xbfa1b04b, 0xbb60adfc, 0xb6238b25, 0xb2e29692,
            0x8aad2b2f, 0x8e6c3698, 0x832f1041, 0x87ee0df6, 0x99a95df3, 0x9d684044, 0x902b669d, 0x94ea7b2a,
            0xe0b41de7, 0xe4750050, 0xe9362689, 0xedf73b3e, 0xf3b06b3b, 0xf771768c, 0xfa325055, 0xfef34de2,
            0xc6bcf05f, 0xc27dede8, 0xcf3ecb31, 0xcbffd686, 0xd5b88683, 0xd1799b34, 0xdc3abded, 0xd8fba05a,
            0x690ce0ee, 0x6dcdfd59, 0x608edb80, 0x644fc637, 0x7a089632, 0x7ec98b85, 0x738aad5c, 0x774bb0eb,
            0x4f040d56, 0x4bc510e1, 0x46863638, 0x42472b8f, 0x5c007b8a, 0x58c1663d, 0x558240e4, 0x51435d53,
            0x251d3b9e, 0x21dc2629, 0x2c9f00f0, 0x285e1d47, 0x36194d42, 0x32d850f5, 0x3f9b762c, 0x3b5a6b9b,
            0x0315d626, 0x07d4cb91, 0x0a97ed48, 0x0e56f0ff, 0x1011a0fa, 0x14d0bd4d, 0x19939b94, 0x1d528623,
            0xf12f560e, 0xf5ee4bb9, 0xf8ad6d60, 0xfc6c70d7, 0xe22b20d2, 0xe6ea3d65, 0xeba91bbc, 0xef68060b,
            0xd727bbb6, 0xd3e6a601, 0xdea580d8, 0xda649d6f, 0xc423cd6a, 0xc0e2d0dd, 0xcda1f604, 0xc960ebb3,
            0xbd3e8d7e, 0xb9ff90c9, 0xb4bcb610, 0xb07daba7, 0xae3afba2, 0xaafbe615, 0xa7b8c0cc, 0xa379dd7b,
            0x9b3660c6, 0x9ff77d71, 0x92b45ba8, 0x9675461f, 0x8832161a, 0x8cf30bad, 0x81b02d74, 0x857130c3,
            0x5d8a9099, 0x594b8d2e, 0x5408abf7, 0x50c9b640, 0x4e8ee645, 0x4a4ffbf2, 0x470cdd2b, 0x43cdc09c,
            0x7b827d21, 0x7f436096, 0x7200464f, 0x76c15bf8, 0x68860bfd, 0x6c47164a, 0x61043093, 0x65c52d24,
            0x119b4be9, 0x155a565e, 0x18197087, 0x1cd86d30, 0x029f3d35, 0x065e2082, 0x0b1d065b, 0x0fdc1bec,
            0x3793a651, 0x3352bbe6, 0x3e119d3f, 0x3ad08088, 0x2497d08d, 0x2056cd3a, 0x2d15ebe3, 0x29d4f654,
            0xc5a92679, 0xc1683bce, 0xcc2b1d17, 0xc8ea00a0, 0xd6ad50a5, 0xd26c4d12, 0xdf2f6bcb, 0xdbee767c,
            0xe3a1cbc1, 0xe760d676, 0xea23f0af, 0xeee2ed18, 0xf0a5bd1d, 0xf464a0aa, 0xf9278673, 0xfde69bc4,
            0x89b8fd09, 0x8d79e0be, 0x803ac667, 0x84fbdbd0, 0x9abc8bd5, 0x9e7d9662, 0x933eb0bb, 0x97ffad0c,
            0xafb010b1, 0xab710d06, 0xa6322bdf, 0xa2f33668, 0xbcb4666d, 0xb8757bda, 0xb5365d03, 0xb1f740b4
        };
            public static uint Crc32(byte[] data)
            {
                uint crc = 0x00000000;

                for (int i = 0; i < data.Length; i++)
                    crc = (crc << 8) ^ crc_table[((crc >> 24) ^ data[i]) & 0xff];

                return crc;
            }
        }

        private void unpack_Click(object sender, EventArgs e)
        {
            try
            {
                if (openPakFileDialog.ShowDialog() == DialogResult.OK && saveUnpackedFilesDialog.ShowDialog() == DialogResult.OK)
                {
                    this.statusField.Text = "Unpacking started and can take much time. It's Ok if app looks like not responding";
                    this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                    progressBar.Value = 0;
                    progressBar.Maximum = openPakFileDialog.FileNames.Length;
                    foreach (String fileName in openPakFileDialog.FileNames)
                    {
                        UnpackPak(fileName, Path.GetDirectoryName(saveUnpackedFilesDialog.FileName));
                        progressBar.Value += 1;
                        this.statusField.Text = fileName + " unpacked ( " + progressBar.Value.ToString() + " / " + progressBar.Maximum.ToString() + " )";
                        this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    this.statusField.Text = "Unpacking finished";
                    this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void pack_Click(object sender, EventArgs e)
        {
            /*
            // Serialize Hashes
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Hashes.bin"), FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, Hashes);
            }
            */


            /*
            UInt32[] Hshs = { };
            string[] Nms = { };
            foreach (KeyValuePair<string, UInt32> Element in Hashes)
            {
                Hshs = Hshs.Append(Element.Value).ToArray();
                Nms = Nms.Append(Element.Key).ToArray();
            }
            Array.Sort(Hshs, Nms);
            Dictionary<string, UInt32> NewHashes = new Dictionary<string, UInt32>();
            */


            try
            {
                // Choose Dir
                if (folderResourceBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //string Output = Path.Combine(Application.StartupPath, "RepackedPaks");
                    //Output = Path.Combine(Output, Path.GetFileName(folderResourceBrowserDialog.SelectedPath) + ".pc");

                    saveRepackedFileDialog.FileName = Path.GetFileName(folderResourceBrowserDialog.SelectedPath) + ".pc";

                    if (saveRepackedFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string Output = saveRepackedFileDialog.FileName;

                        this.statusField.Text = "Repacking started and can take much time. It's Ok if app looks like not responding";
                        this.statusField.ForeColor = System.Drawing.Color.DarkGreen;

                        PackPak(folderResourceBrowserDialog.SelectedPath, Output);

                        this.statusField.Text = "Repacking Finished. Created file: " + Output;
                        this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void kill_Click(object sender, EventArgs e)
        {
            killProcess();
        }

        private void deleteSav_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("TazWanted.sav will be deleted. Continue?", "Delete Savegame", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    File.Delete(Path.Combine(TazFolderPath, "TazWanted.sav"));
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void maxSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                maxSpd = Single.Parse(maxSpeed.Text.Replace(",", "."), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                this.statusField.Text = "Max Speed changed to " + maxSpd.ToString() + ". Update with -/= keys in game.";
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void cameraSpd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                camSpd = Single.Parse(cameraSpd.Text.Replace(",", "."), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                this.statusField.Text = "Camera Speed changed to " + camSpd.ToString() + ". Re-apply Photo Mode to update.";
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void flyModeStep_TextChanged(object sender, EventArgs e)
        {
            try
            {
                flyStep = Single.Parse(flyModeStep.Text.Replace(",", "."), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                this.statusField.Text = "Fly Mode Step changed to " + flyStep.ToString() + ".";
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void savedCoordX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Xcoord = Single.Parse(savedCoordX.Text.Replace(",", "."), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                this.statusField.Text = "Saved X coord changed to " + Xcoord.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }
        private void savedCoordY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Ycoord = Single.Parse(savedCoordY.Text.Replace(",", "."), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                this.statusField.Text = "Saved Y coord changed to " + Ycoord.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }
        private void savedCoordZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Zcoord = Single.Parse(savedCoordZ.Text.Replace(",", "."), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                this.statusField.Text = "Saved Z coord changed to " + Zcoord.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return;
            }
        }

        private void resetSettings_Click(object sender, EventArgs e)
        {
            if (File.Exists(TazFolderPath + @"\Patcher.xml"))
            {
                try
                {
                    // Delete xml
                    File.Delete(TazFolderPath + @"\Patcher.xml");
                }
                catch (Exception ex)
                {
                    // Anyway it's cannot be seen
                    this.statusField.Text = ex.Message.ToString();
                    this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            Application.Restart();
        }

        private void trainerAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            // Save AutoSave State
            savePatcherSettings_Click(sender, e);
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (trainerAutoSave.Checked == true)
            {
                savePatcherSettings_Click(sender, e);
            }
        }

        private void updateWrappers_Click(object sender, EventArgs e)
        {
            try
            {
                string d3d9ver = "???";
                string d3d11ver = "???";
                string VulkanVer = "???";

                this.statusField.Text = "Downloading Wrappers - Please Wait";
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;

                d3d9ver = DownloadD3D8to9();
                d3d11ver = DownloadDgVoodoo2();
                VulkanVer = DownloadDxVk();

                this.statusField.Text = "Wrappers Downloaded.    d3d8to9: " + d3d9ver + "    dgVoodoo: " + d3d11ver + "    dxvk: " + VulkanVer;
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                // Anyway it's cannot be seen
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        // GetWebResponse
        class MyWebClient : WebClient
        {
            Uri _responseUri;

            public Uri ResponseUri
            {
                get { return _responseUri; }
            }

            protected override WebResponse GetWebResponse(WebRequest request)
            {
                WebResponse response = base.GetWebResponse(request);
                _responseUri = response.ResponseUri;
                return response;
            }
        }

        private String DownloadD3D8to9()
        {
            try
            {
                string d3d9Folder = Path.Combine(TazFolderPath, "Wrappers", "d3d8to9");
                string d3d9File = Path.Combine(d3d9Folder, "d3d8.dll");
                // Create folders
                if (!Directory.Exists(d3d9Folder))
                    Directory.CreateDirectory(d3d9Folder);

                // Download d3d8to9
                using (MyWebClient web1 = new MyWebClient())
                {
                    // Get latest release
                    ServicePointManager.Expect100Continue = true; // For XP/7 compatibility (Thanks MilkGames)
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // For XP/7 compatibility (Thanks MilkGames)
                    string data0 = web1.DownloadString("https://github.com/crosire/d3d8to9/releases/latest");
                    string Latest = web1.ResponseUri.ToString();
                    // Get latest assets
                    string data = web1.DownloadString(Latest.Replace("/tag/", "/expanded_assets/"));
                    string dll9Url = gihubUrl + Regex.Match(data, "/crosire/d3d8to9/releases/download/.*/d3d8.dll").ToString();
                    // Downloading
                    web1.DownloadFile(dll9Url, d3d9File);
                    return Regex.Match(dll9Url, "v\\d.*(?=/)").ToString();
                }
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return "???";
            }
        }

        private String DownloadDgVoodoo2()
        {
            try
            {
                string d3d11Folder = Path.Combine(TazFolderPath, "Wrappers", "dgVoodoo2");
                string d3d11File = Path.Combine(d3d11Folder, "d3d8.dll");
                string d3d11Zip = Path.Combine(d3d11Folder, "dgVoodoo2.zip");
                string d3d11ver = "???";
                // Create folders
                if (!Directory.Exists(d3d11Folder))
                    Directory.CreateDirectory(d3d11Folder);
                // Download dgVoodoo2
                using (MyWebClient web1 = new MyWebClient())
                {
                    // Get latest release
                    string data0 = web1.DownloadString("https://github.com/dege-diosg/dgVoodoo2/releases/latest");
                    string Latest = web1.ResponseUri.ToString();
                    // Get latest assets
                    string data = web1.DownloadString(Latest.Replace("/tag/", "/expanded_assets/"));
                    string zip11Url = gihubUrl + Regex.Match(data, "/dege-diosg/dgVoodoo2/releases/download/.*.zip").ToString();
                    // Downloading
                    web1.DownloadFile(zip11Url, d3d11Zip);
                    d3d11ver = Regex.Match(zip11Url, "v\\d.*(?=/)").ToString();
                }
                // Unpack
                using (ZipArchive archive = ZipFile.OpenRead(d3d11Zip))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName == "MS/x86/D3D8.dll" || entry.FullName == "dgVoodooCpl.exe")
                            entry.ExtractToFile(Path.Combine(d3d11Folder, entry.Name), true);
                    }
                }
                File.Delete(d3d11Zip);
                return d3d11ver;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return "???";
            }
        }

        private String DownloadDxVk()
        {
            try
            {
                string VulkanFolder = Path.Combine(TazFolderPath, "Wrappers", "dxvk");
                string VulkanFile = Path.Combine(VulkanFolder, "d3d9.dll");
                string VulkanTar = Path.Combine(VulkanFolder, "dxvk.tar.gz");
                string VulkanVer = "???";
                // Create folders
                if (!Directory.Exists(VulkanFolder))
                    Directory.CreateDirectory(VulkanFolder);
                // Download Vulkan
                using (MyWebClient web1 = new MyWebClient())
                {
                    // Get latest release
                    string data0 = web1.DownloadString("https://github.com/doitsujin/dxvk/releases/latest");
                    string Latest = web1.ResponseUri.ToString();
                    // Get latest assets
                    string data = web1.DownloadString(Latest.Replace("/tag/", "/expanded_assets/"));
                    string targzVulkanUrl = gihubUrl + Regex.Match(data, "/doitsujin/dxvk/releases/download/.*.tar.gz").ToString();
                    // Downloading
                    web1.DownloadFile(targzVulkanUrl, Path.Combine(VulkanFolder, "dxvk.tar.gz"));
                    VulkanVer = Regex.Match(targzVulkanUrl, "v\\d.*(?=/)").ToString();
                }
                // Unpack
                TarExample.Tar.ExtractTarGz(Path.Combine(VulkanFolder, "dxvk.tar.gz"), Path.Combine(VulkanFolder, "dxvk"));
                foreach (string file in Directory.GetFiles(Path.Combine(VulkanFolder, "dxvk"), "*.dll*", SearchOption.AllDirectories))
                {
                    if (file.Contains("x32\\d3d9.dll"))
                        File.Copy(file, VulkanFile, true);
                }
                Directory.Delete(Path.Combine(VulkanFolder, "dxvk"), true);
                File.Delete(Path.Combine(VulkanFolder, "dxvk.tar.gz"));
                return VulkanVer;
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                return "???";
            }
        }
    }
}

