using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextMenuManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsRunningAsAdministrator())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ContextMenuManager());
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Yêu cầu chạy chương trình với quyền Administrator!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static bool IsRunningAsAdministrator()
        {            
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();           
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
