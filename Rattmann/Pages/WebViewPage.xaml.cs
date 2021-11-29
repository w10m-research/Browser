using Rattmann.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Rattmann.Pages {
    public sealed partial class WebViewPage : Page {
        public WebViewPage() {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            // TODO: use this
            TabModel tab = App.Tabs.Tabs[App.Tabs.TabIndex];

            if (tab.History[tab.HistoryIndex].URL != null)
                this.AddressBar.Text = tab.History[tab.HistoryIndex].URL.AbsoluteUri;
        }

        private void AddressBar_OnGotFocus(Object sender, RoutedEventArgs e) {
            // Hide actions
            this.AddressBar.BorderThickness = new Thickness(0, 2, 0, 0);
            this.BottomBar.OverflowButtonVisibility = CommandBarOverflowButtonVisibility.Collapsed;
            this.TabsSeparator.Visibility = Visibility.Collapsed;
            this.AddressSeparator.Visibility = Visibility.Collapsed;
            this.TabsBtn.Visibility = Visibility.Collapsed;
            this.ReloadBtn.Visibility = Visibility.Collapsed;
        }

        private void AddressBar_OnLostFocus(Object sender, RoutedEventArgs e) {
            // Show actions
            this.AddressBar.BorderThickness = new Thickness(0);
            this.BottomBar.OverflowButtonVisibility = CommandBarOverflowButtonVisibility.Auto;
            this.TabsSeparator.Visibility = Visibility.Visible;
            this.AddressSeparator.Visibility = Visibility.Visible;
            this.TabsBtn.Visibility = Visibility.Visible;
            this.ReloadBtn.Visibility = Visibility.Visible;
        }

        private void TabsBtn_OnClick(Object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(Pages.TabsPage), null, new DrillInNavigationTransitionInfo());
        }

        private void SettingsBtn_OnClick(Object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(Pages.SettingsPage), null, new DrillInNavigationTransitionInfo());
        }

        private void AddressBar_OnKeyDown(Object sender, KeyRoutedEventArgs e) {
            if (e.Key != Windows.System.VirtualKey.Enter)
                return;

            String url = this.AddressBar.Text;

            if (!url.Contains(".") && !url.Contains("://"))
                return; // TODO: handle search

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "https://" + url;

            App.Tabs.NavigateTo(new LocationModel() {
                URL = new Uri(url)
            });
        }
    }
}
