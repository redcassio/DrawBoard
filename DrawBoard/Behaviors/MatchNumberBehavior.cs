using Microsoft.Xaml.Behaviors;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace DrawBoard.Behaviors
{
    public class MatchNumberBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
        }

        private void AssociatedObject_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
