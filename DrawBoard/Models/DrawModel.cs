using CommunityToolkit.Mvvm.ComponentModel;

namespace DrawBoard
{
    public partial class DrawModel : ObservableObject
    {
        [ObservableProperty]
        private int _unitNumber;

        [ObservableProperty]
        private bool _isWin = false;

        [ObservableProperty]
        private bool _isOpen = false;

        [ObservableProperty]
        private string? _rankingText;
    }
}