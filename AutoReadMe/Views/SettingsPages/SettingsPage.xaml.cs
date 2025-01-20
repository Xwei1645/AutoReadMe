using ClassIsland.Core.Abstractions.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassIsland.Core.Attributes;
using MaterialDesignThemes.Wpf;
using AutoReadMe;

namespace AutoReadMe.Views.SettingsPages;

/// <summary>
/// ExampleSettingsPage.xaml 的交互逻辑
/// </summary>
[SettingsPageInfo("Xwei1645.AutoReadMe", "AutoReadMe", PackIconKind.CogOutline, PackIconKind.Cog)]
public partial class ExampleSettingsPage : SettingsPageBase
{
    public Plugin Plugin { get; }

    public ExampleSettingsPage(Plugin plugin)
    {
        Plugin = plugin;
        InitializeComponent();
        DataContext = this;
    }
}