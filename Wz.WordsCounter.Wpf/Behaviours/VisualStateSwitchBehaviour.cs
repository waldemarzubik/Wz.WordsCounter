using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Wz.WordsCounter.Wpf.Behaviours
{
    public class VisualStateSwitchBehaviour : Behavior<ListBox>
    {
        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof (bool), typeof (VisualStateSwitchBehaviour),
                new PropertyMetadata(false, OnIsOnpropertyChanged));

        public bool IsOn
        {
            get { return (bool) GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        private static void OnIsOnpropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behaviour = d as VisualStateSwitchBehaviour;
            if (behaviour != null)
            {
                behaviour.SetVisibility((bool) e.NewValue);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            SetVisibility(IsOn);
        }

        private void SetVisibility(bool isOn)
        {
            AssociatedObject.Visibility = isOn ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}