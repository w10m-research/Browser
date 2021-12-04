using Rattmann.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using muxc = Microsoft.UI.Xaml.Controls;

namespace Rattmann.Pages {
    public sealed partial class WrapperPage : Page {
        public ObservableCollection<muxc.TabViewItem> TabViewItemCollection = new ObservableCollection<muxc.TabViewItem>();

        public WrapperPage() {
            this.InitializeComponent();

            this.CreateNewTab();
        }

        private void CreateNewTab() {
            var tab = new muxc.TabViewItem {
                IconSource = new muxc.SymbolIconSource() { Symbol = Symbol.NewWindow },
                Header = "New tab"
            };

            var frame = new Frame();
            tab.Content = frame;
            frame.Navigate(typeof(Pages.WebViewPage), tab, new DrillInNavigationTransitionInfo());

            this.TabViewItemCollection.Add(tab);
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
            this.CreateNewTab();
        }

        private void TabRoot_OnTabCloseRequested(muxc.TabView sender, muxc.TabViewTabCloseRequestedEventArgs args) {
            this.TabViewItemCollection.Remove(args.Tab);
        }
    }
}
