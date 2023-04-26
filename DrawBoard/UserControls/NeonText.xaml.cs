using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DrawBoard.UserControls
{
    /// <summary>
    /// NeonText.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NeonText : UserControl
    {
        private static Color _defaultColor = (Color)ColorConverter.ConvertFromString("#47bdfc");

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(NeonText), new PropertyMetadata("Mouse Events"));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty GlowColorProperty =
           DependencyProperty.Register(nameof(GlowColor), typeof(Color), typeof(NeonText), new PropertyMetadata(_defaultColor));
        public Color GlowColor
        {
            get { return (Color)GetValue(GlowColorProperty); }
            set { SetValue(GlowColorProperty, value); }
        }

        public static readonly DependencyProperty ActivateBlinkProperty =
            DependencyProperty.Register(nameof(ActivateBlink), typeof(bool), typeof(NeonText), new PropertyMetadata(false));
        public bool ActivateBlink
        {
            get { return (bool)GetValue(ActivateBlinkProperty); }
            set { SetValue(ActivateBlinkProperty, value); }
        }

        public NeonText()
        {
            InitializeComponent();
        }
    }
}
