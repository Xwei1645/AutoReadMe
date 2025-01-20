using ClassIsland.Core.Abstractions.Controls;
using ClassIsland.Core.Attributes;
using MaterialDesignThemes.Wpf;

namespace AutoReadMe.Views.SettingsPages;

/// <summary>
/// ExampleSettingsPage.xaml 的交互逻辑
/// </summary>
[SettingsPageInfo("Xwei1645.AutoReadMe", "AutoReadMe", PackIconKind.CogOutline, PackIconKind.Cog)]
public partial class SettingsPage : SettingsPageBase
{
    public Plugin Plugin { get; }

    public SettingsPage(Plugin plugin)
    {
        Plugin = plugin;
        InitializeComponent();
        DataContext = this;
    }
}