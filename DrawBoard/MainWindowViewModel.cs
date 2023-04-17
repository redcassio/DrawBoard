using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DrawBoard
{
    public partial class MainWindowViewModel : ObservableObject
    {
        #region :: Members ::

        #region :: Window ::

        [ObservableProperty]
        private double _windowWidth = 730d;

        [ObservableProperty]
        private double _windowHeight = 700d;

        #endregion

        #region :: Game Count ::

        [ObservableProperty]
        private int _winLoseAllCount = 50;
        [ObservableProperty]
        private int _winCount = 3;

        [ObservableProperty]
        private int _rankingAllCount = 30;
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
        private Color? _winLoseBackgroundColor;
        [ObservableProperty]
        private Color? _rankingBackgroundColor;

        [ObservableProperty]
        private Color? _winLoseWinBackgroundColor;
        [ObservableProperty]
        private Color? _rankingWinBackgroundColor;

        [ObservableProperty]
        private Color? _winLoseLoseBackgroundColor;
        [ObservableProperty]
        private Color? _rankingLoseBackgroundColor;

        [ObservableProperty]
        private Color? _winLoseNumberColor;
        [ObservableProperty]
        private Color? _rankingNumberColor;

        [ObservableProperty]
        private Color? _winLoseWinColor;
        [ObservableProperty]
        private Color? _rankingWinColor;

        [ObservableProperty]
        private Color? _winLoseLoseColor;
        [ObservableProperty]
        private Color? _rankingLoseColor;

        [ObservableProperty]
        private Color? _winLosePanelColor;
        [ObservableProperty]
        private Color? _rankingPanelColor;

        #endregion

        #region :: Font ::

        [ObservableProperty]
        private ObservableCollection<string> _fontList = new();

        [ObservableProperty]
        private string? _selectedWinLoseFont;
        [ObservableProperty]
        private string? _selectedRankingFont;

        #endregion

        #region :: Sound ::

        [ObservableProperty]
        private double _winVolume = 0.5d;

        [ObservableProperty]
        private double _loseVolume = 0.5d;

        [ObservableProperty]
        private string? _winSoundPath;

        [ObservableProperty]
        private string? _loseSoundPath;

        #endregion

        #region :: MediaElement ::

        [ObservableProperty]
        private Uri? _winMediaElementSource;
        [ObservableProperty]
        private Uri? _loseMediaElementSource;
        [ObservableProperty]
        private bool _isWinMediaElementPlay;
        [ObservableProperty]
        private bool _isLoseMediaElementPlay;

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

        [ObservableProperty]
        private Brush _winLoseListBoxBackground;
        [ObservableProperty]
        private string? _winLoseImagePath;

        [ObservableProperty]
        private Brush _rankingListBoxBackground;
        [ObservableProperty]
        private string? _rankingImagePath;

        #endregion

        #region :: Visible ::

        [ObservableProperty]
        private Visibility _winLoseSettingVisible = Visibility.Visible;
        [ObservableProperty]
        private Visibility _rankingSettingVisible = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _textSettingVisible = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _boxSettingVisible = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _colorSettingVisible = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _soundSettingVisible = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _etcSettingVisible = Visibility.Collapsed;

        [ObservableProperty]
        private Visibility _winLoseListBoxVisible = Visibility.Visible;
        [ObservableProperty]
        private Visibility _rankingListBoxVisible = Visibility.Collapsed;

        [ObservableProperty]
        private bool _isRadioWinLoseUse = true;
        [ObservableProperty]
        private bool _isRadioRankingUse = false;

        #endregion

        [ObservableProperty]
        private bool _isFocusOnOff;

        #endregion

        #region :: Ctor ::

        public MainWindowViewModel()
        {
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontList.Add(fontFamily.Source);
            }

            SetDefaultValue();
            WinLoseUseImage();
            RankingUseImage();
        }

        private void SetDefaultValue()
        { 
            WinLoseAllCount = DrawBoardSettings.Default.AllNumber;
            WinCount = DrawBoardSettings.Default.WinNumber;
            WinText = DrawBoardSettings.Default.WinText;
            //LoseText = DrawBoardSettings.Default.LoseText;
            //NumberTextSize = DrawBoardSettings.Default.NumberTextSize;
            //WinLoseTextSize = DrawBoardSettings.Default.WinLoseTextSize;
            //BoxWidth = DrawBoardSettings.Default.BoxWidth;
            //BoxHeight = DrawBoardSettings.Default.BoxHeight;
            WindowWidth = DrawBoardSettings.Default.WindowWidth;
            WindowHeight = DrawBoardSettings.Default.WindowHeight;
            SelectedWinLoseFont = DrawBoardSettings.Default.SelectedFont;
            WinSoundPath = DrawBoardSettings.Default.WinSoundPath;
            //LoseSoundPath = DrawBoardSettings.Default.LoseSoundPath;
            WinVolume = DrawBoardSettings.Default.WinVolume;
            //LoseVolume = DrawBoardSettings.Default.LoseVolume;
            //BackgroundColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.BackgroundColor);
            //LoseColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.LoseColor);
            //WinColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.WinColor);
            //NumberColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.NumberColor);
            WinLosePanelColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.PanelColor);

            if (string.IsNullOrEmpty(LoseSoundPath))
            {
                LoseSoundPath = $"{AppDomain.CurrentDomain.BaseDirectory}SoundEffect\\Lose.mp3";
            }
        }

        #endregion

        #region :: Commands ::

        [RelayCommand]
        private void MakeWinLose()
        {
            IsFocusOnOff = !IsFocusOnOff;
            MakeDrawWinLoseList(WinLoseAllCount);
        }

        [RelayCommand]
        private void MakeRanking()
        {
            IsFocusOnOff = !IsFocusOnOff;
            MakeRankingList(RankingAllCount);
        }

        [RelayCommand]
        private void DrawOpen(DrawModel model)
        {
            model.IsOpen = true;

            if (model.IsWin)
            {
                if (!string.IsNullOrEmpty(WinSoundPath) && WinSoundPath != "없음")
                {
                    LoseMediaElementSource = null;
                    WinMediaElementSource = new Uri(WinSoundPath);
                    IsWinMediaElementPlay = !IsWinMediaElementPlay;
                }
            }
            else 
            {
                if (!string.IsNullOrEmpty(LoseSoundPath) && LoseSoundPath != "없음")
                {
                    WinMediaElementSource = null;
                    LoseMediaElementSource = new Uri(LoseSoundPath);
                    IsLoseMediaElementPlay = !IsLoseMediaElementPlay;
                }
            }
        }

        [RelayCommand]
        private void SettingChange(SettingButtons settings)
        {
            WinLoseSettingVisible = Visibility.Collapsed;
            RankingSettingVisible = Visibility.Collapsed;
            TextSettingVisible = Visibility.Collapsed;
            BoxSettingVisible = Visibility.Collapsed;
            ColorSettingVisible = Visibility.Collapsed;
            SoundSettingVisible = Visibility.Collapsed;
            EtcSettingVisible = Visibility.Collapsed;
            
            switch (settings)
            {
                case SettingButtons.WinLose:
                    WinLoseSettingVisible = Visibility.Visible;
                    RankingListBoxVisible = Visibility.Collapsed;
                    WinLoseListBoxVisible = Visibility.Visible;
                    IsRadioWinLoseUse = true;
                    break;
                case SettingButtons.Ranking:
                    RankingSettingVisible = Visibility.Visible;
                    WinLoseListBoxVisible = Visibility.Collapsed;
                    RankingListBoxVisible = Visibility.Visible;
                    IsRadioRankingUse = true;
                    break;
                case SettingButtons.Text:
                    TextSettingVisible = Visibility.Visible;
                    break;
                case SettingButtons.Box:
                    BoxSettingVisible = Visibility.Visible;
                    break;
                case SettingButtons.Color:
                    ColorSettingVisible = Visibility.Visible;
                    break;
                case SettingButtons.Sound:
                    SoundSettingVisible = Visibility.Visible;
                    break;
                case SettingButtons.Etc:
                    EtcSettingVisible = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        [RelayCommand]
        private void WinSound()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                WinSoundPath = openFileDialog.FileName;
            }
        }

        [RelayCommand]
        private void LoseSound()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                LoseSoundPath = openFileDialog.FileName;
            }
        }

        [RelayCommand]
        private void WinSoundClear()
        {
            WinSoundPath = "없음";
            WinMediaElementSource = null;
        }

        [RelayCommand]
        private void LoseSoundClear()
        {
            LoseSoundPath = "없음";
            LoseMediaElementSource = null;
        }

        [RelayCommand]
        private void WinLoseImageSelect()
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));

                    WinLoseListBoxBackground = imageBrush;
                    WinLoseImagePath = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        private void WinLoseImageRecycle()
        {
            try
            {
                var imageBrush = new ImageBrush();
                var path = $"{AppDomain.CurrentDomain.BaseDirectory}Images\\background2.png";
                if (File.Exists(path))
                {
                    imageBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));

                    WinLoseListBoxBackground = imageBrush;
                    WinLoseImagePath = path;
                }
                else
                {
                    MessageBox.Show($"이미지 파일이 없습니다.{Environment.NewLine}{path}", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        private void WinSoundRecycle()
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}SoundEffect\\win.mp3";
            if (File.Exists(path))
            {
                WinSoundPath = path;
            }
            else
            {
                MessageBox.Show($"사운드 파일이 없습니다.{Environment.NewLine}{path}", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        private void LoseSoundRecycle()
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}SoundEffect\\Lose.mp3";
            if (File.Exists(path))
            {
                LoseSoundPath = path;
            }
            else
            {
                MessageBox.Show($"사운드 파일이 없습니다.{Environment.NewLine}{path}", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        private void WinLoseUseImage()
        {
            try
            {
                if (string.IsNullOrEmpty(WinLoseImagePath))
                {
                    var imageBrush = new ImageBrush();
                    var path = $"{AppDomain.CurrentDomain.BaseDirectory}Images\\background1.png";
                    if (File.Exists(path))
                    {
                        imageBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));

                        WinLoseListBoxBackground = imageBrush;
                        WinLoseImagePath = path;
                    }
                    else
                    {
                        MessageBox.Show($"이미지 파일이 없습니다.{Environment.NewLine}{path}", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    var imageBrush = new ImageBrush();
                    if (File.Exists(WinLoseImagePath))
                    {
                        imageBrush.ImageSource = new BitmapImage(new Uri(WinLoseImagePath, UriKind.Absolute));

                        WinLoseListBoxBackground = imageBrush;
                    }
                    else
                    {
                        MessageBox.Show($"이미지 파일이 없습니다.{Environment.NewLine}{WinLoseImagePath}", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        private void WinLoseUseColor()
        {
            Brush brush = Brushes.Transparent;
            if (WinLosePanelColor is Color color)
            {
                brush = new SolidColorBrush(color);
            }
            WinLoseListBoxBackground = brush;
        }

        [RelayCommand]
        private void RankingUseImage()
        {
            try
            {
                if (string.IsNullOrEmpty(RankingImagePath))
                {
                    var imageBrush = new ImageBrush();
                    var path = $"{AppDomain.CurrentDomain.BaseDirectory}Images\\background2.png";
                    if (File.Exists(path))
                    {
                        imageBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));

                        RankingListBoxBackground = imageBrush;
                        RankingImagePath = path;
                    }
                    else
                    {
                        MessageBox.Show($"이미지 파일이 없습니다.{Environment.NewLine}{path}", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    var imageBrush = new ImageBrush();
                    if (File.Exists(RankingImagePath))
                    {
                        imageBrush.ImageSource = new BitmapImage(new Uri(RankingImagePath, UriKind.Absolute));

                        RankingListBoxBackground = imageBrush;
                    }
                    else
                    {
                        MessageBox.Show($"이미지 파일이 없습니다.{Environment.NewLine}{RankingImagePath}", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        [RelayCommand]
        private void RankingUseColor()
        {
            Brush brush = Brushes.Transparent;
            if (RankingPanelColor is Color color)
            {
                brush = new SolidColorBrush(color);
            }
            RankingListBoxBackground = brush;
        }

        [RelayCommand]
        private void RadioWinLoseUse()
        {
            WinLoseListBoxVisible = Visibility.Visible;
            RankingListBoxVisible = Visibility.Collapsed;
        }

        [RelayCommand]
        private void RadioRankingUse()
        {
            WinLoseListBoxVisible = Visibility.Collapsed;
            RankingListBoxVisible = Visibility.Visible;
        }

        #endregion

        #region :: Methods ::

        private int[] GeneratorRandomNumber(int min, int max, int count)
        {
            var intArray = new int[count];
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                // 랜덤 값 생성
                int randNumber = rand.Next(min, max + 1);

                // 랜덤 값이 배열에 존재하면 loop를 1 감소
                if (intArray.Contains(randNumber))
                {
                    i--;
                }
                // 랜덤 값이 배열에 없으면 배열에 추가
                else
                {
                    intArray[i] = randNumber;
                }
            }
            return intArray;
        }

        private void MakeDrawWinLoseList(int allNumber)
        {
            LoseMediaElementSource = null;
            WinMediaElementSource = null;

            if (WinLoseAllCount <= 1)
            {
                MessageBox.Show("1보다 큰 수를 입력해 주세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                WinLoseAllCount = 2;
            }
            else if (WinCount <= 0)
            {
                MessageBox.Show("0보다 큰 수를 입력해 주세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                WinCount = 1;
            }
            else if (WinLoseAllCount < WinCount)
            {
                MessageBox.Show("당첨 개수가 전체 개수보다 큽니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                WinLoseAllCount = WinCount;
            }
            else
            {
                DrawWinLoseList.Clear();
                var array = GeneratorRandomNumber(1, WinLoseAllCount, WinCount);

                foreach (var number in Enumerable.Range(1, allNumber))
                {
                    DrawWinLoseList.Add(new() { UnitNumber = number, IsWin = array.Contains(number) ? true : false });
                }
            }
        }

        #region :: Ranking ::

        private void MakeRankingList(int allNumber)
        {
            LoseMediaElementSource = null;
            WinMediaElementSource = null;

            if (RankingAllCount <= 1)
            {
                MessageBox.Show("1보다 큰 수를 입력해 주세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                RankingAllCount = 2;
            }
            else if (RankingAllCount < (FirstCount + SecondCount + ThirdCount + FourthCount + FifthCount + SixthCount + SeventhCount))
            {
                MessageBox.Show("당첨 개수가 전체 개수보다 큽니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                RankingAllCount = (FirstCount + SecondCount + ThirdCount + FourthCount + FifthCount + SixthCount + SeventhCount);
            }
            else
            {
                DrawRankingList.Clear();
                var item1 = GeneratorRandomNumber(1, RankingAllCount, FirstCount);
                var item2 = GeneratorRandomNumber(1, RankingAllCount, SecondCount, item1);
                var item3 = GeneratorRandomNumber(1, RankingAllCount, ThirdCount, GeneratorSum(item1, item2));
                var item4 = GeneratorRandomNumber(1, RankingAllCount, FourthCount, GeneratorSum(item1, item2, item3));
                var item5 = GeneratorRandomNumber(1, RankingAllCount, FifthCount, GeneratorSum(item1, item2, item3, item4));
                var item6 = GeneratorRandomNumber(1, RankingAllCount, SixthCount, GeneratorSum(item1, item2, item3, item4, item5));
                var item7 = GeneratorRandomNumber(1, RankingAllCount, SeventhCount, GeneratorSum(item1, item2, item3, item4, item5, item6));

                foreach (var number in Enumerable.Range(1, allNumber))
                {
                    if (item1.Contains(number))
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = true, RankingText = FirstText });
                    }
                    else if (item2.Contains(number))
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = true, RankingText = SecondText });
                    }
                    else if (item3.Contains(number))
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = true, RankingText = ThirdText});
                    }
                    else if (item4.Contains(number))
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = true, RankingText = FourthText });
                    }
                    else if (item5.Contains(number))
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = true, RankingText = FifthText });
                    }
                    else if (item6.Contains(number))
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = true, RankingText = SixthText });
                    }
                    else if (item7.Contains(number))
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = true, RankingText = SeventhText });
                    }
                    else
                    {
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = false, RankingText = RankingLoseText });
                    }
                }
            }
        }

        private int[] GeneratorRandomNumber(int min, int max, int count, int[] refItem)
        {
            var intArray = new int[count];
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                // 랜덤 값 생성
                int randNumber = rand.Next(min, max + 1);

                // 랜덤 값이 배열에 존재하면 loop를 1 감소
                if (intArray.Contains(randNumber) || refItem.Contains(randNumber))
                {
                    i--;
                }
                // 랜덤 값이 배열에 없으면 배열에 추가
                else
                {
                    intArray[i] = randNumber;
                }
            }
            return intArray;
        }

        private int[] GeneratorSum(int[] item1, int[] item2)
        {
            int[] ints = new int[item1.Length + item2.Length];
            int count = 0;

            for (int i = 0; i < item1.Length; i++)
            {
                ints[i] = item1[i];
                count++;
            }
            for (int i = 0; i < item2.Length; i++)
            {
                ints[count] = item2[i];
                count++;
            }
            
            return ints;
        }

        private int[] GeneratorSum(int[] item1, int[] item2, int[] item3)
        {
            int[] ints = new int[item1.Length + item2.Length + item3.Length];
            int count = 0;

            for (int i = 0; i < item1.Length; i++)
            {
                ints[i] = item1[i];
                count++;
            }
            for (int i = 0; i < item2.Length; i++)
            {
                ints[count] = item2[i];
                count++;
            }
            for (int i = 0; i < item3.Length; i++)
            {
                ints[count] = item3[i];
                count++;
            }

            return ints;
        }

        private int[] GeneratorSum(int[] item1, int[] item2, int[] item3, int[] item4)
        {
            int[] ints = new int[item1.Length + item2.Length + item3.Length + item4.Length];
            int count = 0;

            for (int i = 0; i < item1.Length; i++)
            {
                ints[i] = item1[i];
                count++;
            }
            for (int i = 0; i < item2.Length; i++)
            {
                ints[count] = item2[i];
                count++;
            }
            for (int i = 0; i < item3.Length; i++)
            {
                ints[count] = item3[i];
                count++;
            }
            for (int i = 0; i < item4.Length; i++)
            {
                ints[count] = item4[i];
                count++;
            }

            return ints;
        }

        private int[] GeneratorSum(int[] item1, int[] item2, int[] item3, int[] item4, int[] item5)
        {
            int[] ints = new int[item1.Length + item2.Length + item3.Length + item4.Length + item5.Length];
            int count = 0;

            for (int i = 0; i < item1.Length; i++)
            {
                ints[i] = item1[i];
                count++;
            }
            for (int i = 0; i < item2.Length; i++)
            {
                ints[count] = item2[i];
                count++;
            }
            for (int i = 0; i < item3.Length; i++)
            {
                ints[count] = item3[i];
                count++;
            }
            for (int i = 0; i < item4.Length; i++)
            {
                ints[count] = item4[i];
                count++;
            }
            for (int i = 0; i < item5.Length; i++)
            {
                ints[count] = item5[i];
                count++;
            }

            return ints;
        }

        private int[] GeneratorSum(int[] item1, int[] item2, int[] item3, int[] item4, int[] item5, int[] item6)
        {
            int[] ints = new int[item1.Length + item2.Length + item3.Length + item4.Length + item5.Length + item6.Length];
            int count = 0;

            for (int i = 0; i < item1.Length; i++)
            {
                ints[i] = item1[i];
                count++;
            }
            for (int i = 0; i < item2.Length; i++)
            {
                ints[count] = item2[i];
                count++;
            }
            for (int i = 0; i < item3.Length; i++)
            {
                ints[count] = item3[i];
                count++;
            }
            for (int i = 0; i < item4.Length; i++)
            {
                ints[count] = item4[i];
                count++;
            }
            for (int i = 0; i < item5.Length; i++)
            {
                ints[count] = item5[i];
                count++;
            }
            for (int i = 0; i < item6.Length; i++)
            {
                ints[count] = item6[i];
                count++;
            }

            return ints;
        }

        #endregion

        partial void OnWinLosePanelColorChanged(Color? value)
        {
            WinLoseUseColor();
        }

        partial void OnRankingPanelColorChanged(Color? value)
        {
            RankingUseColor();
        }

        #endregion

    }
}
