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
                model = SaveModel.WindowSaveSetting(vm);

                var serializeData = XmlSerialize.XmlSerialize.Serialize(model);
                var encryptData = EncryptDecrypt.Protect(serializeData);
                var path = $"{AppDomain.CurrentDomain.BaseDirectory}DrawBoardSave.txt";

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = path;
                File.WriteAllText(saveFileDialog.FileName, encryptData);
            }
        }
    }
}
