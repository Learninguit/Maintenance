using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiBanVeTau.BLL;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.GUI;
namespace QuanLiBanVeTau
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
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.Run(new MainForm());
        }
    }
}
