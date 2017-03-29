using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;

namespace WiFi_Sign.View
{
    public partial class Drivers : Form
    {
        private bool isAirpcapInst = false;
        private bool isWinpcapInst = false;
        private bool isTarlogicInst = false;

        private readonly bool X64 = Environment.Is64BitOperatingSystem;
        private readonly string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
        private readonly string SysDir = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private readonly string SysWOW = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);

        public Drivers()
        {
            InitializeComponent();
            noticeLbl.Text = "";
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            CheckInstall();

            if (isAirpcapInst && isWinpcapInst && isTarlogicInst) // 全安装
            {
                BtnInst.Enabled = false;
                BtnUninstall.Enabled = true;
                noticeLbl.Text = "驱动全部正常，无需安装";
                noticeLbl.ForeColor = Color.Green;
            }
            else if (!isAirpcapInst && !isWinpcapInst && !isTarlogicInst) // 全没安装
            {
                BtnInst.Enabled = true;
                BtnUninstall.Enabled = false;
                noticeLbl.Text = "驱动未安装请安装驱动";
                noticeLbl.ForeColor = Color.Red;
            }
            else // 部分安装
            {
                BtnInst.Enabled = true;
                BtnInst.Text = "修复";
                BtnUninstall.Enabled = true;
                noticeLbl.Text = "部分驱动未安装请修复";
                noticeLbl.ForeColor = Color.DarkOrange;
            }
        }

        public bool CheckInstall()
        {
            // 检测 AirPcap 是否已安装
            int DllCount = 0;
            if (File.Exists(SysDir + @"\airpcap.dll")) DllCount++;
            if (File.Exists(SysWOW + @"\airpcap.dll")) DllCount++;
            if (DllCount == 2)
            {
                AirpcapInstSt.Text = "已安装";
                AirpcapInstSt.ForeColor = Color.Green;
                isAirpcapInst = true;
            }
            else if (DllCount == 1)
            {
                if (X64)
                {
                    AirpcapInstSt.Text = "已安装，但不完整";
                    AirpcapInstSt.ForeColor = Color.DarkOrange;
                    isAirpcapInst = false;
                }
                else
                {
                    AirpcapInstSt.Text = "已安装";
                    AirpcapInstSt.ForeColor = Color.Green;
                    isAirpcapInst = true;
                }
            }
            else
            {
                AirpcapInstSt.Text = "未安装";
                AirpcapInstSt.ForeColor = Color.Red;
                isAirpcapInst = false;
            }

            // 检测 WinPcap 是否已安装
            DllCount = 0;
            if (File.Exists(SysDir + @"\drivers\npf.sys")) DllCount++;
            try { if (new ServiceController("npf").Status == ServiceControllerStatus.Running) DllCount++; } catch { }
            if (DllCount == 2)
            {
                WinpcapInstSt.Text = "已安装";
                WinpcapInstSt.ForeColor = Color.Green;
                isWinpcapInst = true;
            }
            else if (DllCount == 1)
            {
                WinpcapInstSt.Text = "已安装，但未运行";
                WinpcapInstSt.ForeColor = Color.DarkOrange;
                isWinpcapInst = true;
            }
            else
            {
                WinpcapInstSt.Text = "未安装";
                WinpcapInstSt.ForeColor = Color.Red;
                isWinpcapInst = false;
            }

            // 检测 TRLNDIS 是否已安装
            DllCount = 0;
            if (File.Exists(SysDir + @"\drivers\TRLNDISMON.sys")) DllCount++;
            try { if (new ServiceController("TRLNDISMON").Status == ServiceControllerStatus.Running) DllCount++; } catch { }
            if (DllCount == 2)
            {
                TarlogicInstSt.Text = "已安装";
                TarlogicInstSt.ForeColor = Color.Green;
                isTarlogicInst = true;
            }
            else if (DllCount == 1)
            {
                TarlogicInstSt.Text = "已安装，但未加载成功";
                TarlogicInstSt.ForeColor = Color.DarkOrange;
                isTarlogicInst = false;
            }
            else
            {
                TarlogicInstSt.Text = "未安装";
                TarlogicInstSt.ForeColor = Color.Red;
                isTarlogicInst = false;
            }

            return isAirpcapInst && isWinpcapInst && isTarlogicInst;
        }

        public void runCmd(string path, string args)
        {
            ProcessStartInfo cmdsi = new ProcessStartInfo(path);
            cmdsi.Arguments = args;
            Process cmd = Process.Start(cmdsi);
            cmd.WaitForExit();
        }

        private void BtnInst_Click(object sender, EventArgs e)
        {
            this.TopMost = false;// 取消置顶

            var permissionSet = new PermissionSet(PermissionState.None);
            var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, SysDir);
            permissionSet.AddPermission(writePermission);
            writePermission = new FileIOPermission(FileIOPermissionAccess.Write, SysWOW);
            permissionSet.AddPermission(writePermission);

            if (!isAirpcapInst)
            {
                bool hasError = false;
                if (X64)
                {
                    try { File.Copy(AppDir + @"\Drivers\x64\airpcap.dll", SysDir + @"\airpcap.dll"); hasError = false; } catch { hasError = true; }
                    try { File.Copy(AppDir + @"\Drivers\x86\airpcap.dll", SysWOW + @"\airpcap.dll"); hasError = false; } catch { hasError = true; }
                }
                else
                {
                    try { File.Copy(AppDir + @"\Drivers\x86\airpcap.dll", SysDir + @"\airpcap.dll"); hasError = false; } catch { hasError = true; }
                }
                AirpcapInstSt.Text = "安装完成";
                AirpcapInstSt.ForeColor = Color.Green;
                isAirpcapInst = true;

                if (hasError)
                {
                    AirpcapInstSt.Text = "安装过程出现错误";
                    AirpcapInstSt.ForeColor = Color.Red;
                    isAirpcapInst = false;
                }
            }

            if (!isTarlogicInst)
            {
                try
                {
                    if (X64)
                    {
                        runCmd(AppDir + @"\Drivers\TRLNDIS_Installer64.exe", "1 1 1");
                    }
                    else
                    {
                        runCmd(AppDir + @"\Drivers\TRLNDIS_Installer32.exe", "1 1 1");
                    }
                    TarlogicInstSt.Text = "安装完成";
                    TarlogicInstSt.ForeColor = Color.Green;
                    isTarlogicInst = true;
                }
                catch
                {
                    TarlogicInstSt.Text = "安装过程出现错误";
                    TarlogicInstSt.ForeColor = Color.Red;
                    isTarlogicInst = false;
                }
            }

            if (!isWinpcapInst)
            {
                try
                {
                    runCmd(AppDir + @"\Drivers\WinPcap.exe", "");

                    WinpcapInstSt.Text = "安装完成";
                    WinpcapInstSt.ForeColor = Color.Green;
                    isWinpcapInst = true;
                }
                catch
                {
                    WinpcapInstSt.Text = "安装过程出现错误";
                    WinpcapInstSt.ForeColor = Color.Red;
                    isWinpcapInst = false;
                }
            }
            MessageBox.Show("驱动全部安装完成，将重新启动萌签！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Restart();
        }

        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("这将会导致程序退出，请先保存数据！继续吗？", "确定要卸载所有驱动吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ProcessStartInfo cmdsi = new ProcessStartInfo(AppDir + @"\Drivers\DrvUninst.exe");
                    Process cmd = Process.Start(cmdsi);
                }
                catch
                {
                }
                Application.Exit();
            }
        }
    }
}
