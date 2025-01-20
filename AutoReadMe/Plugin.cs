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
            var result = CommonDialog.ShowDialog("欢迎", "消息内容", new BitmapImage(new Uri("", UriKind.Relative)), 60, 60, dialogActions);

            services.AddSettingsPage<AutoReadMeSettingsPage>();
        }
    }
}