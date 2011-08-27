using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System;

namespace SQLServerCompanion.Controls
{
    class ProgressBarEx : ProgressBar
    {
        public bool ShowAnimation
        {
            get { return (bool)GetValue(ShowAnimationProperty); }
            set { SetValue(ShowAnimationProperty, value); }
        }

        public static readonly DependencyProperty ShowAnimationProperty =
            DependencyProperty.Register("ShowAnimation", typeof(bool), typeof(ProgressBarEx), new UIPropertyMetadata(true));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ProgressBarEx), new UIPropertyMetadata(String.Empty));

        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForegroundOverlapped.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(ProgressBarEx), new FrameworkPropertyMetadata(Brushes.Black));

        public Brush TextColorOverlapped
        {
            get { return (Brush)GetValue(TextColorOverlappedProperty); }
            set { SetValue(TextColorOverlappedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForegroundOverlapped.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorOverlappedProperty =
            DependencyProperty.Register("TextColorOverlapped", typeof(Brush), typeof(ProgressBarEx), new FrameworkPropertyMetadata(Brushes.White));

        public Brush TextColorIndeterminate
        {
            get { return (Brush)GetValue(TextColorIndeterminateProperty); }
            set { SetValue(TextColorIndeterminateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForegroundOverlapped.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorIndeterminateProperty =
            DependencyProperty.Register("TextColorIndeterminate", typeof(Brush), typeof(ProgressBarEx), new FrameworkPropertyMetadata(Brushes.Black));



        public bool ShowProcessing
        {
            get { return (bool)GetValue(ShowProcessingProperty); }
            set { SetValue(ShowProcessingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowProcessing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowProcessingProperty =
            DependencyProperty.Register("ShowProcessing", typeof(bool), typeof(ProgressBarEx), new UIPropertyMetadata(true));


    }
}
