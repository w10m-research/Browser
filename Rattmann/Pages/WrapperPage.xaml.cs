using Rattmann.Models;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using muxc = Microsoft.UI.Xaml.Controls;

namespace Rattmann.Pages {
    public sealed partial class WrapperPage : Page {
        public WrapperPage() {
            this.InitializeComponent();
        }

        public List<muxc.TabViewItem> TabViewItemCollection {
            get {
                var tabs = new List<muxc.TabViewItem>();
                foreach (TabModel item in App.Tabs.Tabs) {

                    var tab = new muxc.TabViewItem {
                        IconSource = new muxc.SymbolIconSource() { Symbol = Symbol.Document },
                        Header = item.History[item.HistoryIndex].Title
                    };
                    
                    var frame = new Frame();
                    tab.Content = frame;
                    frame.Navigate(typeof(Pages.WebViewPage));

                    tabs.Add(tab);
                }

                return tabs;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            coreTitleBar.LayoutMetricsChanged += this.CoreTitleBar_LayoutMetricsChanged;

            Window.Current.SetTitleBar(this.CustomDragRegion);

            // TODO: use this
            TabModel tab = App.Tabs.Tabs[App.Tabs.TabIndex];
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, Object args) {
            if (this.FlowDirection == FlowDirection.LeftToRight) {
                this.CustomDragRegion.MinWidth = sender.SystemOverlayRightInset;
                this.ShellTitlebarInset.MinWidth = sender.SystemOverlayLeftInset;
            } else {
                this.CustomDragRegion.MinWidth = sender.SystemOverlayLeftInset;
                this.ShellTitlebarInset.MinWidth = sender.SystemOverlayRightInset;
            }

            this.CustomDragRegion.Height = this.ShellTitlebarInset.Height = sender.Height;
        }

        private void TabRoot_OnAddTabButtonClick(muxc.TabView sender, Object args) {
            App.Tabs.NewTab(new TabModel());

            // Refresh tabs
            this.TabRoot.TabItemsSource = this.TabViewItemCollection;

            // Set the new tab as active
            this.TabRoot.SelectedIndex = this.TabRoot.TabItems.Count - 1;
        }

        private void TabRoot_OnTabCloseRequested(muxc.TabView sender, muxc.TabViewTabCloseRequestedEventArgs args) {
            Int32 pos = this.TabRoot.TabItems.IndexOf(args.Tab);

            App.Tabs.CloseTab(App.Tabs.Tabs[pos]);

            // Refresh tabs
            this.TabRoot.TabItemsSource = this.TabViewItemCollection;

            // If we're closing the current tab; set the next one as active
            if (pos >= (this.TabRoot.TabItems.Count - 1))
                this.TabRoot.SelectedIndex = this.TabRoot.TabItems.Count - 1;
        }

        private void ButtonBase_OnClick(Object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(Pages.SettingsPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}
