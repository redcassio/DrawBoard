using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace DrawBoard.Behaviors
{
    public class WindowCloseBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Closed += AssociatedObject_Closed;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Closed -= AssociatedObject_Closed;
        }

        private void AssociatedObject_Closed(object? sender, System.EventArgs e)
        {
            if (AssociatedObject.DataContext is MainWindowViewModel vm)
            {
                DrawBoardSettings.Default.AllNumber = vm.WinFailureAllCount;
                DrawBoardSettings.Default.WinNumber = vm.WinCount;
                DrawBoardSettings.Default.WinText = vm.WinText;
                DrawBoardSettings.Default.FailureText = vm.FailureText;
                DrawBoardSettings.Default.BoxWidth = vm.BoxWidth;
                DrawBoardSettings.Default.BoxHeight = vm.BoxHeight;
                DrawBoardSettings.Default.WindowWidth = vm.WindowWidth;
                DrawBoardSettings.Default.WindowHeight = vm.WindowHeight;
                DrawBoardSettings.Default.SelectedFont = vm.SelectedWinFailureFont;
                DrawBoardSettings.Default.NumberTextSize = vm.NumberTextSize;
                DrawBoardSettings.Default.WinFailureTextSize = vm.WinFailureTextSize;
                DrawBoardSettings.Default.WinVolume = vm.WinVolume;
                DrawBoardSettings.Default.FailureVolume = vm.FailureVolume;
                DrawBoardSettings.Default.BackgroundColor = vm.BackgroundColor.ToString();
                DrawBoardSettings.Default.FailureColor = vm.FailureColor.ToString();
                DrawBoardSettings.Default.WinColor = vm.WinColor.ToString();
                DrawBoardSettings.Default.FontColor = vm.FontColor.ToString();
                DrawBoardSettings.Default.PanelColor = vm.PanelColor.ToString();
                DrawBoardSettings.Default.WinSoundPath = vm.WinSoundPath;
                DrawBoardSettings.Default.FailureSoundPath = vm.FailureSoundPath;

                DrawBoardSettings.Default.Save();
            }
        }
    }
}
