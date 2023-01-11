using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_Community_Client.Service.AutoUpdata
{
    public class AutoUpdata
    {

        //注册自动更新
        public static void Client_Update()
        {
            Thread.CurrentThread.CurrentCulture =
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("zh");
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Start("http://47.109.60.217:81/AutoUpdata/autoupdata.xml");//这个地方写你的自更新配置文件读取地址
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
        }


        private static void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            var messageBox = new Wpf.Ui.Controls.MessageBox();
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        dialogResult =
                        MessageBox.Show(
                           $@"xxx客户端新版本: {args.CurrentVersion} 发布. 您正在使用版本 {args.InstalledVersion}. 这是必需的更新,按确定开始更新应用程序.", @"xxx客户端更新",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information);

                    }
                    else
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"Xxx客户端新版本 {args.CurrentVersion} 发布. 您正在使用版本 {args.InstalledVersion}. 是否要立即更新应用程序?", @"xxx客户端更新",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                    }

                    // 如果您想显示标准更新对话框，请取消注释以下行。
                    AutoUpdater.ShowUpdateForm(args);

                    if (dialogResult.Equals(true))
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    //MessageBox.Show(@"没有可用的更新请稍后再试.", @"没有可用的更新",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (args.Error is WebException)
                {
                    MessageBox.Show(
                        @"连接更新服务器时出现问题.请检查您的互联网连接并稍后重试.",
                        @"更新检查失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

    }
}
