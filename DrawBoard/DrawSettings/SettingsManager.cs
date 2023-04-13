using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;

namespace DrawBoard.DrawSettings
{
    public class SettingsManager
    {
        public static void LoadSettings(FrameworkElement sender, Dictionary<FrameworkElement, DependencyProperty> savedElements)
        {
            EnsureProperties(sender, savedElements);
            foreach (FrameworkElement element in savedElements.Keys)
            {
                try
                {
                    element.SetValue(savedElements[element], DrawBoardSettings.Default[sender.Name + "." + element.Name]);
                }
                catch (Exception ex) { }
            }
        }

        public static void SaveSettings(FrameworkElement sender, Dictionary<FrameworkElement, DependencyProperty> savedElements)
        {
            EnsureProperties(sender, savedElements);
            foreach (FrameworkElement element in savedElements.Keys)
            {
                DrawBoardSettings.Default[sender.Name + "." + element.Name] = element.GetValue(savedElements[element]);
            }
            DrawBoardSettings.Default.Save();
        }

        public static void EnsureProperties(FrameworkElement sender, Dictionary<FrameworkElement, DependencyProperty> savedElements)
        {
            foreach (FrameworkElement element in savedElements.Keys)
            {
                bool hasProperty =
                    DrawBoardSettings.Default.Properties[sender.Name + "." + element.Name] != null;

                if (!hasProperty)
                {
                    SettingsAttributeDictionary attributes = new SettingsAttributeDictionary();
                    UserScopedSettingAttribute attribute = new UserScopedSettingAttribute();
                    attributes.Add(attribute.GetType(), attribute);

                    SettingsProperty property = new SettingsProperty(sender.Name + "." + element.Name,
                        savedElements[element].DefaultMetadata.DefaultValue.GetType(), DrawBoardSettings.Default.Providers["LocalFileSettingsProvider"], false, null, SettingsSerializeAs.String, attributes, true, true);
                    DrawBoardSettings.Default.Properties.Add(property);
                }
            }
            DrawBoardSettings.Default.Reload();
        }
    }
}
