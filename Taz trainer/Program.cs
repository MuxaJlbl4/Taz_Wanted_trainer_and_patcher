using System;
using System.Windows.Forms;
using System.Threading;

namespace Taz_trainer
{
    static class Program
    {
        private static Mutex mutex = new System.Threading.Mutex(false, "TazWantedTrainerAndPatcher");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (mutex.WaitOne(0, false))
                {
                    // Run the application
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new form());
                }
                else
                {
                    MessageBox.Show("An instance of the application is already running.");
                }
            }
            finally
            {
                if (mutex != null)
                {
                    mutex.Close();
                    mutex = null;
                }
            }
        }
        public static void Restart()
        {
            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex.Dispose();
                mutex = null;
                Application.Restart();
            }
        }
    }
}
