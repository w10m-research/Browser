using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Rattmann.Pages {
    public sealed partial class WebViewPage : Page {
        public WebViewPage() {
            this.InitializeComponent();
        }

        private void SettingsButton_OnClick(Object sender, RoutedEventArgs e) {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame?.Navigate(typeof(Pages.SettingsPage), null, new DrillInNavigationTransitionInfo());
        }

        private void WebRoot_OnNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args) {
            this.AddressBar.Text = this.WebRoot.Source.AbsoluteUri.ToString();
        }
    }
}
