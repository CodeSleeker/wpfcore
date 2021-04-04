using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfCore
{
    public static class ElementAnimation
    {
        public static async Task SlideUp(this FrameworkElement element, float seconds, double offset, Thickness margin)
        {
            var sb = new Storyboard();
            sb.SlideToTop(seconds, offset, margin);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideBottom(this FrameworkElement element, float seconds, double offset, Thickness margin)
        {
            var sb = new Storyboard();
            sb.SlideToBottom(seconds, offset, margin);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task FadeInElement(this FrameworkElement element, float seconds)
        {
            var sb = new Storyboard();
            sb.FadeIn(seconds);
            sb.Begin(element);
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task FadeOutElement(this FrameworkElement element, float seconds)
        {
            var sb = new Storyboard();
            sb.FadeOut(seconds);
            sb.Begin(element);
            await Task.Delay((int)seconds * 1000);
        }
    }
}
