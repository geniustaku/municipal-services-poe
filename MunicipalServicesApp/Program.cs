// Municipal Services Application
// Genius Mhirizhonga  ST10541838
// AAPD7112 Portfolio of Evidence, Part 1

using System;
using System.Windows.Forms;
using MunicipalServicesApp.Forms;

namespace MunicipalServicesApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
        }
    }
}
