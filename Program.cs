using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZlizEQMap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Settings.InitializeDefaultSettings();
                Settings.LoadSettings();
                if (Settings.UseExperimentalUI)
                {
                    Application.Run(new ZlizEQMapFormExperimental());
                }
                else
                {
                    Application.Run(new ZlizEQMapForm());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
