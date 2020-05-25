using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using Update;

namespace autoUpdate
{

    public partial class Form1 : Form
    {
        [DllImport("zipfile.dll")]
        public static extern int MyZip_ExtractFileAll(string zipfile, string pathname);
        public Form1()
        {
            InitializeComponent();
            //清除之前下载来的rar文件
            if (File.Exists(Application.StartupPath + "\\Update_autoUpdate.zip"))
            {
                try
                {
                    File.Delete(Application.StartupPath + "\\Update_autoUpdate.zip");
                }
                catch (Exception)
                {


                }

            }
            if (Directory.Exists(Application.StartupPath + "\\autoupload"))
            {
                try
                {
                    Directory.Delete(Application.StartupPath + "\\autoupload", true);
                }
                catch (Exception)
                {


                }
            }

            //检查服务端是否有新版本程序
            checkUpdate();
            timer1.Enabled = true;
        }
        SoftUpdate app = new SoftUpdate(Application.ExecutablePath, "ExceTransforCsv");
        public void checkUpdate()
        {

            app.UpdateFinish += new UpdateState(app_UpdateFinish);
            try
            {
                if (app.IsUpdate)
                {
                    app.Update();
                }
                else
                {
                    MessageBox.Show("未检测到新版本!");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void app_UpdateFinish()
        {
            //解压下载后的文件
            string path = app.FinalZipName;
            if (File.Exists(path))
            {
                //后改的 先解压滤波zip植入ini然后再重新压缩
                string dirEcgPath = Application.StartupPath + "\\" + "autoupload";
                if (!Directory.Exists(dirEcgPath))
                {
                    Directory.CreateDirectory(dirEcgPath);
                }
                //开始解压压缩包
                MyZip_ExtractFileAll(path, dirEcgPath);

                try
                {
                    //复制新文件替换旧文件
                    DirectoryInfo TheFolder = new DirectoryInfo(dirEcgPath);
                    foreach (FileInfo NextFile in TheFolder.GetFiles())
                    {
                        File.Copy(NextFile.FullName, Application.StartupPath + "\\program\\" + NextFile.Name, true);
                    }
                    Directory.Delete(dirEcgPath, true);
                    File.Delete(path);
                    //覆盖完成 重新启动程序
                    path = Application.StartupPath + "\\program";
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "ExceTransforCsv.exe";
                    process.StartInfo.WorkingDirectory = path;//要掉用得exe路径例如:"C:\windows";               
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    Application.Exit();
                }
                catch (Exception)
                {
                    MessageBox.Show("请关闭系统在执行更新操作!");
                    Application.Exit();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "下载文件进度:" + COMMON.CommonMethod.autostep.ToString() + "%";
            this.progressBar1.Value = COMMON.CommonMethod.autostep;
            if (COMMON.CommonMethod.autostep == 100)
            {
                timer1.Enabled = false;
            }
        }
    }
}
