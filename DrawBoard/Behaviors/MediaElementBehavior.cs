using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace DrawBoard.Behaviors
{
    public class MediaElementBehavior : Behavior<MediaElement>
    {
        public static readonly DependencyProperty IsMediaElementPlayProperty =
            DependencyProperty.Register(nameof(IsMediaElementPlay), typeof(bool), typeof(MediaElementBehavior), new PropertyMetadata(false, propertyChangedCallback: IsMediaElementPlayPropertyChanged));

        public bool IsMediaElementPlay
        {
            get { return (bool)GetValue(IsMediaElementPlayProperty); }
            set { SetValue(IsMediaElementPlayProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        private static void IsMediaElementPlayPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MediaElementBehavior elementBehavior)
            {
                if (elementBehavior.AssociatedObject.Source != null)
                {
                    elementBehavior.AssociatedObject.Stop();
                    elementBehavior.AssociatedObject.Play();
                }
            }
        }
    }
}
