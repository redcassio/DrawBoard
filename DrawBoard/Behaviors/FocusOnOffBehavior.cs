using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DrawBoard.Behaviors
{
    public class FocusOnOffBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty IsFocusProperty =
            DependencyProperty.Register("IsFocus", typeof(bool), typeof(FocusOnOffBehavior), new PropertyMetadata(false, propertyChangedCallback: IsFocusPropertyChanged));

        public bool IsFocus
        {
            get { return (bool)GetValue(IsFocusProperty); }
            set { SetValue(IsFocusProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        private static void IsFocusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FocusOnOffBehavior behavior)
            {
                behavior.AssociatedObject.Focus();
                Keyboard.ClearFocus();
            }
        }
    }
}
