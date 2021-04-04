using System.Threading.Tasks;
using System.Windows.Controls;
using static WpfCore.ServiceExtensions;

namespace WpfCore
{
    public class BasePage : Page
    {
        public PageEnum LoadAnimation { get; set; } = PageEnum.SlideAndFadeInFromRight;
        public PageEnum UnLoadAnimation { get; set; } = PageEnum.SlideAndFadeOutToLeft;

        public bool WillAnimateOut { get; set; }
        public float SlideSeconds { get; set; } = 0.5f;

        public BasePage()
        {
            if (this.LoadAnimation != PageEnum.None)
                this.Visibility = System.Windows.Visibility.Collapsed;
            this.Loaded += BasePage_Loaded;
        }

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (WillAnimateOut)
                await AnimateOut();
            else
                await AnimateIn();
        }
        public async Task AnimateIn()
        {
            if (this.LoadAnimation == PageEnum.None) return;
            switch (this.LoadAnimation)
            {
                case PageEnum.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSeconds, Margin);
                    break;
                case PageEnum.SlideAndFadeInFromTop:
                    await this.SlideAndFadeInFromTop(SlideSeconds, Margin);
                    break;
                case PageEnum.FadeInAnimation:
                    await this.FadeInPage(SlideSeconds);
                    break;
            }
        }
        public async Task AnimateOut()
        {
            if (this.UnLoadAnimation == PageEnum.None) return;
            switch (this.UnLoadAnimation)
            {
                case PageEnum.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSeconds, Margin);
                    break;
                case PageEnum.SlideAndFadeOutToBottom:
                    await this.SlideAndFadeOutToBottom(SlideSeconds, Margin);
                    break;
                case PageEnum.FadeOutAnimation:
                    await this.FadeOutPage(SlideSeconds);
                    break;
            }
        }
    }
    public class BasePage<VM> : BasePage where VM: BaseViewModel, new()
    {
        private VM _ViewModel;
        public VM ViewModel
        {
            get { return _ViewModel; }
            set
            {
                if (_ViewModel == value)
                    return;
                _ViewModel = value;
                this.DataContext = _ViewModel;
            }
        }

        public BasePage(): base()
        {
            ViewModel = Service<VM>() ?? new VM();
        }
        public BasePage(VM viewModel = null) : base()
        {
            if (viewModel != null)
                ViewModel = viewModel;
            else
                ViewModel = Service<VM>() ?? new VM();
        }
    }
}
