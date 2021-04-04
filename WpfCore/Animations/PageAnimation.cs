using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfCore
{
    public static class PageAnimation
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds, Thickness margin)
        {
            var sb = new Storyboard();
            sb.SlideFromRight(seconds, page.WindowWidth, margin);
            sb.FadeIn(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds, Thickness margin)
        {
            var sb = new Storyboard();
            sb.SlideToLeft(seconds, page.WindowWidth, margin);
            sb.FadeOut(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeInFromTop(this Page page, float seconds, Thickness margin)
        {
            var sb = new Storyboard();
            sb.SlideFromTop(seconds, page.WindowHeight, margin);
            sb.FadeIn(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToBottom(this Page page, float seconds, Thickness margin)
        {
            var sb = new Storyboard();
            sb.SlideToBottom(seconds, page.WindowHeight, margin);
            sb.FadeOut(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task FadeInPage(this Page page, float seconds)
        {
            var sb = new Storyboard();
            sb.FadeIn(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task FadeOutPage(this Page page, float seconds)
        {
            var sb = new Storyboard();
            sb.FadeOut(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
    }
}
