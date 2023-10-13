using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

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
        private string _loseText = "";

        [ObservableProperty]
        private string _rankingLoseText = "";
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
        private double _winLoseTextSize = 25d;
        [ObservableProperty]
        private double _winLoseNumberTextSize = 35d;

        [ObservableProperty]
        private double _rankingTextSize = 25d;
        [ObservableProperty]
        private double _rankingNumberTextSize = 35d;

        #endregion

        #region :: Color ::

        [ObservableProperty]
        private Color? _winLoseBackgroundColor = (Color)ColorConverter.ConvertFromString("#FFDD2476");
        [ObservableProperty]
        private Color? _rankingBackgroundColor = (Color)ColorConverter.ConvertFromString("#FFDD2476");

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

        [ObservableProperty]
        private Color? _backgroundColor1 = (Color)ColorConverter.ConvertFromString("#FF000000");
        [ObservableProperty]
        private Color? _backgroundColor2 = (Color)ColorConverter.ConvertFromString("#0A38A2D7");

        #endregion

        #region :: Font ::

        [ObservableProperty]
        private ObservableCollection<string> _fontList = new();

        [ObservableProperty]
        private string? _selectedWinLoseFont = "Arial";
        [ObservableProperty]
        private string? _selectedRankingFont = "Arial";

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
        private double _winLoseBoxWidth = 60d;
        [ObservableProperty]
        private double _winLoseBoxHeight = 45d;

        [ObservableProperty]
        private double _rankingBoxWidth = 60d;
        [ObservableProperty]
        private double _rankingBoxHeight = 45d;

        //[ObservableProperty]
        //private Brush? _winLoseListBoxBackground;
        [ObservableProperty]
        private string? _winLoseImagePath;

        //[ObservableProperty]
        //private Brush? _rankingListBoxBackground;
        [ObservableProperty]
        private string? _rankingImagePath;

        [ObservableProperty]
        private Stretch _winLoseImageStretch = Stretch.Uniform;
        [ObservableProperty]
        private Stretch _rankingImageStretch = Stretch.Uniform;

        [ObservableProperty]
        private bool _isWinLoseStretchNone;
        [ObservableProperty]
        private bool _isWinLoseStretchFill;
        [ObservableProperty]
        private bool _isWinLoseStretchUniform = true;
        [ObservableProperty]
        private bool _isWinLoseStretchNoneUniformToFill;

        [ObservableProperty]
        private bool _isRankingStretchNone;
        [ObservableProperty]
        private bool _isRankingStretchFill;
        [ObservableProperty]
        private bool _isRankingStretchUniform = true;
        [ObservableProperty]
        private bool _isRankingStretchNoneUniformToFill;

        #endregion

        #region :: Opacity ::
        [ObservableProperty]
        private double _opacityValue = 0.8d;

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

        public static SaveModel SaveSetting(MainWindowViewModel viewModel)
        {
            var model = new SaveModel();

            #region :: Model ::

            model.WindowWidth = viewModel.WindowWidth;
            model.WindowHeight = viewModel.WindowHeight;
            model.WinLoseGameCount = viewModel.WinLoseGameCount;
            model.WinCount = viewModel.WinCount;
            model.RankingGameCount = viewModel.RankingGameCount;
            model.FirstCount = viewModel.FirstCount;
            model.SecondCount = viewModel.SecondCount;

            model.ThirdCount = viewModel.ThirdCount;
            model.FourthCount = viewModel.FourthCount;
            model.FifthCount = viewModel.FifthCount;
            model.SixthCount = viewModel.SixthCount;
            model.SeventhCount = viewModel.SeventhCount;

            model.WinText = viewModel.WinText;
            model.LoseText = viewModel.LoseText;
            model.RankingLoseText = viewModel.RankingLoseText;
            model.FirstText = viewModel.FirstText;
            model.SecondText = viewModel.SecondText;
            model.ThirdText = viewModel.ThirdText;
            model.FourthText = viewModel.FourthText;
            model.FifthText = viewModel.FifthText;
            model.SixthText = viewModel.SixthText;
            model.SeventhText = viewModel.SeventhText;
            model.WinLoseTextSize = viewModel.WinLoseTextSize;
            model.WinLoseNumberTextSize = viewModel.WinLoseNumberTextSize;
            model.RankingTextSize = viewModel.RankingTextSize;
            model.RankingNumberTextSize = viewModel.RankingNumberTextSize;

            model.WinLoseBackgroundColor = viewModel.WinLoseBackgroundColor;
            model.RankingBackgroundColor = viewModel.RankingBackgroundColor;
            model.WinLoseWinBackgroundColor = viewModel.WinLoseWinBackgroundColor;
            model.RankingWinBackgroundColor = viewModel.RankingWinBackgroundColor;
            model.WinLoseLoseBackgroundColor = viewModel.WinLoseLoseBackgroundColor;
            model.RankingLoseBackgroundColor = viewModel.RankingLoseBackgroundColor;
            model.WinLoseNumberColor = viewModel.WinLoseNumberColor;
            model.RankingNumberColor = viewModel.RankingNumberColor;
            model.WinLoseWinColor = viewModel.WinLoseWinColor;
            model.RankingWinColor = viewModel.RankingWinColor;
            model.WinLoseLoseColor = viewModel.WinLoseLoseColor;
            model.RankingLoseColor = viewModel.RankingLoseColor;
            model.WinLosePanelColor = viewModel.WinLosePanelColor;
            model.RankingPanelColor = viewModel.RankingPanelColor;
            model.BackgroundColor1 = viewModel.BackgroundColor1;
            model.BackgroundColor2 = viewModel.BackgroundColor2;

            model.SelectedWinLoseFont = viewModel.SelectedWinLoseFont;
            model.SelectedRankingFont = viewModel.SelectedRankingFont;

            model.WinVolume = viewModel.WinVolume;
            model.LoseVolume = viewModel.LoseVolume;
            model.WinSoundPath = viewModel.WinSoundPath;
            model.LoseSoundPath = viewModel.LoseSoundPath;

            model.DrawWinLoseList = viewModel.DrawWinLoseList;
            model.DrawRankingList = viewModel.DrawRankingList;

            model.WinLoseBoxWidth = viewModel.WinLoseBoxWidth;
            model.WinLoseBoxHeight = viewModel.WinLoseBoxHeight;
            model.RankingBoxWidth = viewModel.RankingBoxWidth;
            model.RankingBoxHeight = viewModel.RankingBoxHeight;

            //model.WinLoseListBoxBackground = viewModel.WinLoseListBoxBackground;
            model.WinLoseImagePath = viewModel.WinLoseImagePath;

            //model.RankingListBoxBackground = viewModel.RankingListBoxBackground;
            model.RankingImagePath = viewModel.RankingImagePath;

            model.WinLoseImageStretch = viewModel.WinLoseImageStretch;
            model.RankingImageStretch = viewModel.RankingImageStretch;

            model.IsWinLoseStretchNone = viewModel.IsWinLoseStretchNone;
            model.IsWinLoseStretchFill = viewModel.IsWinLoseStretchFill;
            model.IsWinLoseStretchUniform = viewModel.IsWinLoseStretchUniform;
            model.IsWinLoseStretchNoneUniformToFill = viewModel.IsWinLoseStretchNoneUniformToFill;

            model.IsRankingStretchNone = viewModel.IsRankingStretchNone;
            model.IsRankingStretchFill = viewModel.IsRankingStretchFill;
            model.IsRankingStretchUniform = viewModel.IsRankingStretchUniform;
            model.IsRankingStretchNoneUniformToFill = viewModel.IsRankingStretchNoneUniformToFill;

            model.OpacityValue = viewModel.OpacityValue;

            #region :: Visible ::

            //private Visibility _winLoseSettingVisible = Visibility.Visible;                
            //private Visibility _rankingSettingVisible = Visibility.Collapsed;
            //private Visibility _textSettingVisible = Visibility.Collapsed;
            //private Visibility _boxSettingVisible = Visibility.Collapsed;
            //private Visibility _colorSettingVisible = Visibility.Collapsed;
            //private Visibility _soundSettingVisible = Visibility.Collapsed;
            //private Visibility _etcSettingVisible = Visibility.Collapsed;

            //private Visibility _winLoseListBoxVisible = Visibility.Visible;
            //private Visibility _rankingListBoxVisible = Visibility.Collapsed;

            //private bool _isRadioWinLoseUse = true;
            //private bool _isRadioRankingUse = false;

            #endregion

            #endregion

            return model;
        }

        public static void OpenSetting(SaveModel model, MainWindowViewModel viewModel)
        {
            #region :: Model ::

            viewModel.WindowWidth = model.WindowWidth;
            viewModel.WindowHeight = model.WindowHeight;
            viewModel.WinLoseGameCount = model.WinLoseGameCount;
            viewModel.WinCount = model.WinCount;
            viewModel.RankingGameCount = model.RankingGameCount;
            viewModel.FirstCount = model.FirstCount;
            viewModel.SecondCount = model.SecondCount;

            viewModel.ThirdCount = model.ThirdCount;
            viewModel.FourthCount = model.FourthCount;
            viewModel.FifthCount = model.FifthCount;
            viewModel.SixthCount = model.SixthCount;
            viewModel.SeventhCount = model.SeventhCount;

            viewModel.WinText = model.WinText;
            viewModel.LoseText = model.LoseText;
            viewModel.RankingLoseText = model.RankingLoseText;
            viewModel.FirstText = model.FirstText;
            viewModel.SecondText = model.SecondText;
            viewModel.ThirdText = model.ThirdText;
            viewModel.FourthText = model.FourthText;
            viewModel.FifthText = model.FifthText;
            viewModel.SixthText = model.SixthText;
            viewModel.SeventhText = model.SeventhText;
            viewModel.WinLoseTextSize = model.WinLoseTextSize;
            viewModel.WinLoseNumberTextSize = model.WinLoseNumberTextSize;
            viewModel.RankingTextSize = model.RankingTextSize;
            viewModel.RankingNumberTextSize = model.RankingNumberTextSize;

            viewModel.WinLoseBackgroundColor = model.WinLoseBackgroundColor;
            viewModel.RankingBackgroundColor = model.RankingBackgroundColor;
            viewModel.WinLoseWinBackgroundColor = model.WinLoseWinBackgroundColor;
            viewModel.RankingWinBackgroundColor = model.RankingWinBackgroundColor;
            viewModel.WinLoseLoseBackgroundColor = model.WinLoseLoseBackgroundColor;
            viewModel.RankingLoseBackgroundColor = model.RankingLoseBackgroundColor;
            viewModel.WinLoseNumberColor = model.WinLoseNumberColor;
            viewModel.RankingNumberColor = model.RankingNumberColor;
            viewModel.WinLoseWinColor = model.WinLoseWinColor;
            viewModel.RankingWinColor = model.RankingWinColor;
            viewModel.WinLoseLoseColor = model.WinLoseLoseColor;
            viewModel.RankingLoseColor = model.RankingLoseColor;
            viewModel.WinLosePanelColor = model.WinLosePanelColor;
            viewModel.RankingPanelColor = model.RankingPanelColor;
            viewModel.BackgroundColor1 = model.BackgroundColor1;
            viewModel.BackgroundColor2 = model.BackgroundColor2;

            viewModel.SelectedWinLoseFont = model.SelectedWinLoseFont;
            viewModel.SelectedRankingFont = model.SelectedRankingFont;

            viewModel.WinVolume = model.WinVolume;
            viewModel.LoseVolume = model.LoseVolume;
            viewModel.WinSoundPath = model.WinSoundPath;
            viewModel.LoseSoundPath = model.LoseSoundPath;

            viewModel.DrawWinLoseList = model.DrawWinLoseList;
            viewModel.DrawRankingList = model.DrawRankingList;

            viewModel.WinLoseBoxWidth = model.WinLoseBoxWidth;
            viewModel.WinLoseBoxHeight = model.WinLoseBoxHeight;
            viewModel.RankingBoxWidth = model.RankingBoxWidth;
            viewModel.RankingBoxHeight = model.RankingBoxHeight;

            //WinLoseListBoxBackground = model.WinLoseListBoxBackground;
            viewModel.WinLoseImagePath = model.WinLoseImagePath;

            //RankingListBoxBackground = model.RankingListBoxBackground;
            viewModel.RankingImagePath = model.RankingImagePath;

            viewModel.WinLoseImageStretch = model.WinLoseImageStretch;
            viewModel.RankingImageStretch = model.RankingImageStretch;

            viewModel.IsWinLoseStretchNone = model.IsWinLoseStretchNone;
            viewModel.IsWinLoseStretchFill = model.IsWinLoseStretchFill;
            viewModel.IsWinLoseStretchUniform = model.IsWinLoseStretchUniform;
            viewModel.IsWinLoseStretchNoneUniformToFill = model.IsWinLoseStretchNoneUniformToFill;

            viewModel.IsRankingStretchNone = model.IsRankingStretchNone;
            viewModel.IsRankingStretchFill = model.IsRankingStretchFill;
            viewModel.IsRankingStretchUniform = model.IsRankingStretchUniform;
            viewModel.IsRankingStretchNoneUniformToFill = model.IsRankingStretchNoneUniformToFill;

            viewModel.OpacityValue = model.OpacityValue;

            #endregion
        }

        public static SaveModel WindowSaveSetting(MainWindowViewModel viewModel)
        {
            var model = new SaveModel();

            #region :: Model ::

            model.WindowWidth = viewModel.WindowWidth;
            model.WindowHeight = viewModel.WindowHeight;
            model.WinLoseGameCount = viewModel.WinLoseGameCount;
            model.WinCount = viewModel.WinCount;
            model.RankingGameCount = viewModel.RankingGameCount;
            model.FirstCount = viewModel.FirstCount;
            model.SecondCount = viewModel.SecondCount;

            model.ThirdCount = viewModel.ThirdCount;
            model.FourthCount = viewModel.FourthCount;
            model.FifthCount = viewModel.FifthCount;
            model.SixthCount = viewModel.SixthCount;
            model.SeventhCount = viewModel.SeventhCount;

            model.WinText = viewModel.WinText;
            model.LoseText = viewModel.LoseText;
            model.RankingLoseText = viewModel.RankingLoseText;
            model.FirstText = viewModel.FirstText;
            model.SecondText = viewModel.SecondText;
            model.ThirdText = viewModel.ThirdText;
            model.FourthText = viewModel.FourthText;
            model.FifthText = viewModel.FifthText;
            model.SixthText = viewModel.SixthText;
            model.SeventhText = viewModel.SeventhText;
            model.WinLoseTextSize = viewModel.WinLoseTextSize;
            model.WinLoseNumberTextSize = viewModel.WinLoseNumberTextSize;
            model.RankingTextSize = viewModel.RankingTextSize;
            model.RankingNumberTextSize = viewModel.RankingNumberTextSize;

            model.WinLoseBackgroundColor = viewModel.WinLoseBackgroundColor;
            model.RankingBackgroundColor = viewModel.RankingBackgroundColor;
            model.WinLoseWinBackgroundColor = viewModel.WinLoseWinBackgroundColor;
            model.RankingWinBackgroundColor = viewModel.RankingWinBackgroundColor;
            model.WinLoseLoseBackgroundColor = viewModel.WinLoseLoseBackgroundColor;
            model.RankingLoseBackgroundColor = viewModel.RankingLoseBackgroundColor;
            model.WinLoseNumberColor = viewModel.WinLoseNumberColor;
            model.RankingNumberColor = viewModel.RankingNumberColor;
            model.WinLoseWinColor = viewModel.WinLoseWinColor;
            model.RankingWinColor = viewModel.RankingWinColor;
            model.WinLoseLoseColor = viewModel.WinLoseLoseColor;
            model.RankingLoseColor = viewModel.RankingLoseColor;
            model.WinLosePanelColor = viewModel.WinLosePanelColor;
            model.RankingPanelColor = viewModel.RankingPanelColor;
            model.BackgroundColor1 = viewModel.BackgroundColor1;
            model.BackgroundColor2 = viewModel.BackgroundColor2;

            model.SelectedWinLoseFont = viewModel.SelectedWinLoseFont;
            model.SelectedRankingFont = viewModel.SelectedRankingFont;

            model.WinVolume = viewModel.WinVolume;
            model.LoseVolume = viewModel.LoseVolume;
            model.WinSoundPath = viewModel.WinSoundPath;
            model.LoseSoundPath = viewModel.LoseSoundPath;

            model.DrawWinLoseList = viewModel.DrawWinLoseList;
            model.DrawRankingList = viewModel.DrawRankingList;

            model.WinLoseBoxWidth = viewModel.WinLoseBoxWidth;
            model.WinLoseBoxHeight = viewModel.WinLoseBoxHeight;
            model.RankingBoxWidth = viewModel.RankingBoxWidth;
            model.RankingBoxHeight = viewModel.RankingBoxHeight;

            //model.WinLoseListBoxBackground = viewModel.WinLoseListBoxBackground;
            model.WinLoseImagePath = viewModel.WinLoseImagePath;

            //model.RankingListBoxBackground = viewModel.RankingListBoxBackground;
            model.RankingImagePath = viewModel.RankingImagePath;

            model.WinLoseImageStretch = viewModel.WinLoseImageStretch;
            model.RankingImageStretch = viewModel.RankingImageStretch;

            model.IsWinLoseStretchNone = viewModel.IsWinLoseStretchNone;
            model.IsWinLoseStretchFill = viewModel.IsWinLoseStretchFill;
            model.IsWinLoseStretchUniform = viewModel.IsWinLoseStretchUniform;
            model.IsWinLoseStretchNoneUniformToFill = viewModel.IsWinLoseStretchNoneUniformToFill;

            model.IsRankingStretchNone = viewModel.IsRankingStretchNone;
            model.IsRankingStretchFill = viewModel.IsRankingStretchFill;
            model.IsRankingStretchUniform = viewModel.IsRankingStretchUniform;
            model.IsRankingStretchNoneUniformToFill = viewModel.IsRankingStretchNoneUniformToFill;

            model.OpacityValue = viewModel.OpacityValue;

            #region :: Visible ::

            //private Visibility _winLoseSettingVisible = Visibility.Visible;                
            //private Visibility _rankingSettingVisible = Visibility.Collapsed;
            //private Visibility _textSettingVisible = Visibility.Collapsed;
            //private Visibility _boxSettingVisible = Visibility.Collapsed;
            //private Visibility _colorSettingVisible = Visibility.Collapsed;
            //private Visibility _soundSettingVisible = Visibility.Collapsed;
            //private Visibility _etcSettingVisible = Visibility.Collapsed;

            //private Visibility _winLoseListBoxVisible = Visibility.Visible;
            //private Visibility _rankingListBoxVisible = Visibility.Collapsed;

            //private bool _isRadioWinLoseUse = true;
            //private bool _isRadioRankingUse = false;

            #endregion

            #endregion

            return model;
        }
    }
}
