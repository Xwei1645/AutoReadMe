using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Controls.CommonDialog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using ClassIsland.Core.Extensions.Registry;
using AutoReadMe.Models;
using AutoReadMe.Views.SettingsPages;
using System;

namespace AutoReadMe
{
    [PluginEntrance]
    public class Plugin : PluginBase
    {
        // 新增 Settings 属性
        public Settings Settings { get; private set; }

        public Plugin()
        {
            // 在构造函数中初始化 Settings
            Settings = new Settings();
        }

        public override void Initialize(HostBuilderContext context, IServiceCollection services)
        {
            var dialogActions = new ObservableCollection<DialogAction>()
            {
                new DialogAction()
                {
                    PackIconKind = PackIconKind.OpenInNew,
                    Name = "打开",
                    IsPrimary = true
                },
                new DialogAction()
                {
                    PackIconKind = PackIconKind.OpenInNew,
                    Name = "仅本次打开",
                    IsPrimary = true
                },
                new DialogAction()
                {
                    PackIconKind = PackIconKind.Cancel,
                    Name = "不打开",
                    IsPrimary = true
                }
            };

            // 显示弹窗
            string mainText = Settings.WelcomeText;
            var result = CommonDialog.ShowDialog("欢迎", mainText, new BitmapImage(new Uri("https://i0.hdslb.com/bfs/garb/88c671c2156928dbc284ea9820c2a8bed317716d.png", UriKind.Relative)), 60, 60, dialogActions);
            Console.WriteLine("显示 AutoReadMe 弹窗");
            Console.WriteLine($"弹窗内容: {mainText}");

            Console.WriteLine($"用户选择的按钮索引: {result}");

            // 根据用户选择的按钮执行相应操作并输出到控制台
            if (result == 0)
            {
                OpenReadMe();
            }
            else if (result == 1)
            {
                OpenReadMe();
                Settings.ShowAgain = false;
                Console.WriteLine("关闭“每次显示”");
            }
            else if (result == 2)
            {
                Settings.ShowAgain = false;
                Console.WriteLine("不打开 README 文件");
            }

            services.AddSingleton(Settings);
            services.AddSettingsPage<SettingsPage>();
        }

        private void OpenReadMe()
        {
            // 打开 README 文件的逻辑
            string readMePath = Settings.ReadMePath;
            if (!string.IsNullOrEmpty(readMePath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = readMePath,
                    UseShellExecute = true
                });
                Console.WriteLine($"打开 README 文件: {readMePath}");
            }
            else
            {
                Console.WriteLine("README 文件路径为空");
            }
        }
    }
}
