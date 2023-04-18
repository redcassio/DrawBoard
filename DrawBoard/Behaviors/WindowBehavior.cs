using DrawBoard.EncryptionDecryption;
using DrawBoard.Models;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors;
using System;
using System.IO;
using System.Windows;

namespace DrawBoard.Behaviors
{
    public class WindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseDown += AssociatedObject_MouseDown;
            AssociatedObject.Closed += AssociatedObject_Closed;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseDown -= AssociatedObject_MouseDown;
            AssociatedObject.Closed -= AssociatedObject_Closed;
        }

        private void AssociatedObject_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                AssociatedObject.DragMove();
            }
        }

        private void AssociatedObject_Closed(object? sender, System.EventArgs e)
        {
            if (AssociatedObject.DataContext is MainWindowViewModel vm)
            {
                var model = new SaveModel();

                #region :: Model ::

                model.WindowWidth = vm.WindowWidth;
                model.WindowHeight = vm.WindowHeight;
                model.WinLoseGameCount = vm.WinLoseGameCount;
                model.WinCount = vm.WinCount;
                model.RankingGameCount = vm.RankingGameCount;
                model.FirstCount = vm.FirstCount;
                model.SecondCount = vm.SecondCount;
                
                model.ThirdCount = vm.ThirdCount;
                model.FourthCount = vm.FourthCount;
                model.FifthCount = vm.FifthCount;
                model.SixthCount = vm.SixthCount;
                model.SeventhCount = vm.SeventhCount;

                model.WinText = vm.WinText;
                model.LoseText = vm.LoseText;
                model.RankingLoseText = vm.RankingLoseText;
                model.FirstText = vm.FirstText;
                model.SecondText = vm.SecondText;
                model.ThirdText = vm.ThirdText;
                model.FourthText = vm.FourthText;
                model.FifthText = vm.FifthText;
                model.SixthText = vm.SixthText;
                model.SeventhText = vm.SeventhText;
                model.WinLoseTextSize = vm.WinLoseTextSize;
                model.WinLoseNumberTextSize = vm.WinLoseNumberTextSize;
                model.RankingTextSize = vm.RankingTextSize;
                model.RankingNumberTextSize = vm.RankingNumberTextSize;

                model.WinLoseBackgroundColor = vm.WinLoseBackgroundColor;
                model.RankingBackgroundColor = vm.RankingBackgroundColor;
                model.WinLoseWinBackgroundColor = vm.WinLoseWinBackgroundColor;
                model.RankingWinBackgroundColor = vm.RankingWinBackgroundColor;
                model.WinLoseLoseBackgroundColor = vm.WinLoseLoseBackgroundColor;
                model.RankingLoseBackgroundColor = vm.RankingLoseBackgroundColor;
                model.WinLoseNumberColor = vm.WinLoseNumberColor;
                model.RankingNumberColor = vm.RankingNumberColor;
                model.WinLoseWinColor = vm.WinLoseWinColor;
                model.RankingWinColor = vm.RankingWinColor;
                model.WinLoseLoseColor = vm.WinLoseLoseColor;
                model.RankingLoseColor = vm.RankingLoseColor;
                model.WinLosePanelColor = vm.WinLosePanelColor;
                model.RankingPanelColor = vm.RankingPanelColor;

                model.SelectedWinLoseFont = vm.SelectedWinLoseFont;
                model.SelectedRankingFont = vm.SelectedRankingFont;

                model.WinVolume = vm.WinVolume;
                model.LoseVolume = vm.LoseVolume;
                model.WinSoundPath = vm.WinSoundPath;
                model.LoseSoundPath = vm.LoseSoundPath;

                model.DrawWinLoseList = vm.DrawWinLoseList;
                model.DrawRankingList = vm.DrawRankingList;

                model.WinLoseBoxWidth = vm.WinLoseBoxWidth;
                model.WinLoseBoxHeight = vm.WinLoseBoxHeight;
                model.RankingBoxWidth = vm.RankingBoxWidth;
                model.RankingBoxHeight = vm.RankingBoxHeight;

                //model.WinLoseListBoxBackground = vm.WinLoseListBoxBackground;
                model.WinLoseImagePath = vm.WinLoseImagePath;

                //model.RankingListBoxBackground = vm.RankingListBoxBackground;
                model.RankingImagePath = vm.RankingImagePath;

                model.WinLoseImageStretch = vm.WinLoseImageStretch;
                model.RankingImageStretch = vm.RankingImageStretch;

                model.IsWinLoseStretchNone = vm.IsWinLoseStretchNone;
                model.IsWinLoseStretchFill = vm.IsWinLoseStretchFill;
                model.IsWinLoseStretchUniform = vm.IsWinLoseStretchUniform;
                model.IsWinLoseStretchNoneUniformToFill = vm.IsWinLoseStretchNoneUniformToFill;

                model.IsRankingStretchNone = vm.IsRankingStretchNone;
                model.IsRankingStretchFill = vm.IsRankingStretchFill;
                model.IsRankingStretchUniform = vm.IsRankingStretchUniform;
                model.IsRankingStretchNoneUniformToFill = vm.IsRankingStretchNoneUniformToFill;

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

                var serializeData = XmlSerialize.XmlSerialize.Serialize(model);
                var encryptData = EncryptDecrypt.Protect(serializeData);
                var path = $"{AppDomain.CurrentDomain.BaseDirectory}DrawBoardSave.txt";

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = path;
                File.WriteAllText(saveFileDialog.FileName, encryptData);
            
            //XmlSerialize.XmlSerialize.Save(encryptData, path);
        }
        }
    }
}
