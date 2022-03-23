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
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Taz_trainer.Properties;

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

        string TazFolderPath = "";

        //Dictionary<string, Int32> Hashes = new Dictionary<string, Int32>();

        public form()
        {
            InitializeComponent();

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
            //gkh.HookedKeys.Add(Keys.Insert);
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

            if (File.Exists(Application.StartupPath + @"\Patcher.xml"))
            {
                try
                {
                    // Load form element states
                    FormSerialisor.Deserialise(this, Application.StartupPath + @"\Patcher.xml");
                }
                catch (Exception ex)
                {
                    this.statusField.Text = ex.Message.ToString();
                    this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                    // Default form element states
                    autoFillVideo(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    textBoxRegistry.Text = getPathFromRegistry();
                    langComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                // Default form element states
                autoFillVideo(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                textBoxRegistry.Text = getPathFromRegistry();
                langComboBox.SelectedIndex = 0;
            }
            TazFolderPath = textBoxRegistry.Text;

            // Usage tab init
            string html = Properties.Resources.README;
            webBrowser.DocumentText = html;
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
                BallMouseTazSwitch();
                sendKey(Keys.F12, "{F12}");
            }
            /*if (e.KeyCode == Keys.Insert)
            {
                this.fragileWorld.Checked = !this.fragileWorld.Checked;
                sendKey(Keys.Insert, "{Insert}");
            }*/
            if (e.KeyCode == Keys.Home)
            {
                this.undestructibleWorld.Checked = !this.undestructibleWorld.Checked;
                sendKey(Keys.Home, "{Home}");
            }
            /*
            if (e.KeyCode == Keys.End)
            {

                sendKey(Keys.End, "{End}");
            }
            */
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
            if (WriteProcessMemory(handle, (IntPtr)adress, bytes, size, out mem) == false) {
                this.statusField.Text = "WriteProcessMemory failed! Handle = " + handle;
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            };
            CloseHandle(handle);
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
                //enviroment
                byte[] bytes = { 0xFF };
                checkAndWrite((IntPtr)0x00474FC4, bytes, bytes.Length, new IntPtr());
                byte[] bytes2 = { 0x74 };
                checkAndWrite((IntPtr)0x00474FD0, bytes2, bytes2.Length, new IntPtr());

                //bonuses and effects
                byte[] bytes3 = { 0x00, 0x00, 0x80, 0x7F }; // Code
                checkAndWrite((IntPtr)0x005F66E8, bytes3, bytes3.Length, new IntPtr());
                byte[] bytes4 = { 0xE8, 0x66, 0x5F, 0x00 }; // Code
                checkAndWrite((IntPtr)0x0047E00B, bytes4, bytes4.Length, new IntPtr());
                byte[] bytes5 = { 0xD9, 0xE8, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }; // Code
                checkAndWrite((IntPtr)0x0047E016, bytes5, bytes5.Length, new IntPtr());

                message("Infinity Draw Distance: On");
            }
            else
            {
                //enviroment
                byte[] bytes = { 0x00 };
                checkAndWrite((IntPtr)0x00474FC4, bytes, bytes.Length, new IntPtr());
                byte[] bytes2 = { 0x75 };
                checkAndWrite((IntPtr)0x00474FD0, bytes2, bytes2.Length, new IntPtr());

                //bonuses and effects
                byte[] bytes4 = { 0xF4, 0x75, 0x5F, 0x00 }; // Code
                checkAndWrite((IntPtr)0x0047E00B, bytes4, bytes4.Length, new IntPtr());
                byte[] bytes5 = { 0xD9, 0x46, 0x3C, 0xD8, 0x0D, 0xE4, 0x7E, 0x5F, 0x00, 0xD9, 0xFE }; // Code
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

                message("Super Jump Mode: On (Hold Jump)");
            }
            else
            {
                byte[] bytes2 = { 0xD9, 0x44, 0x24, 0x58, 0xD8, 0x63, 0x08 };
                checkAndWrite((IntPtr)0x00462245, bytes2, bytes2.Length, new IntPtr());

                message("Super Jump Mode: Off");
            }
        }


        private void changeGameSpeed(byte ch)
        {
            //read current speed
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            bytes = checkAndRead((IntPtr)0x006F4A3C, bytes, bytes.Length, new IntPtr());
            float current = BitConverter.ToSingle(bytes, 0);

            //PositiveInfinity stops game, all other commented values crashes
            float[] values = { /* 0, Single.Epsilon, 0.0000001f, */ 0.000001f, 0.001f, 0.01f, 0.1f, 1, 2, 4, 8, 16 /*, Single.MaxValue, Single.PositiveInfinity*/ };
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

                message("Always Burp Mode: On");
            }
            else
            {
                byte[] bytes = { 0x0F, 0x85, 0x95, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00482FE2, bytes, bytes.Length, new IntPtr());

                message("Always Burp Mode: Off");
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

        float X = 0;
        float Y = 0;
        float Z = 0;

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
            X = value;
            adress += 0x4;
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            value = BitConverter.ToSingle(bytes, 0);
            Z = value;
            adress += 0x4;
            bytes = checkAndRead((IntPtr)adress, bytes, size, mem);
            value = BitConverter.ToSingle(bytes, 0);
            Y = value;

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
            bytes = BitConverter.GetBytes(X);
            checkAndWrite((IntPtr)adress, bytes, size, mem);
            adress += 0x4;
            bytes = BitConverter.GetBytes(Z);
            checkAndWrite((IntPtr)adress, bytes, size, mem);
            adress += 0x4;
            bytes = BitConverter.GetBytes(Y);
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            message("Taz Position Loaded");
        }

        private void flyCamera_CheckedChanged(object sender, EventArgs e)
        {
            byte[] bytes = { 0x01 };
            checkAndWrite((IntPtr)0x0071C4D4, bytes, bytes.Length, new IntPtr());

            message("Fly Camera: On (Bite to turn off)");
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
            //Read debug menu state offset
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            bytes = checkAndRead((IntPtr)0x006C80EC, bytes, 4, new IntPtr());
            int adress = BitConverter.ToInt32(bytes, 0);
            adress += 0x14;

            //Write debug menu state to 1
            byte[] bytes2 = { 0x01 };
            checkAndWrite((IntPtr)adress, bytes2, bytes2.Length, new IntPtr());

            this.dbgMenuOff.Start();

            message("");
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
                byte[] bytes = { 0xEB, 0x0D };
                checkAndWrite((IntPtr)0x0041B87B, bytes, bytes.Length, new IntPtr());

                message("Solid World Mode: On");
            }
            else
            {
                byte[] bytes = { 0x75, 0x16 };
                checkAndWrite((IntPtr)0x0041B87B, bytes, bytes.Length, new IntPtr());

                message("Solid World Mode: Off");
            }
        }

        private void SmoothLighting_CheckedChanged(object sender, EventArgs e)
        {
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

                message("Smooth Lighting: On");
            }
            else
            {
                //Lighting mode 4
                byte[] bytes3 = { 0x04 };
                checkAndWrite((IntPtr)0x005F66D2, bytes3, bytes3.Length, new IntPtr());

                message("Smooth Lighting: Off");
            }
        }

        private void fpsCap_CheckedChanged(object sender, EventArgs e)
        {
            /*
            label(returnhere)
            label(exit)

            "Taz.exe"+1F6700:
            // DrawFrame
            call Taz.exe+90110 //90100

            sleep1:
            // bkTimerRead__Fv
            call 005785F0
            push edx
            push eax

            mov edx,[005F6708]
            mov eax,[005F6704]
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
            fcomp [005F6700]
            fnstsw ax
            test ah,1
            jne sleep1

            exit:
            // bkTimerRead__Fv
            call 005785F0
            mov [005F6708],edx
            mov [005F6704],eax

            jmp returnhere

            "Taz.exe"+A77EC:
            jmp "Taz.exe"+1F6700
            returnhere:
            */
            // 0xE8, 0xFB, 0x99, 0xE9
            byte[] bytes = { 0xE8, 0x0B, 0x9A, 0xE9, 0xFF, 0xE8, 0xE6, 0x1E, 0xF8, 0xFF, 0x52, 0x50, 0x8B, 0x15, 0x58, 0x05, 0x01, 0x00, 0xA1, 0x54, 0x05, 0x01, 0x00, 0x52, 0x50, 0xE8, 0xE2, 0x1F, 0xF8, 0xFF, 0x68, 0x01, 0x00, 0x00, 0x00, 0x68, 0x01, 0x00, 0x00, 0x00, 0x52, 0x50, 0xE8, 0x81, 0x1F, 0xF8, 0xFF, 0x83, 0xC4, 0x20, 0xD8, 0x1D, 0x50, 0x05, 0x01, 0x00, 0xDF, 0xE0, 0xF6, 0xC4, 0x01, 0x75, 0xC6, 0xE8, 0xAC, 0x1E, 0xF8, 0xFF, 0x89, 0x15, 0x58, 0x05, 0x01, 0x00, 0xA3, 0x54, 0x05, 0x01, 0x00, 0xE9, 0x9D, 0x10, 0xEB, 0xFF };
            checkAndWrite((IntPtr)0x005F6710, bytes, bytes.Length, new IntPtr());

            /*
            "Taz.exe" + A77EC:
            jmp "Taz.exe" + 1F6700
            returnhere:
            */
            byte[] bytes2 = { 0xE9, 0x0F, 0xEF, 0x14, 0x00 };
            checkAndWrite((IntPtr)0x004A77EC, bytes2, bytes2.Length, new IntPtr());

            if (this.fpsCap.Checked == true)
            {
                float miliseconds = (1000 / (float)numericFpsCap.Value) / 1000;

                // Float delay in seconds
                byte[] bytes3 = BitConverter.GetBytes(miliseconds);
                checkAndWrite((IntPtr)0x005F6700, bytes3, bytes3.Length, new IntPtr());

                message("FPS Cap: " + numericFpsCap.Value.ToString() + " Hz");
            }
            else
            {
                // 0,00
                byte[] bytes3 = { 0x00, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x005F6700, bytes3, bytes3.Length, new IntPtr());

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
        /*
        private void mouseMode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.mouseMode.Checked == true)
            {
                byte[] bytes = { 0xEB, 0x4E, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x0042E1B2, bytes, bytes.Length, new IntPtr());
                message("Tiny Mouse (Ghost): On");
            }
            else
            {
                byte[] bytes = { 0x0F, 0x84, 0x86, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x0042E1B2, bytes, bytes.Length, new IntPtr());
                message("Tiny Mouse (Ghost): Off");
            }
        }

        private void ballMode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ballMode.Checked == true)
            {
                byte[] bytes2 = { 0x75, 0x05, 0xEB, 0x3E, 0x90 };
                checkAndWrite((IntPtr)0x0042E1F2, bytes2, bytes2.Length, new IntPtr());
                byte[] bytes = { 0xEB, 0x2A, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x0042E1B2, bytes, bytes.Length, new IntPtr());

                message("Bouncy Ball (Ghost): On");
            }
            else
            {
                byte[] bytes2 = { 0x74, 0x40, 0x83, 0xF8, 0x51 };
                checkAndWrite((IntPtr)0x0042E1F2, bytes2, bytes2.Length, new IntPtr());
                byte[] bytes = { 0x0F, 0x84, 0x86, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x0042E1B2, bytes, bytes.Length, new IntPtr());

                message("Bouncy Ball (Ghost): Off");
            }
        }
        */


        private void ballMouseTazMode_CheckedChanged(object sender, EventArgs e)
        {
            BallMouseTazSwitch();
        }

        private void BallMouseTazSwitch()
        {
            byte[] bytes = { 0x00 };
            bytes = checkAndRead((IntPtr)0x0042E1B3, bytes, 1, new IntPtr());

            if (bytes[0] == 0x2A) // From Ball to Mouse
            {
                byte[] bytes2 = { 0xEB, 0x4E, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x0042E1B2, bytes2, bytes2.Length, new IntPtr());
                message("Tiny Mouse (Ghost)");
            }
            else if (bytes[0] == 0x4E) // From Mouse to Taz
            {
                byte[] bytes2 = { 0xEB, 0x12, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x0042E1B2, bytes2, bytes2.Length, new IntPtr());
                message("Taz (Ghost)");
            }
            else // From Taz to Ball
            {
                byte[] bytes2 = { 0x75, 0x05, 0xEB, 0x3E, 0x90 };
                checkAndWrite((IntPtr)0x0042E1F2, bytes2, bytes2.Length, new IntPtr());
                byte[] bytes3 = { 0xEB, 0x2A, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x0042E1B2, bytes3, bytes3.Length, new IntPtr());
                message("Bouncy Ball (Ghost)");
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


        private void dbgMenuOff_Tick(object sender, EventArgs e)
        {
            this.dbgMenuOff.Stop();

            //Read debug menu state offset
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            bytes = checkAndRead((IntPtr)0x006C80EC, bytes, 4, new IntPtr());
            int adress = BitConverter.ToInt32(bytes, 0);
            adress += 0x14;

            //Write debug menu state to 0
            byte[] bytes2 = { 0x00 };
            checkAndWrite((IntPtr)adress, bytes2, bytes2.Length, new IntPtr());
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
                    File.Copy(TazFolderPath + "\\Taz.exe", TazFolderPath + "\\Taz.exe.backup");
                    backuped = true;
                }

                //backup Taz.exe
                if (File.Exists(TazFolderPath + "\\taz.dat.backup") == false)
                {
                    File.Copy(TazFolderPath + "\\taz.dat", TazFolderPath + "\\taz.dat.backup");
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

                //disable draw distance
                if (this.disableDrawDistance.Checked == true)
                {
                    //enviroment
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[] { 0xFF, 0xFF, 0x74 }; // 00 00 75
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

                //disable videos
                if (this.disableVideos.Checked == true)
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

                //resolution
                if (this.changeResolution.Checked == true)
                {
                    byte[] width = BitConverter.GetBytes(UInt32.Parse(this.width.Text));
                    byte[] height = BitConverter.GetBytes(UInt32.Parse(this.height.Text));

                    if (this.windowed.Checked == false)
                    {
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
                            file.Position = 0x34;
                            file.WriteByte(0x00);
                            //lighting
                            file.Position = 0x38;
                            file.WriteByte(0x01);
                            //outlines
                            file.Position = 0x3C;
                            file.WriteByte(0x01);
                            //no voodoo
                            //file.Position = 0x40;
                            //file.WriteByte(0x00);
                            //file.Close();
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
                    }
                }
                else
                {
                    //restore resolution
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
                        file.Position = 0x38;
                        file.WriteByte(0x01);
                        //outlines
                        file.Position = 0x3C;
                        file.WriteByte(0x01);
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
                    // restore windowed mode
                    using (var file = new FileStream(TazFolderPath + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //windowed
                        file.Position = 0x34;
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
                        file.Position = 0x8FD76;
                        file.WriteByte(aspect1);
                        file.Position = 0x8FD7D;
                        file.WriteByte(aspect2);
                        file.Close();
                    }
                }
                else
                {
                    //restore aspect ratio
                    using (var file = new FileStream(TazFolderPath + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //windowed
                        file.Position = 0x8FD76;
                        file.WriteByte(0x04);
                        file.Position = 0x8FD7D;
                        file.WriteByte(0x03);
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

                //warning banner time
                if (this.warningBanner.Checked == true)
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
                        File.Copy(TazFolderPath + "\\Paks\\text.pc.backup", TazFolderPath + "\\Paks\\text.pc");
                        File.Copy(TazFolderPath + "\\Paks\\resTex.pc.backup", TazFolderPath + "\\Paks\\resTex.pc");
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
                        File.Copy(TazFolderPath + "\\Paks\\text.pc", TazFolderPath + "\\Paks\\text.pc.backup");
                        File.Copy(TazFolderPath + "\\Paks\\resTex.pc", TazFolderPath + "\\Paks\\resTex.pc.backup");
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
                        File.Copy(TazFolderPath + "\\Taz.exe.backup", TazFolderPath + "\\Taz.exe");
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
                        File.Copy(TazFolderPath + "\\Paks\\text.pc.backup", TazFolderPath + "\\Paks\\text.pc");
                        File.Copy(TazFolderPath + "\\Paks\\resTex.pc.backup", TazFolderPath + "\\Paks\\resTex.pc");
                        File.Delete(TazFolderPath + "\\Paks\\text.pc.backup");
                        File.Delete(TazFolderPath + "\\Paks\\resTex.pc.backup");
                    }

                    //Check and restore taz.dat backup
                    if (File.Exists(TazFolderPath + "\\taz.dat.backup") == true)
                    {
                        //Replace
                        File.Delete(TazFolderPath + "\\taz.dat");
                        File.Copy(TazFolderPath + "\\taz.dat.backup", TazFolderPath + "\\taz.dat");
                    }
                    else
                    {
                        this.statusField.Text = "taz.dat.backup not found!";
                        this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                    }

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
                    MessageBox.Show("Game config file not found. Launch game via native launcher (Settings -> Taz Shortcuts -> Launcher) to create config, then restart game via patcher.", "File taz.dat not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void savePatcherSettings_Click(object sender, EventArgs e)
        {
            try
            {
                FormSerialisor.Serialise(this, Application.StartupPath + @"\Patcher.xml");
                this.statusField.Text = "App settings successfully saved to: " + Application.StartupPath + @"\Patcher.xml";
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
            // Deserialize Hashes
            Dictionary<string, UInt32> Hashes = new Dictionary<string, UInt32>();
            byte[] hashbin = Properties.Resources.Hashes;
            Stream hashstream = new MemoryStream(hashbin);
            using (hashstream)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Hashes = (Dictionary<string, UInt32>)formatter.Deserialize(hashstream);
            }

            // Init
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
                UsedHashes = UsedHashes.Append(Hashes[ShortName]).ToArray();
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
                FileInfos = FileInfos.Concat(BitConverter.GetBytes(Hashes[ShortName])).ToArray();
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
            if (Path.GetDirectoryName(DirName).Contains("ound"))
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

        private void unpack_Click(object sender, EventArgs e)
        {
            try
            {
                if (openPakFileDialog.ShowDialog() == DialogResult.OK && saveUnpackedFilesDialog.ShowDialog() == DialogResult.OK)
                {
                    this.statusField.Text = "Unpacking started";
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
                    string Output = Path.Combine(Application.StartupPath, "RepackedPaks");
                    Output = Path.Combine(Output, Path.GetFileName(folderResourceBrowserDialog.SelectedPath) + ".pc");

                    PackPak(folderResourceBrowserDialog.SelectedPath, Output);

                    this.statusField.Text = "Repacking Finished. Created file: " + Output;
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
    }
}

