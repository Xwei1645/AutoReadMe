using CommunityToolkit.Mvvm.ComponentModel;

namespace AutoReadMe.Models;

public class Settings : ObservableRecipient
{
    private bool _showAgain = true;
    private string _welcomeText = "欢迎使用经过魔改后超级好用的电子白板！为了帮助你更好的了解相关软件的使用方法，我们编写了一份详细的说明文档，如果你需要阅读，请单击“打开”或“仅本次打开”；如果不需要，请单击“不打开”。";
    private string _readMePath = "";

    public bool ShowAgain
    {
        get => _showAgain;
        set
        {
            if (value == _showAgain) return;
            _showAgain = value;
            OnPropertyChanged();
        }
    }

    public string WelcomeText
    {
        get => _welcomeText;
        set
        {
            if (value == _welcomeText) return;
            _welcomeText = value;
            OnPropertyChanged();
        }
    }

    public string ReadMePath
    {
        get => _readMePath;
        set
        {
            if (value == _readMePath) return;
            _readMePath = value;
            OnPropertyChanged();
        }
    }
}