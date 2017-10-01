using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Utilities;
using Microsoft.Win32;
using System.IO;

namespace Taz_trainer
{
    public partial class Form1 : Form
    {
        // dll import (pinvoke.net)
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess,IntPtr lpBaseAddress,byte[] lpBuffer,int nSize,out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);


        public Form1()
        {
            InitializeComponent();

            gkh.HookedKeys.Add(Keys.F1);
            gkh.HookedKeys.Add(Keys.F2);
            gkh.HookedKeys.Add(Keys.F3);
            gkh.HookedKeys.Add(Keys.F4);
            gkh.HookedKeys.Add(Keys.F5);
            gkh.HookedKeys.Add(Keys.F6);
            gkh.HookedKeys.Add(Keys.F7);
            gkh.HookedKeys.Add(Keys.PageDown);
            gkh.HookedKeys.Add(Keys.PageUp);
            gkh.HookedKeys.Add(Keys.Subtract);
            gkh.HookedKeys.Add(Keys.Add);

            gkh.HookedKeys.Add(Keys.NumPad9);
            gkh.HookedKeys.Add(Keys.NumPad8);
            gkh.HookedKeys.Add(Keys.NumPad7);
            gkh.HookedKeys.Add(Keys.NumPad6);
            gkh.HookedKeys.Add(Keys.NumPad5);
            gkh.HookedKeys.Add(Keys.NumPad4);
            gkh.HookedKeys.Add(Keys.NumPad2);

            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

            autoFillVideo(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

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
            }
            if (e.KeyCode == Keys.F2)
            {
                this.superBelchCan.Checked = !this.superBelchCan.Checked;
            }
            if (e.KeyCode == Keys.F3)
            {
                this.flyMode.Checked = !this.flyMode.Checked;
            }
            if (e.KeyCode == Keys.F4)
            {
                this.freezeLevelTimer.Checked = !this.freezeLevelTimer.Checked;
            }
            if (e.KeyCode == Keys.F5)
            {
                this.drawDistance.Checked = !this.drawDistance.Checked;
            }
            if (e.KeyCode == Keys.F6)
            {
                this.smoothLight.Checked = !this.smoothLight.Checked;
            }
            if (e.KeyCode == Keys.F7)
            {
                this.debugMenu.Checked = !this.debugMenu.Checked;
            }
            if (e.KeyCode == Keys.PageUp)
            {
                this.numericSpeed.UpButton();
            }
            if (e.KeyCode == Keys.PageDown)
            {
                this.numericSpeed.DownButton();
            }
            if (e.KeyCode == Keys.Add)
            {
                this.numericJump.UpButton();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                this.numericJump.DownButton();
            }


            if (e.KeyCode == Keys.NumPad5)
            {
                //if (e.IsRepeat) return;
                this.flyMode.Checked = !this.flyMode.Checked;
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(0); //Z+
                }
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(4); //Y+
                }
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(1); //Z-
                }
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(2); //X+
                }
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(3); //X-
                }
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                if (this.flyMode.Checked == true)
                {
                    movement(5); //Y-
                }
            }

            e.Handled = true;
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

            //calculate aspect ratio
            int a = width;
            int b = height;
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            int aspect1 = width / a;
            int aspect2 = height / a;
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


        //#######################################################################################################################
        //Cheats
        private void memoryEdit(int adress, byte[] bytes)
        {
            int size = bytes.Length;
            var mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);
        }

        private void drawDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.drawDistance.Checked == true)
            {
                byte[] bytes = { 0xFF };
                checkAndWrite((IntPtr)0x00474FC4, bytes, bytes.Length, new IntPtr());
                byte[] bytes2 = { 0x74 };
                checkAndWrite((IntPtr)0x00474FD0, bytes2, bytes2.Length, new IntPtr());

                message("Infinity draw distance: on");
            }
            else
            {
                byte[] bytes = { 0x00 };
                checkAndWrite((IntPtr)0x00474FC4, bytes, bytes.Length, new IntPtr());
                byte[] bytes2 = { 0x75 };
                checkAndWrite((IntPtr)0x00474FD0, bytes2, bytes2.Length, new IntPtr());

                message("Infinity draw distance: off");
            }
        }

        private void numericJump_ValueChanged(object sender, EventArgs e)
        {
            float impulse = 1750;
            impulse *= (float)numericJump.Value;
            checkAndWrite((IntPtr)0x0048129F, BitConverter.GetBytes(impulse), BitConverter.GetBytes(impulse).Length, new IntPtr());

            message("Jump impulse: x" + numericJump.Value.ToString());
        }

        private void numericSpeed_ValueChanged(object sender, EventArgs e)
        {
            float val = 1;
            //correction to 0.1
            if ((float)numericSpeed.Value == 0)
            {
                val = (float)0.1;
            }
            else
            {
                val = (float)numericSpeed.Value;
            }

            checkAndWrite((IntPtr)0x006F4A3C, BitConverter.GetBytes(val), BitConverter.GetBytes((float)numericSpeed.Value).Length, new IntPtr());
            message("Game speed: x" + val.ToString());
        }

        private void superBelchCan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.superBelchCan.Checked == true)
            {
                byte[] bytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                checkAndWrite((IntPtr)0x00482FE2, bytes, bytes.Length, new IntPtr());

                message("Always super burp: on");
            }
            else
            {
                byte[] bytes = { 0x0F, 0x85, 0x95, 0x00, 0x00, 0x00 };
                checkAndWrite((IntPtr)0x00482FE2, bytes, bytes.Length, new IntPtr());

                message("Always super burp: off");
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

                message("Invisibility: on");
            }
            else
            {
                byte[] bytes2 = { 0x84 };
                checkAndWrite((IntPtr)0x0051F2E7, bytes2, bytes2.Length, new IntPtr());
                bytes2[0] = 0x00;
                checkAndWrite((IntPtr)0x0051F47E, bytes2, bytes2.Length, new IntPtr());
                //bytes2[0] = 0x00;
                checkAndWrite((IntPtr)adress, bytes2, bytes2.Length, new IntPtr());

                message("Invisibility: off");
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

                message("Fly mode: on (use numpad)");
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

                message("Fly mode: off");
            }
        }

        private void movement (byte dir)
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

                message("Freeze level timer: on");
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

                message("Freeze level timer: off");
            }
        }

        private void smoothLight_CheckedChanged(object sender, EventArgs e)
        {
            //Code injection
            byte[] bytes = { 0x50, 0xB8, 0x05, 0x00, 0x00, 0x00, 0x89, 0x87, 0x44, 0x01, 0x00, 0x00, 0x58, 0xD8, 0x1D, 0x3C, 0x73, 0x5F, 0x00, 0xE9, 0xA7, 0xBB, 0xE6, 0xFF };
            checkAndWrite((IntPtr)0x005F66A0, bytes, bytes.Length, new IntPtr());
            //Jump to injection
            byte[] bytes2 = { 0xE9, 0x42, 0x44, 0x19, 0x00, 0x90 };
            checkAndWrite((IntPtr)0x00462259, bytes2, bytes2.Length, new IntPtr());

            if (this.smoothLight.Checked == true)
            {

                //Lighting mode 5
                byte[] bytes3 = { 0x05 };
                checkAndWrite((IntPtr)0x005F66A2, bytes3, bytes3.Length, new IntPtr());

                message("Smooth lighting: on");
            }
            else
            {
                //Lighting mode 4
                byte[] bytes3 = { 0x04 };
                checkAndWrite((IntPtr)0x005F66A2, bytes3, bytes3.Length, new IntPtr());

                message("Smooth lighting: off");
            }
        }

        private void debugMenu_CheckedChanged(object sender, EventArgs e)
        {
            /*
             * 00642038 - bckg text
             * 004A7867 - DBG MENU!!!!!!!!!!!!!!!!
            */
            //Read debug menu state offset
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00 };
            bytes = checkAndRead((IntPtr)0x006C80EC, bytes, 4, new IntPtr());
            int adress = BitConverter.ToInt32(bytes, 0);
            adress += 0x14;

            //Write debug menu state to 1
            byte[] bytes2 = { 0x01 };
            checkAndWrite((IntPtr)adress, bytes2, bytes2.Length, new IntPtr());

            this.dbgMenuOff.Start();

            message("Call debug menu");
        }

        private void message(string message)
        {
            //Jmp to show text
            var adress = 0x004A9AED;
            byte[] bytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            int size = 6;
            var mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Push text
            adress = 0x004A9B0A;
            bytes[0] = 0x00;
            bytes[1] = 0xC4;
            bytes[2] = 0x58;
            bytes[3] = 0x00;
            size = 4;
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Hide additional info 1
            adress = 0x00643030;
            bytes[0] = 0x00;
            size = 1;
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Hide additional info 2
            adress = 0x00643038;
            bytes[0] = 0x00;
            size = 1;
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Text
            adress = 0x0058C400; //Cave for text adress
            byte[] bytes2 = Encoding.ASCII.GetBytes(message);
            size = bytes2.Length + 1; // +1 adds zero at end
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes2, size, mem);

            timer.Stop();
            timer.Start();

            /*
            //Jmp to show text
            var adress = 0x004A9D5C; //Base adress
            byte[] bytes = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x68, 0x00, 0xC4, 0x58, 0x00 };
            //byte[] bytes = { 0x0F, 0x85, 0x93, 0x00, 0x00, 0x00, 0x68, 0x24, 0x30, 0x64, 0x00 };
            int size = 11;
            var mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Text
            adress = 0x0058C400; //Cave for text adress
            byte[] bytes2 = Encoding.ASCII.GetBytes(message);
            size = bytes2.Length + 1; //Add zero
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes2, size, mem);

            timer.Stop();
            timer.Enabled = true;
            */
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            //Return original instructions of show text
            var adress = 0x004A9AED;
            byte[] bytes = { 0x0F, 0x84, 0x56, 0x02, 0x00, 0x00 };
            int size = 6;
            var mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Restore to original push
            adress = 0x004A9B0A;
            bytes[0] = 0x2C;
            bytes[1] = 0x12;
            bytes[2] = 0x64;
            bytes[3] = 0x00;
            size = 4;
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Restore to original text 1
            adress = 0x00643030;
            bytes[0] = 0x25;
            size = 1;
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            //Restore to original text 2
            adress = 0x00643038;
            bytes[0] = 0x28;
            size = 1;
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);

            /*
            //Original push
            adress = 0x004A9B09; //Base adress
            byte[] bytes2 = { 0x68, 0x2C, 0x12, 0x64, 0x00 };
            size = 5;
            mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);
            */
            /*
            timer.Enabled = false;
            //Return original instructions of show text
            var adress = 0x004A9D5C; //Base adress
            byte[] bytes = { 0x0F, 0x85, 0x93, 0x00, 0x00, 0x00, 0x68, 0x24, 0x30, 0x64, 0x00 };
            int size = 11;
            var mem = new IntPtr();
            checkAndWrite((IntPtr)adress, bytes, size, mem);
            */
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

        private void patch_Click(object sender, EventArgs e)
        {
            try
            {
                //Check checkboxes
                if (this.noCD.Checked == false && this.disableDrawDistance.Checked == false && this.disableVideos.Checked == false && this.changeResolution.Checked == false && this.aspectRatio.Checked == false && this.warningBanner.Checked == false)
                {
                    MessageBox.Show("Select at least one option", "No options selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Read path from registry
                string TazGameFolder = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Infogrames Interactive\TazWanted\Release", "Location", null);
                if (TazGameFolder == null)
                {
                    // Search in x86 registry
                    TazGameFolder = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Infogrames Interactive\TazWanted\Release", "Location", null);
                }

                bool backuped = false;

                //backup taz.exe
                if (File.Exists(TazGameFolder + "\\Taz.exe.backup") == false)
                {
                    File.Copy(TazGameFolder + "\\Taz.exe", TazGameFolder + "\\Taz.exe.backup");
                    backuped = true;
                }

                //noCD 
                if (this.noCD.Checked == true)
                {
                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
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

                //disable draw distance
                if (this.disableDrawDistance.Checked == true)
                {
                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[] { 0xFF, 0xFF, 0x74 }; // 00 00 75
                        file.Position = 0x74FC4;
                        file.WriteByte(bytes[0]);
                        file.WriteByte(bytes[1]);
                        file.Position = 0x74FD0;
                        file.WriteByte(bytes[2]);
                        file.Close();
                    }

                    using (var file = new FileStream(TazGameFolder + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //max default
                        file.Position = 0x44;
                        file.WriteByte(0xFF);
                        file.WriteByte(0xFF);
                        file.Close();
                    }
                }

                //disable videos
                if (this.disableVideos.Checked == true)
                {
                    if (Directory.Exists(TazGameFolder + "\\DISABLED Videos") == false)
                    {
                        Directory.Move(TazGameFolder + "\\Videos", TazGameFolder + "\\DISABLED Videos");
                    }
                }

                //resolution
                if (this.changeResolution.Checked == true)
                {
                    if (this.windowed.Checked == false)
                    {
                        byte[] width = BitConverter.GetBytes(UInt32.Parse(this.width.Text));
                        byte[] height = BitConverter.GetBytes(UInt32.Parse(this.height.Text));

                        using (var file = new FileStream(TazGameFolder + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
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
                            file.Position = 0x40;
                            file.WriteByte(0x00);
                            file.Close();
                        }
                    }
                    else
                    {
                        using (var file = new FileStream(TazGameFolder + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                        {
                            //windowed
                            file.Position = 0x34;
                            file.WriteByte(0x01);
                            file.Close();
                        }
                    }
                }

                //aspect ratio
                if (this.aspectRatio.Checked == true)
                {
                    byte aspect1 = Byte.Parse(this.aspect1.Text);
                    byte aspect2 = Byte.Parse(this.aspect2.Text);

                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //windowed
                        file.Position = 0x8FD76;
                        file.WriteByte(aspect1);
                        file.Position = 0x8FD7D;
                        file.WriteByte(aspect2);
                        file.Close();
                    }
                }

                if (this.warningBanner.Checked == true)
                {
                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //warning banner time
                        file.Position = 0x1F73F6;
                        file.WriteByte(0x00);
                        file.WriteByte(0x00);
                        file.Close();
                    }
                }

                    //end
                    this.statusField.Text = "Patched successfully (" + TazGameFolder + ")";
                if (backuped == true)
                {
                    this.statusField.Text += " and created backup of taz.exe";
                }
                this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                MessageBox.Show("Patched successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var result = MessageBox.Show("This will restore: CD check, draw distance, logo videos, warning banner and set video mode to 1024x768 (4:3 fullscreen). Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Read path from registry
                    string TazGameFolder = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Infogrames Interactive\TazWanted\Release", "Location", null);
                    if (TazGameFolder == null)
                    {
                        // Search in x86 registry
                        TazGameFolder = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Infogrames Interactive\TazWanted\Release", "Location", null);
                    }

                    //restore CD check
                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[] { 0x81, 0xEC, 0x38, 0x01 };
                        file.Position = 0xA1F10;
                        file.WriteByte(bytes[0]);
                        file.WriteByte(bytes[1]);
                        file.WriteByte(bytes[2]);
                        file.WriteByte(bytes[3]);
                        file.Close();
                    }
                    //restore draw distace
                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] bytes = new byte[] { 0x00, 0x00, 0x75 };
                        file.Position = 0x74FC4;
                        file.WriteByte(bytes[0]);
                        file.WriteByte(bytes[1]);
                        file.Position = 0x74FD0;
                        file.WriteByte(bytes[2]);
                        file.Close();
                    }
                    using (var file = new FileStream(TazGameFolder + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //max default
                        file.Position = 0x44;
                        file.WriteByte(0x30);
                        file.WriteByte(0x02);
                        file.Close();
                    }
                    //restore videos
                    if (Directory.Exists(TazGameFolder + "\\Videos") == false)
                    {
                        Directory.Move(TazGameFolder + "\\DISABLED Videos", TazGameFolder + "/Videos");
                    }
                    //restore resolution
                    using (var file = new FileStream(TazGameFolder + "\\taz.dat", FileMode.Open, FileAccess.ReadWrite))
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
                        file.Position = 0x40;
                        file.WriteByte(0x00);
                        file.Close();
                    }
                    //restore aspect ratio
                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        //windowed
                        file.Position = 0x8FD76;
                        file.WriteByte(0x04);
                        file.Position = 0x8FD7D;
                        file.WriteByte(0x03);
                        file.Close();
                    }
                    //restore warning banner time
                    using (var file = new FileStream(TazGameFolder + "\\Taz.exe", FileMode.Open, FileAccess.ReadWrite))
                    {
                        file.Position = 0x1F73F6;
                        file.WriteByte(0xA0);
                        file.WriteByte(0x40);
                        file.Close();
                    }
                    //restore end
                    this.statusField.Text = "Restored successfully (" + TazGameFolder + ")";
                    this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                    MessageBox.Show("Restored successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.statusField.Text = ex.Message.ToString();
                this.statusField.ForeColor = System.Drawing.Color.DarkRed;
            }

        }


        private void restoreBackup_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("This will restore previously created backup of taz.exe file. Continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Read path from registry
                    string TazGameFolder = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Infogrames Interactive\TazWanted\Release", "Location", null);
                    if (TazGameFolder == null)
                    {
                        // Search in x86 registry
                        TazGameFolder = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Infogrames Interactive\TazWanted\Release", "Location", null);
                    }

                    //Check backup
                    if (File.Exists(TazGameFolder + "\\Taz.exe.backup") == true)
                    {
                        //Replace
                        File.Delete(TazGameFolder + "\\Taz.exe");
                        File.Copy(TazGameFolder + "\\Taz.exe.backup", TazGameFolder + "\\Taz.exe");
                    }
                    else
                    {
                        this.statusField.Text = "Taz.exe.backup not found!";
                        this.statusField.ForeColor = System.Drawing.Color.DarkRed;
                        return;
                    }
                    //restore end
                    this.statusField.Text = "Restored successfully (" + TazGameFolder + ")";
                    this.statusField.ForeColor = System.Drawing.Color.DarkGreen;
                    MessageBox.Show("Restored successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (this.windowed.Checked == false)
                {
                    this.height.Enabled = true;
                    this.xLabel.Enabled = true;
                    this.width.Enabled = true;
                }
                this.aspectRatio.Checked = true;
            }
            else
            {
                this.windowed.Enabled = false;
                this.height.Enabled = false;
                this.xLabel.Enabled = false;
                this.width.Enabled = false;
                this.aspectRatio.Checked = false;
            }
        }

        private void windowed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.windowed.Checked == true)
            {
                this.height.Enabled = false;
                this.xLabel.Enabled = false;
                this.width.Enabled = false;
                autoFillVideo(640, 480);
                this.aspectRatio.Checked = true;
            }
            else
            {
                this.height.Enabled = true;
                this.xLabel.Enabled = true;
                this.width.Enabled = true;
                autoFillVideo(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                this.aspectRatio.Checked = true;
            }
        }

        private void gitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MuxaJlbl4/Taz_Wanted_trainer_and_patcher");
        }
    }
}
