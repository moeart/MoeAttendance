using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DriverUninstaller
{
    public partial class Form1 : Form
    {
        private readonly bool X64 = Environment.Is64BitOperatingSystem;
        private readonly string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
        private readonly string SysDir = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private readonly string SysWOW = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要卸载所有驱动吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
                return;
            }

            var permissionSet = new PermissionSet(PermissionState.None);
            var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, SysDir);
            permissionSet.AddPermission(writePermission);
            writePermission = new FileIOPermission(FileIOPermissionAccess.Write, SysWOW);
            permissionSet.AddPermission(writePermission);

            if (X64)
            {
                try { File.Delete(SysDir + @"\airpcap.dll"); } catch { }
                try { File.Delete(SysWOW + @"\airpcap.dll"); } catch { }
            }
            else
            {
                try { File.Delete(SysDir + @"\airpcap.dll"); } catch { }
            }

            try
            {
                if (X64)
                {
                    runCmd(AppDir + @"\TRLNDIS_Installer64.exe", "2 1");
                }
                else
                {
                    runCmd(AppDir + @"\TRLNDIS_Installer32.exe", "2 1");
                }
            }
            catch
            {
            }

            try
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\WinPcap\Uninstall.exe"))
                {
                    runCmd(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\WinPcap\Uninstall.exe", "");

                }
                else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\WinPcap\Uninstall.exe"))
                {
                    runCmd(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\WinPcap\Uninstall.exe", "");
                }
            }
            catch
            {
            }

            MessageBox.Show("卸载完成", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
            Application.Exit();
        }

        public void runCmd(string path, string args)
        {
            ProcessStartInfo cmdsi = new ProcessStartInfo(path);
            cmdsi.Arguments = args;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }
    }
}
