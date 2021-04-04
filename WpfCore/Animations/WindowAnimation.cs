using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfCore
{
    public static class WindowAnimation
    {
        public static async Task FadeInWindow(this Window window, float seconds)
        {
            var sb = new Storyboard();
            sb.FadeIn(seconds);
            sb.Begin(window);
            window.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task FadeOutWindow(this Window window, float seconds)
        {
            var sb = new Storyboard();
            sb.FadeOut(seconds);
            sb.Begin(window);
            window.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
    }
}
