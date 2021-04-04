using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfCore
{
    public static class StoryboardHelper
    {
        public static void SlideFromRight(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Right + offset, margin.Top, margin.Left - offset, margin.Bottom),
                To = new Thickness(margin.Right, margin.Top, margin.Left, margin.Bottom),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }
        public static void SlideToRight(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom),
                To = new Thickness(margin.Left + offset, margin.Top, margin.Right - offset, margin.Bottom),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static void SlideFromLeft(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Left - offset, margin.Top, margin.Right + offset, margin.Bottom),
                To = new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }
        public static void SlideToLeft(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom),
                To = new Thickness(margin.Left - offset, margin.Top, margin.Right + offset, margin.Bottom),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static void SlideFromTop(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Left, margin.Top - offset, margin.Right, margin.Bottom + offset),
                To = new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }
        public static void SlideToTop(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom),
                To = new Thickness(margin.Left, margin.Top - offset, margin.Right, margin.Bottom + offset),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static void SlideFromBottom(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Left, margin.Top + offset, margin.Right, margin.Bottom - offset),
                To = new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }
        public static void SlideToBottom(this Storyboard storyboard, float seconds, double offset, Thickness margin)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(margin.Left, margin.Top, margin.Right, margin.Bottom),
                To = new Thickness(margin.Left, margin.Top + offset, margin.Right, margin.Bottom - offset),
                DecelerationRatio = 0.5f
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static void FadeIn(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }
        public static void FadeOut(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }
    }
}
