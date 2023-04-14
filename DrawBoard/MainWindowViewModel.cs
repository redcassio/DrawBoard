using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace DrawBoard
{
    public partial class MainWindowViewModel : ObservableObject
    {
        #region :: Members ::

        [ObservableProperty]
        //[property: RegularExpression(@"[^0-9]+")]
        private int _winFailureAllCount = 50;
        [ObservableProperty]
        private int _rankingAllCount = 30;

        [ObservableProperty]
        private int _winCount = 3;

        [ObservableProperty]
        private int _firstCount = 1;
        [ObservableProperty]
        private int _secondCount = 2;
        [ObservableProperty]
        private int _thirdCount = 2;
        [ObservableProperty]
        private int _fourthCount = 2;
        [ObservableProperty]
        private int _fifthCount = 2;
        [ObservableProperty]
        private int _sixthCount = 2;
        [ObservableProperty]
        private int _seventhCount = 7;
                
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
        private string _winText = "당첨";
        [ObservableProperty]
        private string _failureText = "꽝";

        [ObservableProperty]
        private string _rankingFailureText = "꽝";

        [ObservableProperty]
        private double _numberTextSize = 40d;

        [ObservableProperty]
        private double _winFailureTextSize = 30d;

        [ObservableProperty]
        private double _boxWidth = 100d;

        [ObservableProperty]
        private double _boxHeight = 60d;

        [ObservableProperty]
        private Color? _backgroundColor;

        [ObservableProperty]
        private Color? _failureColor;

        [ObservableProperty]
        private Color? _winColor;

        [ObservableProperty]
        private Color? _fontColor;

        [ObservableProperty]
        private Color? _panelColor;

        [ObservableProperty]
        private ObservableCollection<string> _fontList = new();

        [ObservableProperty]
        private string? _selectedWinFailureFont;
        [ObservableProperty]
        private string? _selectedRankingFont = "Expo M";

        [ObservableProperty]
        private double _windowWidth = 730d;

        [ObservableProperty]
        private double _windowHeight = 700d;

        [ObservableProperty]
        private double _winVolume = 0.5d;

        [ObservableProperty]
        private double _failureVolume = 0.5d;

        [ObservableProperty]
        private string? _winSoundPath;

        [ObservableProperty]
        private string? _failureSoundPath;

        [ObservableProperty]
        private Uri? _winMediaElementSource;

        [ObservableProperty]
        private Uri? _FailureMediaElementSource;

        [ObservableProperty]
        private bool _isWinMediaElementPlay;

        [ObservableProperty]
        private bool _isFailureMediaElementPlay;

        [ObservableProperty]
        private ObservableCollection<DrawModel> _drawWinFailureList = new();

        [ObservableProperty]
        private ObservableCollection<DrawModel> _drawRankingList = new();

        [ObservableProperty]
        private Visibility _numberSetting = Visibility.Visible;
        [ObservableProperty]
        private Visibility _textSetting = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _boxSetting = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _colorSetting = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _soundSetting = Visibility.Collapsed;
        [ObservableProperty]
        private Visibility _etcSetting = Visibility.Collapsed;

        [ObservableProperty]
        private bool _isFocusOnOf;

        #endregion

        #region :: Ctor ::

        public MainWindowViewModel()
        {
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontList.Add(fontFamily.Source);
            }

            SetDefaultValue();

            //MakeDrawWinFailureList(AllNumber);
        }

        private void SetDefaultValue()
        { 
            WinFailureAllCount = DrawBoardSettings.Default.AllNumber;
            WinCount = DrawBoardSettings.Default.WinNumber;
            WinText = DrawBoardSettings.Default.WinText;
            FailureText = DrawBoardSettings.Default.FailureText;
            NumberTextSize = DrawBoardSettings.Default.NumberTextSize;
            WinFailureTextSize = DrawBoardSettings.Default.WinFailureTextSize;
            BoxWidth = DrawBoardSettings.Default.BoxWidth;
            BoxHeight = DrawBoardSettings.Default.BoxHeight;
            WindowWidth = DrawBoardSettings.Default.WindowWidth;
            WindowHeight = DrawBoardSettings.Default.WindowHeight;
            SelectedWinFailureFont = DrawBoardSettings.Default.SelectedFont;
            WinSoundPath = DrawBoardSettings.Default.WinSoundPath;
            FailureSoundPath = DrawBoardSettings.Default.FailureSoundPath;
            WinVolume = DrawBoardSettings.Default.WinVolume;
            FailureVolume = DrawBoardSettings.Default.FailureVolume;
            BackgroundColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.BackgroundColor);
            FailureColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.FailureColor);
            WinColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.WinColor);
            FontColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.FontColor);
            PanelColor = (Color)ColorConverter.ConvertFromString(DrawBoardSettings.Default.PanelColor);
        }

        #endregion

        #region :: Commands ::

        [RelayCommand]
        private void MakeWinFailure()
        {
            IsFocusOnOf = !IsFocusOnOf;
            MakeDrawWinFailureList(WinFailureAllCount);
        }

        [RelayCommand]
        private void MakeRanking()
        {
            IsFocusOnOf = !IsFocusOnOf;
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
                    FailureMediaElementSource = null;
                    WinMediaElementSource = new Uri(WinSoundPath);
                    IsWinMediaElementPlay = !IsWinMediaElementPlay;
                }
            }
            else 
            {
                if (!string.IsNullOrEmpty(FailureSoundPath) && FailureSoundPath != "없음")
                {
                    WinMediaElementSource = null;
                    FailureMediaElementSource = new Uri(FailureSoundPath);
                    IsFailureMediaElementPlay = !IsFailureMediaElementPlay;
                }
            }
        }

        [RelayCommand]
        private void SettingChange(SettingButtons settings)
        {
            NumberSetting = Visibility.Collapsed;
            TextSetting = Visibility.Collapsed;
            BoxSetting = Visibility.Collapsed;
            ColorSetting = Visibility.Collapsed;
            SoundSetting = Visibility.Collapsed;
            EtcSetting = Visibility.Collapsed;

            switch (settings)
            {
                case SettingButtons.Number:
                    NumberSetting = Visibility.Visible;
                    break;
                case SettingButtons.Text:
                    TextSetting = Visibility.Visible;
                    break;
                case SettingButtons.Box:
                    BoxSetting = Visibility.Visible;
                    break;
                case SettingButtons.Color:
                    ColorSetting = Visibility.Visible;
                    break;
                case SettingButtons.Sound:
                    SoundSetting = Visibility.Visible;
                    break;
                case SettingButtons.Etc:
                    EtcSetting = Visibility.Visible;
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
        private void FailureSound()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FailureSoundPath = openFileDialog.FileName;
            }
        }

        [RelayCommand]
        private void WinSoundClear()
        {
            WinSoundPath = "없음";
            WinMediaElementSource = null;
        }

        [RelayCommand]
        private void FailureSoundClear()
        {
            FailureSoundPath = "없음";
            FailureMediaElementSource = null;
        }

        #endregion

        #region :: Methods ::

        private void MakeDrawWinFailureList(int allNumber)
        {
            FailureMediaElementSource = null;
            WinMediaElementSource = null;

            if (WinFailureAllCount <= 1)
            {
                MessageBox.Show("1보다 큰 수를 입력해 주세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                WinFailureAllCount = 2;
            }
            else if (WinCount <= 0)
            {
                MessageBox.Show("0보다 큰 수를 입력해 주세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                WinCount = 1;
            }
            else if (WinFailureAllCount < WinCount)
            {
                MessageBox.Show("당첨 개수가 전체 개수보다 큽니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Information);
                WinFailureAllCount = WinCount;
            }
            else
            {
                DrawWinFailureList.Clear();
                var array = GeneratorRandomNumber(1, WinFailureAllCount, WinCount);

                foreach (var number in Enumerable.Range(1, allNumber))
                {
                    DrawWinFailureList.Add(new() { UnitNumber = number, IsWin = array.Contains(number) ? true : false });
                }
            }
        }

        private void MakeRankingList(int allNumber)
        {
            FailureMediaElementSource = null;
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
                        DrawRankingList.Add(new() { UnitNumber = number, IsWin = false, RankingText = RankingFailureText });
                    }
                }
            }
        }

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

        private int[] GeneratorRandomNumber(int min, int max, int count, int[] refItem)
        {
            //var allCount = count + refItem.Length;
            var intArray = new int[count];
            var rand = new Random();

            //for (int i = 0; i < refItem.Length; i++)
            //{
            //    intArray[i] = refItem[i];
            //}

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

    }
}
