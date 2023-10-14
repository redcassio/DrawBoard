using System.Windows;

namespace DrawBoard
{
    /// <summary>
    /// DownloadWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DownloadWindow : Window
    {
        public static readonly DependencyProperty ProgressValueStringProperty =
            DependencyProperty.Register(nameof(ProgressValueString), typeof(string), typeof(DownloadWindow), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ProgressValueProperty =
            DependencyProperty.Register(nameof(ProgressValue), typeof(double), typeof(DownloadWindow), new PropertyMetadata(0d));

        public string ProgressValueString
        {
            get { return (string)GetValue(ProgressValueStringProperty); }
            set { SetValue(ProgressValueStringProperty, value); }
        }

        public double ProgressValue
        {
            get { return (double)GetValue(ProgressValueProperty); }
            set { SetValue(ProgressValueProperty, value); }
        }

        public DownloadWindow()
        {
            InitializeComponent();
        }
    }
}
