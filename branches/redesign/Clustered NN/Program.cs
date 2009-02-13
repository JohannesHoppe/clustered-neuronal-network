using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clustered_NN.Forms;

namespace Clustered_NN
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CollectForm());
        }
    }
}