using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows;
using System;

namespace DrawBoard.Models
{
    public partial class SaveModel : ObservableObject
    {
        #region :: Members ::

        #region :: Window ::

        [ObservableProperty]
        private double _windowWidth = 885d;
        [ObservableProperty]
        private double _windowHeight = 635d;

        #endregion

        #region :: Game Count ::

        [ObservableProperty]
        private int _winLoseGameCount = 50;
        [ObservableProperty]
        private int _winCount = 3;

        [ObservableProperty]
        private int _rankingGameCount = 50;
        [ObservableProperty]
        private int _firstCount = 1;
        [ObservableProperty]
        private int _secondCount = 2;
        [ObservableProperty]
        private int _thirdCount = 3;
        [ObservableProperty]
        private int _fourthCount = 4;
        [ObservableProperty]
        private int _fifthCount = 5;
        [ObservableProperty]
        private int _sixthCount = 6;
        [ObservableProperty]
        private int _seventhCount = 7;

        #endregion

        #region :: Text ::

        [ObservableProperty]
        private string _winText = "당첨";
        [ObservableProperty]
        private string _loseText = "꽝";

        [ObservableProperty]
        private string _rankingLoseText = "꽝";
        [ObservableProperty]
        private string _firstText = "1등";
        [ObservableProperty]
        private string _secondText = "2등";
        [ObservableProperty]
        private string _thirdText = "3등";
        [ObservableProperty]
        private string _fourthText = "4등";
        [ObservableProperty]
        private string _fifthText = "5등";
        [ObservableProperty]
        private string _sixthText = "6등";
        [ObservableProperty]
        private string _seventhText = "7등";

        [ObservableProperty]
        private double _winLoseTextSize = 30d;
        [ObservableProperty]
        private double _winLoseNumberTextSize = 40d;

        [ObservableProperty]
        private double _rankingTextSize = 30d;
        [ObservableProperty]
        private double _rankingNumberTextSize = 40d;

        #endregion

        #region :: Color ::

        [ObservableProperty]
        private Color? _winLoseBackgroundColor = (Color)ColorConverter.ConvertFromString("#FF4B0082");
        [ObservableProperty]
        private Color? _rankingBackgroundColor = (Color)ColorConverter.ConvertFromString("#FF4B0082");

        [ObservableProperty]
        private Color? _winLoseWinBackgroundColor = (Color)ColorConverter.ConvertFromString("#00FFFFFF");
        [ObservableProperty]
        private Color? _rankingWinBackgroundColor = (Color)ColorConverter.ConvertFromString("#00FFFFFF");

        [ObservableProperty]
        private Color? _winLoseLoseBackgroundColor = (Color)ColorConverter.ConvertFromString("#00FFFFFF");
        [ObservableProperty]
        private Color? _rankingLoseBackgroundColor = (Color)ColorConverter.ConvertFromString("#00FFFFFF");

        [ObservableProperty]
        private Color? _winLoseNumberColor = (Color)ColorConverter.ConvertFromString("#FFEEE8AA");
        [ObservableProperty]
        private Color? _rankingNumberColor = (Color)ColorConverter.ConvertFromString("#FFEEE8AA");

        [ObservableProperty]
        private Color? _winLoseWinColor = (Color)ColorConverter.ConvertFromString("#FF00FF00");
        [ObservableProperty]
        private Color? _rankingWinColor = (Color)ColorConverter.ConvertFromString("#FF00FF00");

        [ObservableProperty]
        private Color? _winLoseLoseColor = (Color)ColorConverter.ConvertFromString("#FFFF0000");
        [ObservableProperty]
        private Color? _rankingLoseColor = (Color)ColorConverter.ConvertFromString("#FFFF0000");

        [ObservableProperty]
        private Color? _winLosePanelColor = (Color)ColorConverter.ConvertFromString("#00FFFFFF");
        [ObservableProperty]
        private Color? _rankingPanelColor = (Color)ColorConverter.ConvertFromString("#00FFFFFF");

        #endregion

        #region :: Font ::

        [ObservableProperty]
        private ObservableCollection<string> _fontList = new();

        [ObservableProperty]
        private string? _selectedWinLoseFont = "GulimChe";
        [ObservableProperty]
        private string? _selectedRankingFont = "GulimChe";

        #endregion

        #region :: Sound ::

        [ObservableProperty]
        private double _winVolume = 0.5d;

        [ObservableProperty]
        private double _loseVolume = 0.5d;

        [ObservableProperty]
        private string? _winSoundPath = $"{AppDomain.CurrentDomain.BaseDirectory}SoundEffect\\Win.mp3";

        [ObservableProperty]
        private string? _loseSoundPath = $"{AppDomain.CurrentDomain.BaseDirectory}SoundEffect\\Lose.mp3";

        #endregion

        #region :: ListBox ::

        [ObservableProperty]
        private ObservableCollection<DrawModel> _drawWinLoseList = new();

        [ObservableProperty]
        private ObservableCollection<DrawModel> _drawRankingList = new();

        [ObservableProperty]
        private double _winLoseBoxWidth = 100d;
        [ObservableProperty]
        private double _winLoseBoxHeight = 60d;

        [ObservableProperty]
        private double _rankingBoxWidth = 100d;
        [ObservableProperty]
        private double _rankingBoxHeight = 60d;

        //[ObservableProperty]
        //private Brush? _winLoseListBoxBackground;
        [ObservableProperty]
        private string? _winLoseImagePath;

        //[ObservableProperty]
        //private Brush? _rankingListBoxBackground;
        [ObservableProperty]
        private string? _rankingImagePath;

        [ObservableProperty]
        private Stretch _winLoseImageStretch = Stretch.None;
        [ObservableProperty]
        private Stretch _rankingImageStretch = Stretch.None;

        [ObservableProperty]
        private bool _isWinLoseStretchNone = true;
        [ObservableProperty]
        private bool _isWinLoseStretchFill;
        [ObservableProperty]
        private bool _isWinLoseStretchUniform;
        [ObservableProperty]
        private bool _isWinLoseStretchNoneUniformToFill;

        [ObservableProperty]
        private bool _isRankingStretchNone = true;
        [ObservableProperty]
        private bool _isRankingStretchFill;
        [ObservableProperty]
        private bool _isRankingStretchUniform;
        [ObservableProperty]
        private bool _isRankingStretchNoneUniformToFill;

        #endregion

        #region :: Visible ::

        //[ObservableProperty]
        //private Visibility _winLoseSettingVisible = Visibility.Visible;
        //[ObservableProperty]
        //private Visibility _rankingSettingVisible = Visibility.Collapsed;
        //[ObservableProperty]
        //private Visibility _textSettingVisible = Visibility.Collapsed;
        //[ObservableProperty]
        //private Visibility _boxSettingVisible = Visibility.Collapsed;
        //[ObservableProperty]
        //private Visibility _colorSettingVisible = Visibility.Collapsed;
        //[ObservableProperty]
        //private Visibility _soundSettingVisible = Visibility.Collapsed;
        //[ObservableProperty]
        //private Visibility _etcSettingVisible = Visibility.Collapsed;

        //[ObservableProperty]
        //private Visibility _winLoseListBoxVisible = Visibility.Visible;
        //[ObservableProperty]
        //private Visibility _rankingListBoxVisible = Visibility.Collapsed;

        //[ObservableProperty]
        //private bool _isRadioWinLoseUse = true;
        //[ObservableProperty]
        //private bool _isRadioRankingUse = false;

        #endregion


        #endregion
    }
}
