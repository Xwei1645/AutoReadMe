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
        // ���� Settings ����
        public Settings Settings { get; private set; }

        public Plugin()
        {
            // �ڹ��캯���г�ʼ�� Settings
            Settings = new Settings();
        }

        public override void Initialize(HostBuilderContext context, IServiceCollection services)
        {
            var dialogActions = new ObservableCollection<DialogAction>()
            {
                new DialogAction()
                {
                    PackIconKind = PackIconKind.OpenInNew,
                    Name = "��",
                    IsPrimary = true
                },
                new DialogAction()
                {
                    PackIconKind = PackIconKind.OpenInNew,
                    Name = "�����δ�",
                    IsPrimary = true
                },
                new DialogAction()
                {
                    PackIconKind = PackIconKind.Cancel,
                    Name = "����",
                    IsPrimary = true
                }
            };

            // ��ʾ����
            string mainText = Settings.WelcomeText;
            var result = CommonDialog.ShowDialog("��ӭ", mainText, new BitmapImage(new Uri("https://i0.hdslb.com/bfs/garb/88c671c2156928dbc284ea9820c2a8bed317716d.png", UriKind.Relative)), 60, 60, dialogActions);
            Console.WriteLine("��ʾ AutoReadMe ����");
            Console.WriteLine($"��������: {mainText}");

            Console.WriteLine($"�û�ѡ��İ�ť����: {result}");

            // �����û�ѡ��İ�ťִ����Ӧ���������������̨
            if (result == 0)
            {
                OpenReadMe();
            }
            else if (result == 1)
            {
                OpenReadMe();
                Settings.ShowAgain = false;
                Console.WriteLine("�رա�ÿ����ʾ��");
            }
            else if (result == 2)
            {
                Settings.ShowAgain = false;
                Console.WriteLine("���� README �ļ�");
            }

            services.AddSingleton(Settings);
            services.AddSettingsPage<SettingsPage>();
        }

        private void OpenReadMe()
        {
            // �� README �ļ����߼�
            string readMePath = Settings.ReadMePath;
            if (!string.IsNullOrEmpty(readMePath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = readMePath,
                    UseShellExecute = true
                });
                Console.WriteLine($"�� README �ļ�: {readMePath}");
            }
            else
            {
                Console.WriteLine("README �ļ�·��Ϊ��");
            }
        }
    }
}
