using System;
using System.Collections.Generic;
using System.IO;
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
                Settings.InitializeSettings();
                Overseer.InitializeOverseer();
                
                if (Settings.UseLegacyUI)
                {
                    Application.Run(new ZlizEQMapForm());
                }
                else
                {
                    Application.Run(new ZlizEQMapFormExperimental());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
